using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCircle
{
    private const float StayTime = 0.6f;
    private readonly Color color;
    private Vector3 previousPosition;

    public DebugCircle(Color color)
    {
        this.color = color;
    }
    public void AddPosition(Vector3 pos)
    {
        Debug.DrawLine(previousPosition, pos, color, StayTime);
        previousPosition = pos;
    }
}
