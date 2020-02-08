using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromEuler : MonoBehaviour
{
    [SerializeField]
    private Vector3 euler;
    [SerializeField]
    private uint decimals = 8;

    private string DecimalString { get { return $"F{decimals}"; } }

    private void Awake()
    {
        ArtemisQuaternion a = new ArtemisQuaternion();
        a.FromEuler(euler);

        Quaternion q = Quaternion.Euler(euler);

        Debug.Log($"Unity:\t({q.x.ToString(DecimalString)}, {q.y.ToString(DecimalString)}, {q.z.ToString(DecimalString)}, {q.w.ToString(DecimalString)})");
        Debug.Log($"Artemis:\t({a.X.ToString(DecimalString)}, {a.Y.ToString(DecimalString)}, {a.Z.ToString(DecimalString)}, {a.W.ToString(DecimalString)})");


        Vector3 qv = q.eulerAngles;
        Vector3 av = a.ToEuler();

        Debug.Log($"Unity:\t({qv.x.ToString(DecimalString)}, {qv.y.ToString(DecimalString)}, {qv.z.ToString(DecimalString)})");
        Debug.Log($"Artemis:\t({av.x.ToString(DecimalString)}, {av.y.ToString(DecimalString)}, {av.z.ToString(DecimalString)})");
    }
}
