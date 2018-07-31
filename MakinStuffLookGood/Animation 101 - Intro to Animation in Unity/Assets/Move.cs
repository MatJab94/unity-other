using UnityEngine;

public class Move : MonoBehaviour
{
	public float speed = 1;

	void Update()
	{
		if (Input.GetKey(KeyCode.A))
		{
			gameObject.transform.position += Vector3.left * Time.deltaTime * speed;
		}
		if (Input.GetKey(KeyCode.D))
		{
			gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
		}
	}
}
