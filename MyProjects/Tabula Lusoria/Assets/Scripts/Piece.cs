using UnityEngine;

public class Piece : MonoBehaviour
{
	public Board board;
	public Player owner;
	public SpriteRenderer highlight;
	public int id;

	private void OnMouseDown()
	{
		if (owner.myTurn && owner.isLocalPlayer)
			board.SelectPiece(transform, owner);
	}

	public void Highlight(bool on)
	{
		highlight.color = on ? Color.green : Color.clear;
	}
}
