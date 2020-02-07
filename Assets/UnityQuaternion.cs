using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityQuaternion : IQuaternion
{
    private Quaternion quaternion;

    public void FromEuler(Vector3 euler)
    {
        quaternion = Quaternion.Euler(euler);
    }
    public Vector3 Rotate(Vector3 point)
    {
        return quaternion * point;
    }
    public override string ToString()
    {
        return quaternion.ToString();
    }
}
