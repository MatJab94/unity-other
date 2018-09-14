using UnityEngine;

namespace Game.Cursor
{
	public class Cursor : MonoBehaviour
	{
		[SerializeField] Transform tf;
		[SerializeField] Camera cam;
		float x;
		float y;

		void FixedUpdate()
		{
			x = Input.mousePosition.x / Screen.width;
			y = Input.mousePosition.y / Screen.height;

			tf.position = cam.ViewportToWorldPoint(new Vector3(x, y, 0.0f/*cam.nearClipPlane*/));
		}
	}
}