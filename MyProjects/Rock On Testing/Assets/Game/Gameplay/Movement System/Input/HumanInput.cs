using Game.Helper;
using UnityEngine;

namespace Game.Gameplay.MovementSystem
{
	public class HumanInput : Input
	{
		protected override void UpdateCurrentMoveInput()
		{
			float inputX = UnityEngine.Input.GetAxisRaw(Axis.MoveHorizontal);
			float inputY = UnityEngine.Input.GetAxisRaw(Axis.MoveVertical);
			currentMoveInput = new Vector2(inputX, inputY);
		}
	}
}