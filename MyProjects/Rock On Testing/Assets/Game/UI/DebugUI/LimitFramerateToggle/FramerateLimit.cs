using UnityEngine;
using UnityEngine.UI;
using Game.Managers;

namespace Game.UI.DebugUI
{
	[RequireComponent(typeof(Text))]
	public class FramerateLimit : MonoBehaviour
	{
		[SerializeField] Text framerateLimit;

		void OnEnable()
		{
			EventManager.UpdateTargetFramerate += value => { framerateLimit.text = value.ToString(); };
		}
	}
}