﻿using UnityEngine;
using UnityEditor;

namespace NeutronCat.SolarSystem
{
    [CustomEditor(typeof(SimpleSysObject))]
    public class SimpleSysObjectEditor : Editor
    {

        private SimpleSysObject _sysObject;

        private void Awake()
        {
            if (PlayerSettings.colorSpace == ColorSpace.Gamma)
            {
                PlayerSettings.colorSpace = ColorSpace.Linear;
                Debug.Log("Set the color space to linear space");
            }
        }

        public override void OnInspectorGUI()
        {
            _sysObject = target as SimpleSysObject;

            DrawDefaultInspector();

            if (GUILayout.Button("Set Radius"))
            {
                _sysObject.transform.localScale = new Vector3(_sysObject.equatorialRadius, _sysObject.polarRadius, _sysObject.equatorialRadius)
                    * SimpleSysObject.scaleFactor * 2;
            }

        }
    }
}