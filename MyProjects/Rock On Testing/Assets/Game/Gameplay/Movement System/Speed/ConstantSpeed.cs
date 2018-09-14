using UnityEngine;

namespace Game.Gameplay.MovementSystem
{
	public class ConstantSpeed : Speed
	{
		[SerializeField, Range(0, 128)] int speed = 64;

		public override float CurrentSpeed
		{
			get
			{
				return speed;
			}
		}
	}
}