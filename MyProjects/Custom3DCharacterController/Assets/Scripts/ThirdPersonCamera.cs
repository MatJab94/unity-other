using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	public float mouseSensitivity = 3, distance = 2;
	public float tiltMin = -50, tiltMax = 80;
	public Transform target;

	float pan, tilt;
	readonly string mouseX = "Mouse X", mouseY = "Mouse Y";

	void LateUpdate()
	{
		pan += Input.GetAxis(mouseX) * mouseSensitivity;
		tilt -= Input.GetAxis(mouseY) * mouseSensitivity;
		tilt = Mathf.Clamp(tilt, tiltMin, tiltMax);

		transform.eulerAngles = new Vector3(tilt, pan, 0);
		transform.position = target.position - transform.forward * distance;
	}
}
