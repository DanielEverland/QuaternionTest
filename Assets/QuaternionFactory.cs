using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionFactory
{
    public QuaternionFactory(QuaternionType type)
    {
        switch (type)
        {
            case QuaternionType.Unity:
                constructor = new UnityConstructor();
                break;
            case QuaternionType.Artemis:
                constructor = new ArtemisConstructor();
                break;
            default:
                throw new System.ArgumentException();
        }
    }

    private readonly IQuaternionConstructor constructor;

    public IQuaternion FromEuler(Vector3 euler)
    {
        return constructor.FromEuler(euler);
    }

    private interface IQuaternionConstructor
    {
        IQuaternion FromEuler(Vector3 euler);
    }

    private class UnityConstructor : IQuaternionConstructor
    {
        public IQuaternion FromEuler(Vector3 euler)
        {
            UnityQuaternion quaternion = new UnityQuaternion();
            quaternion.FromEuler(euler);

            return quaternion;
        }
    }
    private class ArtemisConstructor : IQuaternionConstructor
    {
        public IQuaternion FromEuler(Vector3 euler)
        {
            ArtemisQuaternion quaternion = new ArtemisQuaternion();
            quaternion.FromEuler(euler);

            return quaternion;
        }
    }
}
public enum QuaternionType
{
    None = 0,

    Unity = 1,
    Artemis = 2,
}