using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
	public float speed = 2.5f;
	public float epsilon = .1f;
	public Vector3 from = Vector3.back, to = Vector3.forward;

	Rigidbody rb;
	Vector3 direction, moveAmount;
	bool pingPong;

	List<Rigidbody> collisions = new List<Rigidbody>();

	Vector3 directionFrom, directionTo;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		directionFrom = (from - to).normalized;
		directionTo = (to - from).normalized;
	}

	void FixedUpdate()
	{
		if ((rb.position - from).sqrMagnitude < epsilon) pingPong = false;
		if ((rb.position - to).sqrMagnitude < epsilon) pingPong = true;

		direction = pingPong ? directionFrom : directionTo;
		moveAmount = direction * speed * Time.fixedDeltaTime;

		rb.MovePosition(rb.position + moveAmount);
		foreach (var rb in collisions) rb.position += moveAmount;

	}

	void OnCollisionEnter(Collision collision)
	{
		var rb = collision.gameObject.GetComponent<Rigidbody>();
		if (rb != null) RegisterObject(rb);
	}

	void OnCollisionExit(Collision collision)
	{
		var rb = collision.gameObject.GetComponent<Rigidbody>();
		if (rb != null) UnregisterObject(rb);
	}

	void RegisterObject(Rigidbody rb)
	{
		collisions.Add(rb);
	}

	void UnregisterObject(Rigidbody rb)
	{
		if (collisions.Contains(rb)) collisions.Remove(rb);
	}
}
