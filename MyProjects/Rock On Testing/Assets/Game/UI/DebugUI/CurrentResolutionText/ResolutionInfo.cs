using UnityEngine;
using UnityEngine.UI;
using Game.Managers;

namespace Game.UI.DebugUI
{
	[RequireComponent(typeof(Text))]
	public class ResolutionInfo : MonoBehaviour
	{
		[SerializeField] Text resolutionInfo;

		void OnEnable()
		{
			EventManager.OnResolutionChanged += UpdateText;
			UpdateText();
		}

		void UpdateText()
		{
			if(resolutionInfo != null)
			{
				resolutionInfo.text = Screen.width + "x" + Screen.height + "\nFS " + Screen.fullScreen;
			}
		}
	}
}