using UnityEngine;

namespace Game.Managers
{
	public class PhysicsTime : MonoBehaviour
	{
		[SerializeField] int minimumPhysicsPerSecond = 60;
		[SerializeField] int maximumPhysicsPerSecond = 200;
		float maxPhysicsTime = 1 / 60.0f;
		float minPhysicsTime = 1 / 200.0f;

		void Awake()
		{
			maxPhysicsTime = 1 / (float)minimumPhysicsPerSecond;
			minPhysicsTime = 1 / (float)maximumPhysicsPerSecond;
		}

		void Update()
		{
			Time.fixedDeltaTime = Mathf.Clamp(Time.deltaTime, minPhysicsTime, maxPhysicsTime);
		}
	}
}