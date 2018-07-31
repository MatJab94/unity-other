using UnityEngine;

[ExecuteInEditMode]
public class CustomImageEffect : MonoBehaviour
{
	public Material EffectMaterial;
	[Range(0, 20)] public int Iterations;
	[Range(1, 8)] public int DownRes;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		int width = source.width / DownRes;
		int height = source.height / DownRes;

		RenderTexture rt = RenderTexture.GetTemporary(width, height);
		Graphics.Blit(source, rt);

		for(int i = 0; i < Iterations; i++)
		{
			RenderTexture rt2 = RenderTexture.GetTemporary(width, height);
			Graphics.Blit(rt, rt2, EffectMaterial);
			RenderTexture.ReleaseTemporary(rt);
			rt = rt2;
		}
		Graphics.Blit(rt, destination);
		RenderTexture.ReleaseTemporary(rt);
	}
}