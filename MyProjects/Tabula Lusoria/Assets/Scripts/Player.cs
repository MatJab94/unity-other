using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : NetworkBehaviour
{
	[SyncVar] public string playerName = "default";
	[SyncVar] public Color color = Color.gray;
	[SyncVar/*(hook = "OnTurnEnd")*/] public bool myTurn = false;
	[SyncVar] public bool ready;
	public SpriteRenderer sprite;
	public SpriteRenderer myTurnSprite;
	public Text nameText;
	Piece[] pieces;


	public void SendMoveToEnemy(int piece, Vector3 field)
	{
		CmdSendMove(piece, field);
	}

	[Command]
	void CmdSendMove(int piece, Vector3 field)
	{
		NetworkConnection target = null;

		var playerObjects = GameObject.FindGameObjectsWithTag("Player");
		if (playerObjects[0] == gameObject)
		{
			target = playerObjects[1].GetComponent<Player>().connectionToClient;
			playerObjects[1].GetComponent<Player>().TargetSendMove(target, piece, field);
		}
		else if (playerObjects[1] == gameObject)
		{
			target = playerObjects[0].GetComponent<Player>().connectionToClient;
			playerObjects[0].GetComponent<Player>().TargetSendMove(target, piece, field);
		}
		else Debug.Log("ERROR", this);

		TurnManager.EndTurn();
	}

	[TargetRpc]
	public void TargetSendMove(NetworkConnection target, int piece, Vector3 field)
	{
		if (pieces == GameManager.game.black)
		{
			GameManager.game.white[piece].transform.position = field;
		}
		else if (pieces == GameManager.game.white)
		{
			GameManager.game.black[piece].transform.position = field;
		}
		else Debug.Log("ERROR", this);

		GameManager.game.EndTurn();
	}

	public override void OnStartLocalPlayer()
	{
		var playerData =
			GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
		CmdSetupPlayer(playerData.playerName, playerData.color);
	}

	[Command]
	void CmdSetupPlayer(string name, Color color)
	{
		playerName = name;
		this.color = color;
		ready = true;
	}

	[Command]
	public void CmdEndTurn()
	{
		TurnManager.EndTurn();
	}

	void OnTurnEnd(bool turn)
	{
		myTurn = turn;
		myTurnSprite.color = turn ? Color.yellow : Color.clear;
	}

	public void Initialise()
	{
		sprite.color = color;
		myTurnSprite.color = myTurn ? Color.yellow : Color.clear;
		nameText.text = playerName;
		pieces = myTurn ? GameManager.game.white : GameManager.game.black;
		foreach (var piece in pieces) piece.owner = this;
	}

	[ClientRpc]
	public void RpcInitialise()
	{
		pieces = myTurn ? GameManager.game.white : GameManager.game.black;
		foreach (var piece in pieces) piece.owner = this;
	}
}
