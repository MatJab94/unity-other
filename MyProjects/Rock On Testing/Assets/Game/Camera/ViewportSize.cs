using UnityEngine;
using Game.Managers;

namespace Game.MyCamera
{
	[ExecuteInEditMode, RequireComponent(typeof(Camera))]
	public class ViewportSize : MonoBehaviour
	{
		[SerializeField] Camera mainCamera;

		void OnEnable()
		{
			EventManager.OnCameraSizeChanged += UpdateViewportRect;
		}

		void UpdateViewportRect()
		{
			if (mainCamera != null)
			{
				Rect viewportRect = mainCamera.rect;
				int cameraSize = ViewManager.cameraSize;
				viewportRect.x = CalculateNormalisedMargin(Screen.width, cameraSize);
				viewportRect.y = CalculateNormalisedMargin(Screen.height, cameraSize);
				viewportRect.width = (float)cameraSize / Screen.width;
				viewportRect.height = (float)cameraSize / Screen.height;
				mainCamera.rect = viewportRect;
			}
		}

		float CalculateNormalisedMargin(int windowLength, int cameraSize)
		{
			int marginSizeInPixels = (windowLength - cameraSize) / 2;
			float normalisedMarginSize = (float)marginSizeInPixels / windowLength;
			return normalisedMarginSize;
		}
	}
}