using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtemisQuaternion : IQuaternion
{
    private double X;
    private double Y;
    private double Z;
    private double W;

    public void FromEuler(Vector3 euler)
    {
		Vector3 temp = euler;
		euler.x = temp.y;
		euler.y = temp.z;
		euler.z = temp.x;

		euler.x *= Mathf.Deg2Rad;
		euler.y *= Mathf.Deg2Rad;
		euler.z *= Mathf.Deg2Rad;

		// Abbreviations for the various angular functions
		double xCos = Mathf.Cos(euler.x / 2);
		double xSin = Mathf.Sin(euler.x / 2);
		double yCos = Mathf.Cos(euler.y / 2);
		double ySin = Mathf.Sin(euler.y / 2);
		double zCos = Mathf.Cos(euler.z / 2);
		double zSin = Mathf.Sin(euler.z / 2);

		X = xSin * ySin * zCos + xCos * yCos * zSin;
		Y = xSin * yCos * zCos + xCos * ySin * zSin;
		Z = xCos * ySin * zCos - xSin * yCos * zSin;
		W = xCos * yCos * zCos - xSin * ySin * zSin;
	}
	public Vector3 Rotate(Vector3 point)
	{
		double x = X * 2;
		double y = Y * 2;
		double z = Z * 2;
		double xx = X * x;
		double yy = Y * y;
		double zz = Z * z;
		double xy = X * y;
		double xz = X * z;
		double yz = Y * z;
		double wx = W * x;
		double wy = W * y;
		double wz = W * z;

		Vector3 res;
		res.x = (float)((1.0 - (yy + zz)) * point.x + (xy - wz) * point.y + (xz + wy) * point.z);
		res.y = (float)((xy + wz) * point.x + (1.0 - (xx + zz)) * point.y + (yz - wx) * point.z);
		res.z = (float)((xz - wy) * point.x + (yz + wx) * point.y + (1.0 - (xx + yy)) * point.z);
		return res;
	}
    public override string ToString()
    {
        return $"({X}, {Y}, {Z}, {W})";
    }
}
