#pragma warning disable 0649
using UnityEngine;
using UnityEngine.UI;
using Game.Helper;

namespace Game.UI.DebugUI
{
	public class InputDisplay : MonoBehaviour
	{
		[SerializeField]
		Button up, down, left, right,
		attack1, attack2, colorRed, colorGreen, colorBlue,
		mouseUp, mouseDown, mouseLeft, mouseRight,
		scrollWheelUp, scrollWheelDown, submit, cancel;

		void Update()
		{
			ShowMoveInputs();
			ShowAttackInputs();
			ShowColorInputs();
			ShowMouseMoveInputs();
			ShowControlInputs();
		}

		void ShowMoveInputs()
		{
			if (Input.GetAxisRaw(Axis.MoveVertical) < 0) down.interactable = true;
			else down.interactable = false;

			if (Input.GetAxisRaw(Axis.MoveVertical) > 0) up.interactable = true;
			else up.interactable = false;

			if (Input.GetAxisRaw(Axis.MoveHorizontal) < 0) left.interactable = true;
			else left.interactable = false;

			if (Input.GetAxisRaw(Axis.MoveHorizontal) > 0) right.interactable = true;
			else right.interactable = false;
		}

		void ShowAttackInputs()
		{
			if (Input.GetButton(Axis.Attack1)) attack1.interactable = true;
			else attack1.interactable = false;

			if (Input.GetButton(Axis.Attack2)) attack2.interactable = true;
			else attack2.interactable = false;
		}

		void ShowColorInputs()
		{
			if (Input.GetButton(Axis.ColorRed)) colorRed.interactable = true;
			else colorRed.interactable = false;

			if (Input.GetButton(Axis.ColorGreen)) colorGreen.interactable = true;
			else colorGreen.interactable = false;

			if (Input.GetButton(Axis.ColorBlue)) colorBlue.interactable = true;
			else colorBlue.interactable = false;
		}

		void ShowMouseMoveInputs()
		{
			if (Input.GetAxisRaw(Axis.MouseY) < 0) mouseDown.interactable = true;
			else mouseDown.interactable = false;

			if (Input.GetAxisRaw(Axis.MouseY) > 0) mouseUp.interactable = true;
			else mouseUp.interactable = false;

			if (Input.GetAxisRaw(Axis.MouseX) < 0) mouseLeft.interactable = true;
			else mouseLeft.interactable = false;

			if (Input.GetAxisRaw(Axis.MouseX) > 0) mouseRight.interactable = true;
			else mouseRight.interactable = false;

			if (Input.GetAxisRaw(Axis.MouseScrollWheel) < 0) scrollWheelDown.interactable = true;
			else scrollWheelDown.interactable = false;

			if (Input.GetAxisRaw(Axis.MouseScrollWheel) > 0) scrollWheelUp.interactable = true;
			else scrollWheelUp.interactable = false;
		}

		void ShowControlInputs()
		{
			if (Input.GetButton(Axis.Submit)) submit.interactable = true;
			else submit.interactable = false;

			if (Input.GetButton(Axis.Cancel)) cancel.interactable = true;
			else cancel.interactable = false;
		}
	}
}