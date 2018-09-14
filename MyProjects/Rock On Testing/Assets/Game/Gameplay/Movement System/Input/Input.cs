using UnityEngine;

namespace Game.Gameplay.MovementSystem
{
	public abstract class Input : MonoBehaviour
	{
		[SerializeField] Movement movement;
		protected Vector2 currentMoveInput = Vector2.zero, previousMoveInput = Vector2.zero;
		
		public bool IsMoving { get { return currentMoveInput != Vector2.zero; } }
		public bool MoveInputChanged { get { return previousMoveInput != currentMoveInput; } }
		public bool StartedToMove { get { return IsMoving && previousMoveInput == Vector2.zero; } }

		void FixedUpdate()
		{
			UpdatePreviousMoveInput();
			UpdateCurrentMoveInput();
			movement.Move(currentMoveInput);
		}

		void UpdatePreviousMoveInput()
		{
			previousMoveInput = currentMoveInput;
		}

		protected abstract void UpdateCurrentMoveInput();
	}
}