using UnityEngine;

namespace Game.Managers
{
	public class FontFix : MonoBehaviour
	{
		[SerializeField] Font[] fonts;

		void Awake()
		{
			foreach (Font font in fonts)
			{
				font.material.mainTexture.filterMode = FilterMode.Point;
			}
		}
	}
}