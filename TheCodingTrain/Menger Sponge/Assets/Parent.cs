using UnityEngine;
using UnityEngine.SceneManagement;

public class Parent : MonoBehaviour {

	public KeyCode spongify;
	public KeyCode minusX;
	public KeyCode plusX;
	public KeyCode minusY;
	public KeyCode plusY;
	public KeyCode minusZ;
	public KeyCode plusZ;
	public KeyCode reset;
	float xAngle, yAngle, zAngle;
	public float speed;
	public GameObject sponge;

	void Update()
	{
		if (Input.GetKeyDown(spongify))
		{
			Sponge[] sponges = gameObject.GetComponentsInChildren<Sponge>();
			foreach(Sponge sp in sponges)
			{
				StartCoroutine(sp.Spongify());
			}
		}
		if (Input.GetKey(minusX)) { xAngle = -Time.deltaTime * speed; }
		if (Input.GetKey(plusX)) { xAngle = Time.deltaTime * speed; }

		if (Input.GetKey(minusY)) { yAngle = -Time.deltaTime * speed; }
		if (Input.GetKey(plusY)) { yAngle = Time.deltaTime * speed; }

		if (Input.GetKey(minusZ)) { zAngle = -Time.deltaTime * speed; }
		if (Input.GetKey(plusZ)) { zAngle = Time.deltaTime * speed; }

		transform.Rotate(xAngle, yAngle, zAngle);

		xAngle = yAngle = zAngle = 0;

		if (Input.GetKey(reset))
		{
			SceneManager.LoadScene("sponge");
		}
	}
}
