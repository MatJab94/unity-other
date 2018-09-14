using UnityEngine;
using Game.Managers;

namespace Game.MyCamera
{
	[ExecuteInEditMode, RequireComponent(typeof(Camera))]
	public class OrthograficSize : MonoBehaviour
	{
		[SerializeField] Camera cam;

		void Start()
		{
			UpdateOrthograficSize();
		}

		void UpdateOrthograficSize()
		{
			cam.orthographicSize = ViewManager.visibleWorldSize * 0.5f;
		}
	}
}