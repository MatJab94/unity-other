using UnityEngine;

namespace Game.Managers
{
	public class EventManager : MonoBehaviour
	{
		public delegate void Void_String(string value);
		public static Void_String UpdateFPS = delegate { };

		public delegate void Void_Bool(bool value);
		public static Void_Bool UpdateLimitFramerate = delegate { };
		public static Void_Bool UpdatePixelPerfectMode = delegate { };

		public delegate void Void_Int(int value);
		public static Void_Int UpdateTargetFramerate = delegate { };

		public delegate void Void_Empty();
		public static Void_Empty OnResolutionChanged = delegate { };
		public static Void_Empty OnCameraSizeChanged = delegate { };
	}
}