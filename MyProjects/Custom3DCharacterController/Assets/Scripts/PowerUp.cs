using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(Collider))]
public class PowerUp : MonoBehaviour
{
	public float multiplier = 1.5f;
	public float duration = 5;

	MeshRenderer graphics;
	Collider collision;
	PlayerController player;

	void Awake()
	{
		graphics = GetComponent<MeshRenderer>();
		collision = GetComponent<Collider>();
	}

	void OnTriggerEnter(Collider other)
	{
		player = other.gameObject.GetComponent<PlayerController>();
		if (player != null)
		{
			player.walkSpeed *= multiplier;
			player.runSpeed *= multiplier;
			player.jumpStrength *= multiplier;
			graphics.enabled = false;
			collision.enabled = false;
			StartCoroutine(Wait());
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(duration);
		player.walkSpeed /= multiplier;
		player.runSpeed /= multiplier;
		player.jumpStrength /= multiplier;
		Destroy(gameObject);
	}
}
