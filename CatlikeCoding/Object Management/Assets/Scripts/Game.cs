using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : PersistableObject
{
	public ShapeFactory shapeFactory;
	public PersistentStorage storage;
	public int levelCount;
	public KeyCode createKey = KeyCode.C, destroyKey = KeyCode.X,
				   newGameKey = KeyCode.N, saveKey = KeyCode.S,
				   loadKey = KeyCode.L;

	public float CreationSpeed { get; set; }
	public float DestructionSpeed { get; set; }

	float creationProgress, destructionProgress;
	List<Shape> shapes;
	const int saveVersion = 2;
	int loadedLevelBuildIndex;

	void Start()
	{
		shapes = new List<Shape>();
		if (Application.isEditor)
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene loadedScene = SceneManager.GetSceneAt(i);
				if (loadedScene.name.Contains("Level "))
				{
					SceneManager.SetActiveScene(loadedScene);
					loadedLevelBuildIndex = loadedScene.buildIndex;
					return;
				}
			}
		}
		StartCoroutine(LoadLevel(1));
	}

	IEnumerator LoadLevel(int levelBuildIndex)
	{
		enabled = false;
		if (loadedLevelBuildIndex > 0)
			yield return SceneManager.UnloadSceneAsync(loadedLevelBuildIndex);
		yield return SceneManager.LoadSceneAsync(levelBuildIndex, LoadSceneMode.Additive);
		SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(levelBuildIndex));
		loadedLevelBuildIndex = levelBuildIndex;
		enabled = true;
	}

	void Update()
	{
		creationProgress = AutoCreateDestroy(creationProgress, CreationSpeed, CreateShape);
		destructionProgress = AutoCreateDestroy(destructionProgress, DestructionSpeed, DestroyShape);

		if (Input.GetKey(createKey)) CreateShape();
		else if (Input.GetKey(destroyKey)) DestroyShape();
		else if (Input.GetKeyDown(newGameKey)) BeginNewGame();
		else if (Input.GetKeyDown(saveKey)) storage.Save(this, saveVersion);
		else if (Input.GetKeyDown(loadKey)) { BeginNewGame(); storage.Load(this); }
		else
		{
			for (int i = 1; i <= levelCount; i++)
			{
				if (Input.GetKeyDown(KeyCode.Alpha0 + i))
				{
					BeginNewGame();
					StartCoroutine(LoadLevel(i));
					return;
				}
			}
		}
	}

	float AutoCreateDestroy(float progress, float speed, System.Action method)
	{
		progress += Time.deltaTime * speed;
		while (progress >= 1f) { progress--; method(); }
		return progress;
	}

	void CreateShape()
	{
		Shape instance = shapeFactory.GetRandom();
		instance.transform.localPosition = Random.insideUnitSphere * 5f;
		instance.transform.localRotation = Random.rotation;
		instance.transform.localScale = Vector3.one * Random.Range(0.1f, 1f);
		instance.SetColor(Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.25f, 1f, 1f, 1f));
		shapes.Add(instance);
	}

	void DestroyShape()
	{
		if (shapes.Count == 0) return;
		int index = Random.Range(0, shapes.Count);
		shapeFactory.Reclaim(shapes[index]);
		int lastIndex = shapes.Count - 1;
		shapes[index] = shapes[lastIndex];
		shapes.RemoveAt(lastIndex);
	}

	void BeginNewGame()
	{
		for (int i = 0; i < shapes.Count; shapeFactory.Reclaim(shapes[i++])) ;
		shapes.Clear();
	}

	public override void Save(GameDataWriter writer)
	{
		writer.Write(shapes.Count);
		writer.Write(loadedLevelBuildIndex);
		for (int i = 0; i < shapes.Count; i++)
		{
			writer.Write(shapes[i].ShapeId);
			writer.Write(shapes[i].MaterialId);
			shapes[i].Save(writer);
		}
	}

	public override void Load(GameDataReader reader)
	{
		int version = reader.Version;
		if (version > saveVersion)
		{
			Debug.Log("Unsupported future save version " + version);
			return;
		}
		int count = version <= 0 ? -version : reader.ReadInt();
		StartCoroutine(LoadLevel(version < 2 ? 1 : reader.ReadInt()));
		for (int i = 0; i < count; i++)
		{
			int shapeId = version > 0 ? reader.ReadInt() : 0;
			int materialId = version > 0 ? reader.ReadInt() : 0;
			Shape instance = shapeFactory.Get(shapeId, materialId);
			instance.Load(reader);
			shapes.Add(instance);
		}
	}
}
