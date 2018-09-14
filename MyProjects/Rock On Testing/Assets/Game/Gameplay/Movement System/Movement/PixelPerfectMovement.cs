using UnityEngine;

namespace Game.Gameplay.MovementSystem
{
	public class PixelPerfectMovement : Movement
	{
		[SerializeField] Rigidbody2D rb;
		[SerializeField] Speed speed;
		Vector2 moveAmount = Vector2.zero;
		bool inCollision = false;

		public override void Move(Vector2 moveInput)
		{
			ResetMoveAmountOnInputChange();
			CalculateMoveAmount(moveInput);
			AlignWithPixels();
			ApplyMoveAmount();
		}

		void ResetMoveAmountOnInputChange()
		{
			if (input.MoveInputChanged)
				moveAmount = Vector2.zero;
		}

		void CalculateMoveAmount(Vector2 moveInput)
		{
			Vector2 direction = moveInput.normalized;
			moveAmount += direction * speed.CurrentSpeed * Time.deltaTime;
		}

		void AlignWithPixels()
		{
			if (!inCollision)
			{
				Vector2 position = rb.position;
				float subPixelsX = position.x - Mathf.RoundToInt(position.x);
				float subPixelsY = position.y - Mathf.RoundToInt(position.y);
				Vector2 subPixels = new Vector2(subPixelsX, subPixelsY);
				rb.position -= subPixels;
			}
		}

		void ApplyMoveAmount()
		{
			Vector2 pixelsToMove = new Vector2((int)moveAmount.x, (int)moveAmount.y);
			rb.position += pixelsToMove;
			moveAmount -= pixelsToMove;
		}

		void OnCollisionEnter2D(Collision2D collision)
		{
			inCollision = true;
		}

		void OnCollisionExit2D(Collision2D collision)
		{
			inCollision = false;
		}
	}
}