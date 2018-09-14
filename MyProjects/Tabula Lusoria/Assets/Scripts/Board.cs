using UnityEngine;
using UnityEngine.Networking;

public class Board : MonoBehaviour
{
	Transform currentPiece;

	public void SelectField(Vector3 fieldPosition)
	{
		if (currentPiece != null)
		{
			SendMoveToEnemy(currentPiece.GetComponent<Piece>().id, fieldPosition);
			currentPiece.position = fieldPosition;
			currentPiece.GetComponent<Piece>().Highlight(false);
			currentPiece = null;
			GameManager.game.EndTurn();
		}
	}

	public void SelectPiece(Transform piece, Player owner)
	{
		if (currentPiece != null) currentPiece.GetComponent<Piece>().Highlight(false);
		currentPiece = piece;
		piece.GetComponent<Piece>().Highlight(true);
	}

	public void SendMoveToEnemy(int piece, Vector3 fieldPosition)
	{
		GameManager.game.currentPlayer.SendMoveToEnemy(piece, fieldPosition);
	}

	public void ResetGame()
	{
		NetworkManager nm = FindObjectOfType<NetworkManager>();
		nm.ServerChangeScene("Board");
	}
}
