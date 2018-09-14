using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Game.UI.DebugUI
{
	[RequireComponent(typeof(Text))]
	public class PPSCounter : MonoBehaviour
	{
		[SerializeField] Text Counter;
		[SerializeField] float updateDelay = 0.5f;

		void OnEnable()
		{
			StartCoroutine(UpdatePPSText());
		}

		IEnumerator UpdatePPSText()
		{
			while (true)
			{
				yield return new WaitForSecondsRealtime(updateDelay);
				UpdateCounter();
			}
		}

		void UpdateCounter()
		{
			Counter.text = (1 / Time.fixedDeltaTime).ToString("F0");
		}
	}
}