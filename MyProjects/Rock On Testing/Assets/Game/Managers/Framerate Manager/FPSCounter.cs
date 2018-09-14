using System.Collections;
using UnityEngine;

namespace Game.Managers
{
	public class FPSCounter : MonoBehaviour
	{
		[SerializeField] bool showFPS = false;
		[SerializeField, Tooltip("How often the FPS Counter updates.")] float updateTime = 0.5f;

		void Start()
		{
			StartCoroutine(UpdateFPSCounter());
		}

		IEnumerator UpdateFPSCounter()
		{
			string framerate = "";
			while (true)
			{
				if (showFPS)
				{
					int count = 0;
					float timeSinceLastUpdate = 0.0f;
					while (timeSinceLastUpdate < updateTime)
					{
						yield return new WaitForEndOfFrame();
						timeSinceLastUpdate += Time.unscaledDeltaTime;
						count++;
					}
					framerate = CalculateNewFramerate(timeSinceLastUpdate, count);
				}
				else
				{
					framerate = "";
					yield return new WaitForSecondsRealtime(updateTime);
				}
				EventManager.UpdateFPS(framerate);
			}
		}

		string CalculateNewFramerate(float timeSinceLastUpdate, int count)
		{
			if (count != 0)
			{
				float averageTimePerFrame = timeSinceLastUpdate / count;
				int newFramerate = (int)(1.0f / averageTimePerFrame);
				return newFramerate.ToString();
			}
			else
			{
				return "ERROR";
			}
		}
	}
}