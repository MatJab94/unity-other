using UnityEngine;
using UnityEngine.UI;
using Game.Managers;

namespace Game.UI.DebugUI
{
	[RequireComponent(typeof(Toggle))]
	public class PixelPerfectMode : MonoBehaviour
	{
		[SerializeField] Toggle pixelPerfectMode;

		public void UpdatePixelPerfectMode(bool newValue)
		{
			EventManager.UpdatePixelPerfectMode(newValue);
		}
	}
}