using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollZ : MonoBehaviour
{
    public float scrollSpeed = 20;
    
	void Update()
	{
        Vector3 nextPosition = transform.position;
        Vector3 localVectorUp = transform.TransformDirection(0, 1, 0);
        nextPosition += localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = nextPosition;
	}
}
