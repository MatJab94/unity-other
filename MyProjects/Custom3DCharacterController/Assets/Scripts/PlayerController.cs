using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	public float walkSpeed = 2, runSpeed = 5, jumpStrength = 5;
	public float height = 1, skin = .1f, radius = .5f;
	public float maxStepHeight = .3f;
	public float stepClimbingSpeed = 1.5f;
	public float maxHoleDepth = 2;
	public LayerMask ground;

	Transform cam;
	Rigidbody rb;
	Vector3 input;
	RaycastHit stepHit, heightHit;
	Vector3 step;
	float speed;
	float stepHeight;
	float holeDepth;

	public bool IsRunning { get; private set; }
	public bool IsGrounded { get; private set; }
	public bool IsJumping { get; private set; }
	float GroundY { get { return transform.position.y - height * .5f; } }


	readonly string horizontal = "Horizontal", vertical = "Vertical";

	void Awake()
	{
		cam = Camera.main.transform;
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		GetInput();
		Rotate();
		if (Input.GetKeyDown(KeyCode.Space)) StartCoroutine(Jump());
	}

	void FixedUpdate()
	{
		bool groundUnder = GroundCheck(); // check for ground directly under Player
		bool stepInFront = StepCheck(); // check for steps in fron of the Player
		bool groundInFront = HeightCheck(); // check if there aren't any holes in front of the Player

		if (stepInFront)
		{
			// if steps are detected, calculate how high they are
			stepHeight = stepHit.point.y - GroundY;
			if (stepHeight < 0) stepHeight = 0;
		}

		// calculate depth of a hole in front of the Player
		holeDepth = groundInFront ? Mathf.Abs(heightHit.point.y - GroundY) : maxHoleDepth;

		// player is grounded if either raycast hits ground and he's not jumping at the same time
		IsGrounded = (groundUnder || stepInFront) && !IsJumping;

		Move();
	}

	void GetInput()
	{
		input.x = Input.GetAxisRaw(horizontal);
		input.z = Input.GetAxisRaw(vertical);
		input.Normalize();
	}

	void Rotate()
	{
		Quaternion rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
		transform.rotation = rotation;
		input = rotation * input;
	}

	IEnumerator Jump()
	{
		if (!IsJumping && IsGrounded)
		{
			rb.velocity += Vector3.up * jumpStrength;
			IsJumping = true;
			yield return new WaitForFixedUpdate();
			bool ground = false;
			while (!ground)
			{
				yield return new WaitForFixedUpdate();
				ground = GroundCheck();
			}
			IsJumping = false;
		}
	}

	bool GroundCheck()
	{
		return Physics.Raycast(transform.position, Vector3.down,
							   height * .5f + skin, ground);
	}

	bool StepCheck()
	{
		return Physics.Raycast(transform.position + input * radius, Vector3.down,
							   out stepHit, height * .5f + skin, ground);
	}

	bool HeightCheck()
	{
		return Physics.Raycast(transform.position + input * radius, Vector3.down,
							   out heightHit, height * .5f + maxHoleDepth, ground);
	}

	void Move()
	{
		// change speed when running/walking
		IsRunning = Input.GetKey(KeyCode.LeftShift);
		speed = IsRunning ? runSpeed : walkSpeed;

		// if steps are detected, calculate how much to move player up
		step = stepHeight < maxStepHeight && stepHeight > 0.05f ? Vector3.up : Vector3.zero;

		// move Player if there isn't a hole in front him, or if he's jumping
		if (holeDepth < maxHoleDepth || IsJumping)
			rb.position += (step * stepClimbingSpeed + input * speed) * Time.fixedDeltaTime;
	}
}
