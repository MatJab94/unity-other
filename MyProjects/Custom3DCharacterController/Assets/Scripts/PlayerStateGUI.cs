using UnityEngine;
using UnityEngine.UI;

public class PlayerStateGUI : MonoBehaviour
{
	[SerializeField] PlayerController player;
	[SerializeField] Text walkState;
	[SerializeField] Text jumpState;
	readonly string walk = "Walking", run = "Running",
					jump = "Jumping", ground = "On ground",
					fall = "Falling";

	void Update()
	{
		walkState.text = player.IsRunning ? run : walk;
		jumpState.text = player.IsGrounded ? ground : jump;
		if (!player.IsGrounded && !player.IsJumping) jumpState.text = fall;
	}
}
