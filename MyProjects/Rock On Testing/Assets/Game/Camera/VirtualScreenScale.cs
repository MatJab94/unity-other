using UnityEngine;
using Game.Managers;

namespace Game.MyCamera
{
	[ExecuteInEditMode, RequireComponent(typeof(Transform))]
	public class VirtualScreenScale : MonoBehaviour
	{
		[SerializeField] Transform virtualScreenQuad;

		void Start()
		{
			UpdateLocalScale();
		}

		private void UpdateLocalScale()
		{
			int visibleWorldSize = ViewManager.visibleWorldSize;
			virtualScreenQuad.localScale = new Vector3(visibleWorldSize, visibleWorldSize, 1);
		}
	}
}