using UnityEngine;

public class Ball : MonoBehaviour
{
	Rigidbody2D rb;
	Animator anim;
	AudioSource audsource;
	public AudioClip pong;
	public float speed = 10;
	public float bounce = 1;
	Vector2 direction = Vector2.left;
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		audsource = GetComponent<AudioSource>();
		ResetBall();
	}

	public void ChangeDirection(Transform tf)
	{
		float distance = transform.position.y - tf.position.y;
		
		if (distance > 0.5f) Bounce(1);
		if (distance < -0.5f) Bounce(-1);
		
		//rb.velocity = direction.normalized * speed;
	}

	void Bounce(int dir)
	{
		rb.velocity += Vector2.up * dir;
		anim.SetTrigger("bounce");
	}

	public void ResetBall()
	{
		float x = -Mathf.Sign(direction.x) * Mathf.CeilToInt(Mathf.Abs(direction.x));
		float y = Random.Range(-0.5f, 0.5f);
		direction = new Vector2(x, y);
		rb.velocity = direction.normalized * speed;

		transform.position = new Vector3();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		audsource.PlayOneShot(pong);
	}
}
