using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager game;
	public GameObject waitUI;
	public Player currentPlayer;
	bool lookForPlayers = true, waitForReady = true;
	readonly Player[] players = new Player[2];
	public Piece[] white, black;

	public void EndTurn()
	{
		currentPlayer = currentPlayer == players[0] ? players[1] : players[0];
	}

	void Awake()
	{
		game = this;
		waitUI.SetActive(true);
	}

	public void DisableWaitUI()
	{
		waitUI.SetActive(false);
	}

	void Update()
	{
		if (lookForPlayers)
		{
			var playerObjects = GameObject.FindGameObjectsWithTag("Player");
			if (playerObjects.Length == 2)
			{
				lookForPlayers = false;
				players[0] = playerObjects[0].GetComponent<Player>();
				players[1] = playerObjects[1].GetComponent<Player>();
				DisableWaitUI();
			}
		}
		else if (waitForReady)
		{
			if (players[0].ready && players[1].ready)
			{
				if (players[0].myTurn != players[1].myTurn)
				{
					waitForReady = false;
					currentPlayer = players[0].myTurn ? players[0] : players[1];
					players[0].Initialise();
					players[1].Initialise();
				}
			}
		}
	}
}
