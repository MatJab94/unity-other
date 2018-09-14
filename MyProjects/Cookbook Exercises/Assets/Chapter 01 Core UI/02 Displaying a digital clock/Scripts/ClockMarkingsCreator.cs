using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMarkingsCreator : MonoBehaviour
{
    private const float markDegrees = 360f / 12f;
    public Transform clockFace;
    public GameObject markingPrefab;

    void Start()
    {
        if (markingPrefab != null)
        {
            for (int i = 0; i < 12; i++)
            {
                GameObject marking = Instantiate(markingPrefab);
                
                marking.transform.localRotation = Quaternion.Euler(0f, 0f, i * markDegrees);

                float angle = i * -markDegrees;
                float radius = clockFace.localScale.x * 0.46f;
                Vector3 center = clockFace.localPosition;
                marking.transform.localPosition = PositionInCircle(center, radius, angle);

                marking.transform.parent = clockFace.gameObject.transform;
                marking.name = markingPrefab.name + " " + (i + 1);
            }
        }
    }

    private Vector3 PositionInCircle(Vector3 center, float radius, float angle)
    {
        Vector3 position;
        position.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        position.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        position.z = center.z;
        return position;
    }
}
