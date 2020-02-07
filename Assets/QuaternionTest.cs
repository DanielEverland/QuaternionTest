using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionTest : MonoBehaviour
{
    private static Vector3 ArtemisOffset = new Vector3(0, 0, 0);
    private static Vector3 UnityOffset = new Vector3(0, 0, 0);

    private static float DummyScale = 0.3f;

    private TestHandler testHandler;

    private void Awake()
    {
        testHandler = new TestHandler(
            new TestCase(new QuaternionFactory(QuaternionType.Unity), UnityOffset, "Unity"),
            new TestCase(new QuaternionFactory(QuaternionType.Artemis), ArtemisOffset, "Artemis"));

        testHandler.SetPoint(new Vector3(0, 1, 0));
        testHandler.FromEuler(new Vector3(5, -5, 5));
    }
    private void Update()
    {
        testHandler.Rotate();
        testHandler.UpdateState();
    }
    private static GameObject GetDummy()
    {
        GameObject dummy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        dummy.transform.localScale = Vector3.one * DummyScale;

        return dummy;
    }
    private class TestHandler
    {
        public TestHandler(params TestCase[] tests)
        {
            cases = tests.ToList();
        }

        private readonly List<TestCase> cases;

        public void UpdateState()
        {
            PerformOnCases(x => { x.UpdateState(); });
        }
        public void SetPoint(Vector3 point)
        {
            PerformOnCases(x => { x.SetPoint(point); });
        }
        public void FromEuler(Vector3 euler)
        {
            PerformOnCases(x => { x.FromEuler(euler); });
        }
        public void Rotate()
        {
            PerformOnCases(x => x.Rotate());
        }
        private void PerformOnCases(System.Action<TestCase> action)
        {
            foreach (TestCase testCase in cases)
            {
                action(testCase);
            }
        }
    }
    private class TestCase
    {
        public TestCase(QuaternionFactory factory, Vector3 offset, string dummyName)
        {
            this.factory = factory;
            this.offset = offset;
            this.dummyName = dummyName;
        }

        private readonly QuaternionFactory factory;
        private readonly Vector3 offset;
        private readonly string dummyName;

        private IQuaternion quaternion;
        private GameObject dummy;
        private Vector3 dummyRepresentation;

        public void Rotate()
        {
            dummyRepresentation = quaternion.Rotate(dummyRepresentation);
        }
        public void FromEuler(Vector3 euler)
        {
            quaternion = factory.FromEuler(euler);
        }
        public void SetPoint(Vector3 point)
        {
            dummyRepresentation = point;

            CreateDummyIfNoneExists();
        }
        public void UpdateState()
        {
            if (dummy == null)
                return;

            dummy.transform.position = dummyRepresentation + offset;
        }
        private void CreateDummyIfNoneExists()
        {
            if (dummy != null)
                return;

            dummy = GetDummy();
            dummy.name = dummyName;
        }
    }
}
