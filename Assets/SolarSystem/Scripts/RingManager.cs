﻿using UnityEngine;
using System.Collections;

namespace NeutronCat.SolarSystem
{
    [AddComponentMenu("Scripts/Solar System/RingManager")]
    public class RingManager : MonoBehaviour
    {

        public int layerId;

        Transform _shadowLight;

        void Awake()
        {
            gameObject.layer = layerId;
            transform.Find("Ring").gameObject.layer = layerId;
            transform.Find("Ring Shadow Caster").gameObject.layer = layerId;
            _shadowLight = transform.Find("Shadow Light");
            _shadowLight.parent = null;
            _shadowLight.position = Vector3.zero;
            _shadowLight.GetComponent<Light>().cullingMask = 1 << layerId;
        }

        void Update()
        {
            _shadowLight.LookAt(transform, Vector3.up);
        }
    }

}