using Game.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.DebugUI
{
	[RequireComponent(typeof(Dropdown))]
	public class ResolutionChanger : MonoBehaviour
	{
		[SerializeField] Dropdown resolutionsList;

		public void ChangeCurrentResolution(int index)
		{
			if (!Application.isEditor)
			{
				string listData = GetDataFromDropdownList(index);
				Resolution resolution = GetParsedResolution(listData);
				ResolutionManager.UpdateResolution(resolution.width, resolution.height);
			}
			else
			{
				Debug.Log("Changing resolution doesn't work in editor mode. Works only in the build.");
			}
		}

		string GetDataFromDropdownList(int index)
		{
			Dropdown.OptionData listItem = resolutionsList.options[index];
			return listItem.text;
		}

		Resolution GetParsedResolution(string listData)
		{
			string[] resolution = listData.Split('x');
			int width = int.Parse(resolution[0]);
			int height = int.Parse(resolution[1]);
			return new Resolution(width, height);
		}

		struct Resolution
		{
			public int width, height;

			public Resolution(int width, int height)
			{
				this.width = width;
				this.height = height;
			}
		}
	}
}