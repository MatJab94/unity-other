using UnityEngine;
using Tiled2Unity;

namespace Game.Level
{
	[ExecuteInEditMode, RequireComponent(typeof(TiledMap))]
	public class LevelGizmos : MonoBehaviour
	{
		[SerializeField] TiledMap levelScript;
		[SerializeField] Color gridColor;
		int mapWidth = 0, mapHeight = 0;
		int tileWidth = 0, tileHeight = 0;
		int tilesWide = 0, tilesHigh = 0;

		void OnEnable()
		{
			mapWidth = levelScript.MapWidthInPixels;
			mapHeight = levelScript.MapHeightInPixels;
			tileWidth = levelScript.TileWidth;
			tileHeight = levelScript.TileHeight;
			tilesWide = levelScript.NumTilesWide;
			tilesHigh = levelScript.NumTilesHigh;
		}

		void OnDrawGizmos()
		{
			Gizmos.color = gridColor;
			DrawHorizontalLines();
			DrawVerticalLines();
		}

		void DrawHorizontalLines()
		{
			Vector3 begining = Vector3.zero;
			Vector3 end = new Vector3(mapWidth, 0);
			for (int i = 0; i <= tilesHigh; i++)
			{
				Gizmos.DrawLine(begining, end);
				begining.y -= tileHeight;
				end.y -= tileHeight;
			}
		}

		void DrawVerticalLines()
		{
			Vector3 begining = Vector3.zero;
			Vector3 end = new Vector3(0, -mapHeight);
			for (int i = 0; i <= tilesWide; i++)
			{
				Gizmos.DrawLine(begining, end);
				begining.x += tileWidth;
				end.x += tileWidth;
			}
		}
	}
}