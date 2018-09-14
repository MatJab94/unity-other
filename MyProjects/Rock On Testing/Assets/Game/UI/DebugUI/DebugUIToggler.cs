using UnityEngine;
using Game.Helper;

namespace Game.UI.DebugUI
{
	public class DebugUIToggler : MonoBehaviour
	{
		[SerializeField] GameObject debugUI;

		void Update()
		{
			if (Input.GetButtonDown(Axis.DebugUIToggle))
			{
				debugUI.SetActive(!debugUI.activeInHierarchy);
			}
		}
	}
}