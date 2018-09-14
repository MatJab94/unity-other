using UnityEngine;

namespace Game.Gameplay.MovementSystem
{
	public abstract class Movement : MonoBehaviour
	{
		[SerializeField] protected Input input;

		public abstract void Move(Vector2 moveInput);
	}
}