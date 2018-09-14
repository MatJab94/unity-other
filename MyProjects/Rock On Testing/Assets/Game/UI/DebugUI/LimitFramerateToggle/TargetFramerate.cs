using UnityEngine;
using Game.Managers;

namespace Game.UI.DebugUI
{
	public class TargetFramerate : MonoBehaviour
	{
		public void UpdateTargetFramerate(float newValue)
		{
			EventManager.UpdateTargetFramerate((int)newValue);
		}
	}
}