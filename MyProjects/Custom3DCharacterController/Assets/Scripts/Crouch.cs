using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Crouch : MonoBehaviour
{
	public float crouchScale = 0.5f;

	[SerializeField] KeyCode crouchKey = KeyCode.LeftControl;

	public bool IsCrouching { get; private set; }
	Vector3 Scale { get { return transform.localScale; } }

	PlayerController player;

	void Awake()
	{
		player = GetComponent<PlayerController>();
	}

	void Update()
	{
		if (Input.GetKeyDown(crouchKey)) ToggleCrouch();
	}

	void ToggleCrouch()
	{
		if (IsCrouching)
		{
			if (!CheckCeiling())
			{
				IsCrouching = false;
				player.height /= crouchScale;
				Vector3 newScale = new Vector3(Scale.x, Scale.y / crouchScale, Scale.z);
				transform.localScale = newScale;
			}
		}
		else
		{
			IsCrouching = true;
			player.height *= crouchScale;
			Vector3 newScale = new Vector3(Scale.x, Scale.y * crouchScale, Scale.z);
			transform.localScale = newScale;
		}
	}

	bool CheckCeiling()
	{
		return Physics.Raycast(transform.position, Vector3.up,
							   player.height / crouchScale * .5f + player.skin, player.ground);
	}
}
