using UnityEngine;

public class Rain : MonoBehaviour
{
	GameObject[] raindrops;
	public GameObject raindrop;
	public Vector2 startOffset;
	public Transform parentRain;
	public int numberOfDrops = 500;
	public float minSpeed = 3;
	public float maxSpeed = 20;
	public float width = 18;
	public float height = 5;
	public float gravityChange = 0.5f;
	public float bottom = -7;
	public float scale = 20;
	Vector3 defaultScale;
	
	void Start()
	{
		raindrops = new GameObject[numberOfDrops];
		defaultScale = raindrop.transform.localScale;
		for (int i = 0; i < raindrops.Length; i++)
		{
			raindrops[i] = Instantiate(raindrop, parentRain);
			ResetDrop(raindrops[i]);
		}
	}

	void ResetDrop(GameObject raindrop)
	{
		float x = Random.Range(startOffset.x, startOffset.x + width);
		float y = Random.Range(startOffset.y, startOffset.y + height);

		float chance = Random.Range(-5, 20);
		float z = 0;
		if (chance > 0) { z = Random.Range(minSpeed, maxSpeed/2); }
		else { z = Random.Range(minSpeed*2, maxSpeed); }
		raindrop.transform.position = new Vector3(x, y, z);
		raindrop.transform.localScale = defaultScale;
		raindrop.transform.localScale *= z/scale;
	}
	
	void Update()
	{
		for (int i = 0; i < raindrops.Length; i++)
		{
			float x = raindrops[i].transform.position.x;
			float y = raindrops[i].transform.position.y;
			float z = raindrops[i].transform.position.z;
			Vector3 newPosition = new Vector3(x, y - (Time.deltaTime * z), z + (Time.deltaTime * gravityChange));
			raindrops[i].transform.position = newPosition;

			if (raindrops[i].transform.position.y < bottom) ResetDrop(raindrops[i]);
		}
	}
}
