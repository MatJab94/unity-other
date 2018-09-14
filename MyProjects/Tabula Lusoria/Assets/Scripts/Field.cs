using UnityEngine;

public class Field : MonoBehaviour
{
	public Board board;

	private void OnMouseDown()
	{
		board.SelectField(transform.position);
	}
}
