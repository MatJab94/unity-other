using UnityEngine;

namespace Game.MyCamera
{
	[ExecuteInEditMode, RequireComponent(typeof(Camera))]
	public class CameraGizmos : MonoBehaviour
	{
		[SerializeField] Color gizmosColor;
		[SerializeField] Camera cameraComponent;
		[SerializeField] Transform transformComponent;

		Vector3 Size
		{
			get
			{
				float size = cameraComponent.orthographicSize * 2;
				return new Vector3(size, size, 0.0f);
			}
		}

		void OnDrawGizmos()
		{
			Gizmos.color = gizmosColor;
			Gizmos.DrawWireCube(transformComponent.position, Size);
		}
	}
}