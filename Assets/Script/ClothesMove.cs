using System.Collections;
using System.Collections.Generic;
using Oculus.Platform.Models;
using UnityEngine;

public class ClothesMove : MonoBehaviour
{
    [SerializeField] private GameObject vrAvatar;
    private Vector3 _followOffset;
    
    // Start is called before the first frame update
    void Start()
    {
       // _followOffset = transform.position - vrAvatar.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector3 targetPosition = vrAvatar.transform.position + _followOffset;
        transform.position += vrAvatar.transform.position;  //(targetPosition - transform.position);
    }
}
