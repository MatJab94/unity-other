using UnityEngine;

public class Paddle : MonoBehaviour
{
	Rigidbody2D rb;
	public float speed = 10f;
	public KeyCode up;
	public KeyCode down;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (Input.GetKey(down)) Move(-1);
		if (Input.GetKey(up)) Move(1);
	}

	void Move(int direction)
	{
		rb.MovePosition(new Vector2(transform.position.x, transform.position.y + (direction * speed)));
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			Ball script = collision.gameObject.GetComponent<Ball>();
			script.ChangeDirection(gameObject.transform);
		}
	}
}
