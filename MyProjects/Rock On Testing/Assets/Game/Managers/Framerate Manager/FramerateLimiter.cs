using UnityEngine;

namespace Game.Managers
{
	public class FramerateLimiter : MonoBehaviour
	{
		[SerializeField] bool limitFramerate = false;
		[SerializeField, Range(30, 200)] int targetFramerate = 144;

		void OnEnable()
		{
			EventManager.UpdateLimitFramerate += value => { limitFramerate = value; };
			EventManager.UpdateTargetFramerate += value => { targetFramerate = value; };
		}

		void Start()
		{
			EventManager.UpdateLimitFramerate(limitFramerate);
			EventManager.UpdateTargetFramerate(targetFramerate);
		}

		void Update()
		{
			if (limitFramerate)
			{
				Application.targetFrameRate = targetFramerate;
			}
			else
			{
				Application.targetFrameRate = -1;
			}
		}
	}
}