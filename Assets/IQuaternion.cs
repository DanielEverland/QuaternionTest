using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuaternion
{
    void FromEuler(Vector3 euler);
    Vector3 Rotate(Vector3 point);
}
