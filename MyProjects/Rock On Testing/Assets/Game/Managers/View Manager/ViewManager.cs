using UnityEngine;

namespace Game.Managers
{
	[ExecuteInEditMode]
	public class ViewManager : MonoBehaviour
	{
		public static int cameraSize = 0, visibleWorldSize = 0;
		[SerializeField, Range(1, 256)] int tileSize = 32;
		[SerializeField, Range(1, 32)] int numOfTilesVertically = 9;
		[SerializeField] bool pixelPerfectMode = true;

		void OnEnable()
		{
			CalculateVisibleWorldSize();

			EventManager.UpdatePixelPerfectMode += UpdatePixelPerfectMode;
			EventManager.OnResolutionChanged += UpdateCameraSize;

			EventManager.UpdatePixelPerfectMode(pixelPerfectMode);
		}

		void CalculateVisibleWorldSize()
		{
			visibleWorldSize = tileSize * numOfTilesVertically;
		}

		void UpdatePixelPerfectMode(bool value)
		{
			pixelPerfectMode = value;
			EventManager.OnResolutionChanged();
		}

		void UpdateCameraSize()
		{
			if (pixelPerfectMode && IsResolutionHighEnough())
			{
				int pixelPerfectScale = Mathf.Min(Screen.width, Screen.height) / visibleWorldSize;
				cameraSize = visibleWorldSize * pixelPerfectScale;
			}
			else
			{
				cameraSize = Mathf.Min(Screen.width, Screen.height);
			}
			EventManager.OnCameraSizeChanged();
		}

		bool IsResolutionHighEnough()
		{
			return Screen.width >= visibleWorldSize && Screen.height >= visibleWorldSize;
		}
	}
}