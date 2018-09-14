using UnityEngine;

public class Mandelbrot : MonoBehaviour
{
	Texture2D texture;
	int width = 160; int height = 90;
	public int maxIter = 150;
	public float colorScale = 1f;
	public float zoom = 40;
	public float offsetX = -0.5f;
	public float offsetY = 0;

	void Start()
	{
		texture = new Texture2D(width, height);
		texture.filterMode = FilterMode.Point;
		GetComponent<Renderer>().material.mainTexture = texture;
		GetComponent<Renderer>().enabled = true;
	}

	void FixedUpdate()
	{
		Colorize(texture);

		if (Input.GetKey(KeyCode.A)) offsetX -= 1f / zoom;
		if (Input.GetKey(KeyCode.D)) offsetX += 1f / zoom;
		if (Input.GetKey(KeyCode.W)) offsetY -= 1f / zoom;
		if (Input.GetKey(KeyCode.S)) offsetY += 1f / zoom;
		if (Input.GetKey(KeyCode.KeypadPlus)) zoom *= 1.02f;
		if (Input.GetKey(KeyCode.KeypadMinus)) zoom *= 0.98f;
		if (Input.GetKey(KeyCode.R)) maxIter += 5;
		if (Input.GetKey(KeyCode.F)) maxIter -= 5;
	}

	void Colorize(Texture2D texture)
	{
		for (int y = 0; y < texture.height; y++)
		{
			for (int x = 0; x < texture.width; x++)
			{
				Vector2 v = Translate(x, y);
				Color color = MandelbrotColor(v.x, v.y);
				texture.SetPixel(x, y, color);
			}
		}
		texture.Apply();
	}

	Vector2 Translate(int x, int y)
	{
		return new Vector2(x - (width / 2), y - (height / 2)) / zoom + new Vector2(offsetX, -offsetY);
	}

	Color MandelbrotColor(float x, float y)
	{
		float zR = x; float zI = y; int i = 0;
		for (i = 0; i < maxIter; i++)
		{
			float newZR = zR * zR - zI * zI;
			float newZI = 2.0f * zR * zI;
			zR = newZR + x;
			zI = newZI + y;

			if (zR * zR + zI * zI > 4) break;
		}

		Color color = Color.black;
		if (i < maxIter)
		{
			float bright = (i / (float)maxIter) * colorScale;
			color = new Color(bright, bright, bright);
		}
		return color;
	}
}
