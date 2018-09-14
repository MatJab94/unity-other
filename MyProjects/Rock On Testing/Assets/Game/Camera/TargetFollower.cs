using UnityEngine;

namespace Game.MyCamera
{
	[ExecuteInEditMode]
	public class TargetFollower : MonoBehaviour
	{
		[SerializeField] Transform target;
		[SerializeField] Vector2 offset;
		[SerializeField] Mode initialMode;

		delegate Vector2 TargetMode(); TargetMode GetPosition;

		enum Mode { ExactPosition, RoundedPosition, IntPosition };

		void OnEnable()
		{
			switch (initialMode)
			{
				case Mode.ExactPosition:
					GetPosition = GetExactTargetPosition; break;
				case Mode.RoundedPosition:
					GetPosition = GetRoundedTargetPosition; break;
				case Mode.IntPosition:
					GetPosition = GetIntTargetPosition; break;
				default:
					Debug.Log("Incorrect mode choosen."); break;
			}
		}

		Vector2 GetExactTargetPosition()
		{
			float x = target.position.x;
			float y = target.position.y;
			return new Vector2(x, y);
		}

		Vector2 GetRoundedTargetPosition()
		{
			float x = Mathf.Round(target.position.x);
			float y = Mathf.Round(target.position.y);
			return new Vector2(x, y);
		}

		Vector2 GetIntTargetPosition()
		{
			float x = (int)target.position.x;
			float y = (int)target.position.y;
			return new Vector2(x, y);
		}

		void LateUpdate()
		{
			Vector2 targetPosition = GetPosition();
			transform.position = targetPosition + offset;
		}
	}
}