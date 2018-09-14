using UnityEngine;

public class PlayerData : MonoBehaviour
{
	public string playerName = "NoName";
	public Color color = Color.magenta;

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	public void SetColorRed()
	{
		color = Color.red;
	}

	public void SetColorBlue()
	{
		color = Color.blue;
	}

	public void SetName(string name)
	{
		playerName = name;
	}
}
