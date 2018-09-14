using UnityEngine;

namespace Game.Gameplay.MovementSystem
{
	public abstract class Speed : MonoBehaviour
	{
		public abstract float CurrentSpeed { get; }
	}
}