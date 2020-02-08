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
		//Vector3 temp = euler;
		//euler.x = temp.y;
		//euler.y = temp.z;
		//euler.z = temp.x;

		euler.x *= Mathf.Deg2Rad;
		euler.y *= Mathf.Deg2Rad;
		euler.z *= Mathf.Deg2Rad;

		// Abbreviations for the various angular functions
		double yCos = Mathf.Cos(euler.y / 2);
		double ySin = Mathf.Sin(euler.y / 2);
		double zCos = Mathf.Cos(euler.z / 2);
		double zSin = Mathf.Sin(euler.z / 2);
		double xCos = Mathf.Cos(euler.x / 2);
		double xSin = Mathf.Sin(euler.x / 2);

		Debug.Log($"xCos: {yCos.ToString("F3")}\nxSin: {ySin.ToString("F3")}\nyCos: {zCos.ToString("F3")}\nySin: {zSin.ToString("F3")}\nzCos: {xCos.ToString("F3")}\nzSin: {xSin.ToString("F3")}");

		X = ySin * zSin * xCos + yCos * zCos * xSin;
		Y = ySin * zCos * xCos + yCos * zSin * xSin;
		Z = yCos * zSin * xCos - ySin * zCos * xSin;
		W = yCos * zCos * xCos - ySin * zSin * xSin;
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
	public Vector3 ToEuler()
	{
		Vector3 euler;

		euler.x = Mathf.Atan2((float)(2 * X * W - 2 * Y * Z), (float)(1 - 2 * X * X - 2 * Z * Z));
		euler.y = Mathf.Atan2((float)(2 * Y * W - 2 * X * Z), (float)(1 - 2 * Y * Y - 2 * Z * Z));
		euler.z = Mathf.Asin((float)(2 * X * Y + 2 * Z * W));


		euler.x *= Mathf.Rad2Deg;
		euler.y *= Mathf.Rad2Deg;
		euler.z *= Mathf.Rad2Deg;

		return euler;
	}
    public override string ToString()
    {
        return $"({X.ToString("F3")}, {Y.ToString("F3")}, {Z.ToString("F3")}, {W.ToString("F3")})";
    }
}
