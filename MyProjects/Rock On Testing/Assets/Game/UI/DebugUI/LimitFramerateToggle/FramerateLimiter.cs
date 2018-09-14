using UnityEngine;
using UnityEngine.UI;
using Game.Managers;

namespace Game.UI.DebugUI
{
	[RequireComponent(typeof(Toggle))]
	public class FramerateLimiter : MonoBehaviour
	{
		[SerializeField] Toggle limitFramerate;

		public void UpdateLimitFramerate(bool newValue)
		{
			EventManager.UpdateLimitFramerate(newValue);
		}
	}
}