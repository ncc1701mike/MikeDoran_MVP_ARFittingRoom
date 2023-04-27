﻿using UnityEngine;
using System.Collections;

namespace NeutronCat.SolarSystem
{
    [AddComponentMenu("Scripts/Solar System/Simple Scene/SimpleSysObject")]
    public class SimpleSysObject : MonoBehaviour
    {

        public const int orbitSample = 100;
        public static bool drawOrbit = false;
        public const float scaleFactor = 0.0001f;

        public float equatorialRadius;
        public float polarRadius;
        public Transform moveAround;
        public float period;
        public float axialTilt;
        public float rotationPeriod;

        private Transform _myTransform;
        private Vector3 _initialVector;
        private Quaternion _moveAroundQuaternion;
        private static Material _lineMaterial;
        private static Color _deltaColor;

        void Awake()
        {
            if (moveAround == null) moveAround = GameObject.Find("Sun").transform;
            _myTransform = transform;
            _initialVector = _myTransform.position - moveAround.position;
            _moveAroundQuaternion = Quaternion.Euler(0, 0, 0);
            _myTransform.rotation *= Quaternion.Euler(0, 0, axialTilt);
            _deltaColor = Color.green * .5f / orbitSample;
            CreateLineMaterial();
        }

        void Update()
        {
            _moveAroundQuaternion *= Quaternion.Euler(0, -Time.deltaTime * SimpleViewer.timeScale / period, 0);
            _myTransform.position = _moveAroundQuaternion * _initialVector + moveAround.position;
            _myTransform.rotation *= Quaternion.Euler(0, -Time.deltaTime * SimpleViewer.timeScale / rotationPeriod, 0);
        }

        void OnRenderObject()
        {
            if (!drawOrbit)
                return;

            _lineMaterial.SetPass(0);

            Quaternion rotate = _moveAroundQuaternion;
            Color lerpColor = Color.green;

            GL.Begin(GL.LINES);

            GL.Color(lerpColor);
            GL.Vertex(_myTransform.position);
            rotate *= Quaternion.Euler(0, 360.0f / orbitSample, 0);
            lerpColor -= _deltaColor;
            GL.Color(lerpColor);
            GL.Vertex(rotate * _initialVector + moveAround.position);
            for (int i = 0; i < orbitSample - 1; ++i)
            {
                GL.Vertex(rotate * _initialVector + moveAround.position);
                rotate *= Quaternion.Euler(0, 360.0f / orbitSample, 0);
                lerpColor -= _deltaColor;
                GL.Color(lerpColor);
                GL.Vertex(rotate * _initialVector + moveAround.position);
            }
            GL.Vertex(rotate * _initialVector + moveAround.position);
            lerpColor -= _deltaColor;
            GL.Color(lerpColor);
            GL.Vertex(_myTransform.position);

            GL.End();
        }

        static void CreateLineMaterial()
        {
            if (!_lineMaterial)
            {
                var shader = Shader.Find("Hidden/Internal-Colored");
                _lineMaterial = new Material(shader);
                _lineMaterial.hideFlags = HideFlags.HideAndDontSave;
                _lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcColor);
                _lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.One);
                _lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
                _lineMaterial.SetInt("_ZWrite", 0);
            }
        }
    }
}