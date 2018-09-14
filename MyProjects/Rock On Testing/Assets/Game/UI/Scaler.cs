using UnityEngine;
using Game.Managers;

namespace Game.UI.DebugUI
{
	[ExecuteInEditMode, RequireComponent(typeof(RectTransform))]
	public class Scaler : MonoBehaviour
	{
		[SerializeField] RectTransform rectTransforms;

		void OnEnable()
		{
			EventManager.OnCameraSizeChanged += UpdateCameraSize;
		}

		void UpdateCameraSize()
		{
			int cameraSize = ViewManager.cameraSize;
			float newScale = CalculateNewScale(cameraSize);

			if(rectTransforms != null)
			{
				rectTransforms.localScale = new Vector3(newScale, newScale, 1);
			}
		}

		float CalculateNewScale(int cameraSize)
		{
			return cameraSize / 1344.0f;
		}
	}
}