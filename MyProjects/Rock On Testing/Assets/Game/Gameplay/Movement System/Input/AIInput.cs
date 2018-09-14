using System.Collections;
using UnityEngine;

namespace Game.Gameplay.MovementSystem
{
	public class AIInput : Input
	{
		bool coroutineRunning = false;

		Vector2 moveInput = Vector2.zero;

		protected override void UpdateCurrentMoveInput()
		{
			currentMoveInput = moveInput;

			if (!coroutineRunning)
			{
				coroutineRunning = true;
				StartCoroutine(UpdateInput());
			}
		}

		IEnumerator UpdateInput()
		{
			while (coroutineRunning)
			{
				yield return new WaitForSeconds(1.0f);
				int inputX = Random.Range(-1, 2);
				int inputY = Random.Range(-1, 2);
				moveInput = new Vector2(inputX, inputY);
				yield return new WaitForSeconds(0.5f);

				moveInput = new Vector2(0, 0);
			}
		}
	}
}