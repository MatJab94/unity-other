﻿using UnityEngine;

public class Billboard : MonoBehaviour
{
	Camera cam;

	void Start()
	{
		cam = FindObjectOfType<Camera>();
	}

	void Update()
	{
		transform.LookAt(cam.transform);
	}
}
