using UnityEngine;
using System.Collections;

namespace Game.Gameplay.MovementSystem
{
	public class DynamicSpeed : Speed
	{
		[SerializeField] Input input;
		[SerializeField, Range(1, 128), Tooltip("Max speed in units (\"pixels\") per second")] int maxSpeed = 90;
		[SerializeField, Range(1, 128), Tooltip("Min speed in units (\"pixels\") per second")] int minSpeed = 25;
		[SerializeField, Range(0.1f, 10.0f), Tooltip("How fast object reaches max speed\n2 = 1/2 sec, 5 = 1/5 sec and so on")] float acceleration = 5.0f;
		float currentSpeed = 0.0f;

		public override float CurrentSpeed
		{
			get
			{
				TryToUpdateSpeed();
				return currentSpeed;
			}
		}

		void TryToUpdateSpeed()
		{
			if (input.StartedToMove)
				StartCoroutine(UpdateSpeed());
		}

		IEnumerator UpdateSpeed()
		{
			float interpolateAmount = 0.0f;
			while (input.IsMoving)
			{
				interpolateAmount += acceleration * Time.deltaTime;
				currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, interpolateAmount);

				if (currentSpeed >= maxSpeed)
					break;

				yield return null;
			}
		}
	}
}