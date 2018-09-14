using UnityEngine;

namespace Game.Managers
{
	[ExecuteInEditMode]
	public class ViewSizeWarning : MonoBehaviour
	{
		[SerializeField] RenderTexture virtualScreenTexture;

		void Update()
		{
			CheckVirtualScreenResolution();
		}

		void CheckVirtualScreenResolution()
		{
			int visibleWorldSize = ViewManager.visibleWorldSize;
			if (virtualScreenTexture.height != visibleWorldSize || virtualScreenTexture.width != visibleWorldSize)
			{
				Debug.LogWarning("Virtual Screen Resolution doesn't match current View Size. It must be changed manually.");
			}
		}
	}
}