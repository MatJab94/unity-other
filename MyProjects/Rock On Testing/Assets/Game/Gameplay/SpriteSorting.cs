using UnityEngine;

namespace Game.Gameplay
{
	[RequireComponent(typeof(SpriteRenderer)), ExecuteInEditMode]
	public class SpriteSorting : MonoBehaviour
	{
		[SerializeField] SpriteRenderer spriteRenderer;

		void FixedUpdate()
		{
			spriteRenderer.sortingOrder = (int)transform.position.y * -1;
		}
	}
}