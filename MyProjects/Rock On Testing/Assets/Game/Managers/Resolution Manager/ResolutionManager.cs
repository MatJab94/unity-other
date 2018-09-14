using UnityEngine;

namespace Game.Managers
{
	[ExecuteInEditMode]
	public class ResolutionManager : MonoBehaviour
	{
		int currentWidth = 0, currentHeight = 0;

		public static void UpdateResolution(int width, int height)
		{
			Screen.SetResolution(width, height, Screen.fullScreen);
		}

		void OnEnable()
		{
			EventManager.OnResolutionChanged += UpdateResolution;
		}

		void UpdateResolution()
		{
			UpdateResolution(Screen.width, Screen.height);
		}

		void Start()
		{
			EventManager.OnResolutionChanged();
		}

		void Update()
		{
			if (ResolutionChanged())
			{
				EventManager.OnResolutionChanged();
			}
		}

		bool ResolutionChanged()
		{
			bool resolutionChanged = false;
			if (currentWidth != Screen.width || currentHeight != Screen.height)
			{
				currentWidth = Screen.width;
				currentHeight = Screen.height;
				resolutionChanged = true;
			}
			return resolutionChanged;
		}
	}
}