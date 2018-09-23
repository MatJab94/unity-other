using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
	public float velocity = 5;
	public float lifespan = 5;
	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * velocity;
		StartCoroutine(AutoDestruct());
	}

	IEnumerator AutoDestruct()
	{
		yield return new WaitForSeconds(lifespan);
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		// ignore other Bullets and Player
		if (other.GetComponent<Bullet>() == null &&
			other.GetComponent<PlayerController>() == null)
		{
			var rigidbody = other.GetComponent<Rigidbody>();
			if (rigidbody != null) rigidbody.velocity += rb.velocity;
			Destroy(gameObject);
		}
	}
}
