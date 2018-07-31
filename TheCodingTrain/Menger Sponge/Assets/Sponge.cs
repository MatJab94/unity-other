using System.Collections;
using UnityEngine;

public class Sponge : MonoBehaviour
{
	public GameObject sponge;
	public Transform parent;

	public IEnumerator Spongify()
	{
		Vector3 position = transform.position;
		float scale = transform.localScale.x / 3f;

		for (int x = -1; x <= 1; x++)
		{
			for (int y = -1; y <= 1; y++)
			{
				for (int z = -1; z <= 1; z++)
				{
					Vector3 newPosition = position + new Vector3(x * scale, y * scale, z * scale);
					if (Mathf.Abs(x) + Mathf.Abs(y) + Mathf.Abs(z) > 1)
					{
						GameObject sp = Instantiate(sponge, parent);
						sp.transform.position = newPosition;
						sp.transform.localScale /= 3f;
					}
				}
			}
		}
		Destroy(gameObject);
		yield return null;
	}
}
