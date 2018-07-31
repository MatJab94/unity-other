using UnityEngine;

public class Explosion : MonoBehaviour
{
	public ParticleSystem Center;
	public ParticleSystem[] Ring;
	public ParticleSystem[] Debris;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			Play();
		}
	}

	public void Play()
	{
		Center.Play();
		for (int i = 0; i < Ring.Length; i++)
			Ring[i].Play();
		for (int i = 0; i < Debris.Length; i++)
			Debris[i].Play();
	}
}
