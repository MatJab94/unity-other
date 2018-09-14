using UnityEngine;
using UnityEngine.Networking;

public class TurnManager : NetworkBehaviour
{
	int whoStarts = -1;
	static GameObject[] playerObjects;
	public Vector3 spawn1, spawn2;

	void Awake()
	{
		whoStarts = Random.Range(0, 2);
	}

	void Update()
	{
		playerObjects = GameObject.FindGameObjectsWithTag("Player");
		if (playerObjects.Length == 2)
		{
			playerObjects[whoStarts].GetComponent<Player>().myTurn = true;

			playerObjects[0].transform.position = spawn1;
			playerObjects[1].transform.position = spawn2;

			gameObject.SetActive(false);
		}
	}

	public static void EndTurn()
	{
		foreach (var player in playerObjects)
		{
			var p = player.GetComponent<Player>();
			p.myTurn = !p.myTurn;
		}
	}
}
