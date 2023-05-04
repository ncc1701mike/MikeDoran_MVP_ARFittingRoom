using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPad : MonoBehaviour
{
    [SerializeField] private GameObject mirror, mirror1, mirror2;
    [SerializeField] private GameObject jacket, jeans, shoes;
    [SerializeField] private GameObject jacket1, jeans1, shoes1;
    [SerializeField] private GameObject mannequin;
    [SerializeField] private GameObject vrAvatar;
    [SerializeField] private GameObject vrAvatarClothed;
    public AudioSource bossaNova;
    
    
    public void ActivateMirror()
    {
        mirror.SetActive(true);
        mirror1.SetActive(true);
        mannequin.SetActive(true);
        bossaNova.Play();
    }

    public void ActivateShoes()
    {
        shoes.SetActive(true);
        shoes1.SetActive(true);
    }
    
    public void ActivatePants()
    {
        jeans.SetActive(true);
        jeans1.SetActive(true);
    }

    public void ActivateJacket()
    {
        jacket.SetActive(true);
        jacket1.SetActive(true);
    }

    public void ActivateVRoutfit()
    {
        mirror2.SetActive(true);
        vrAvatar.SetActive(false);
        vrAvatarClothed.SetActive(true);
        mannequin.SetActive(false);
    }
}
