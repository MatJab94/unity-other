using UnityEngine;
using UnityEngine.UI;
using Game.Managers;

namespace Game.UI.DebugUI
{
	[RequireComponent(typeof(Text))]
	public class FPSCounter : MonoBehaviour
	{
		[SerializeField] Text Counter;

		void OnEnable()
		{
			EventManager.UpdateFPS += value => { Counter.text = value; };
		}
	}
}