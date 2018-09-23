using UnityEngine;

public class Respawn : MonoBehaviour
{
	public Vector3 respawnPosition = Vector3.zero;

	void OnCollisionEnter(Collision collision)
	{
		var player = collision.gameObject.GetComponent<PlayerController>();
		if (player != null) player.transform.position = respawnPosition;
	}
}
