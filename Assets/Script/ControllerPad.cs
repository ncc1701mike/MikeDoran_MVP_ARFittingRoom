using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerPad : MonoBehaviour
{
    [SerializeField] private OVRPassthroughLayer passthroughLayer;
    [SerializeField] private GameObject mirror, mirror1, mirror2;
    [SerializeField] private GameObject jacket, jeans, shoesLeft, shoesRight;
    [SerializeField] private GameObject jacket1, jeans1, shoesLeft1, shoesRight1;
    [SerializeField] private GameObject mannequinBase;
    [SerializeField] private GameObject mannequinController, voodooMannequin;
    [SerializeField] private GameObject vrAvatar;
    [SerializeField] private GameObject vrAvatarClothed;
    //[SerializeField] private InvokeEvents _invokeEvents;
    public AudioSource bossaNova;
    
    public bool isMirrorActive = false;
    public bool isVrAvatarActive = false;
    
    public void ActivateMirror()
    {

        if (passthroughLayer!=null)
        {
            passthroughLayer.enabled = !passthroughLayer.enabled;
        }

        if (passthroughLayer.enabled)
        {
            bossaNova.Play();
        }
        else
        {
            bossaNova.Stop();
        }

        /*MeshRenderer meshRendererC = mannequinController.GetComponent<MeshRenderer>();
        if (meshRendererC != null)
        {
            meshRendererC.enabled = !meshRendererC.enabled;
        }
        
        MeshRenderer meshRendererV = voodooMannequin.GetComponent<MeshRenderer>();
        if (meshRendererV != null)
        {
            meshRendererV.enabled = !meshRendererV.enabled;
        }*/
        
        MeshRenderer meshRendererB= mannequinBase.GetComponent<MeshRenderer>();
        if (meshRendererB != null)
        {
            meshRendererB.enabled = !meshRendererB.enabled;
        }

        isMirrorActive = !isMirrorActive;
        mirror.SetActive(isMirrorActive);
        mirror1.SetActive(isMirrorActive);
        vrAvatar.SetActive(isMirrorActive);
    }

    public void ActivateShoes()
    {

        MeshRenderer meshRendererL = shoesLeft.GetComponent<MeshRenderer>();
        if (meshRendererL != null)
        {
            meshRendererL.enabled = !meshRendererL.enabled;
        }

        MeshRenderer meshRendererR = shoesRight.GetComponent<MeshRenderer>();
        if (meshRendererR != null)
        {
            meshRendererR.enabled = !meshRendererR.enabled;
        }

        MeshRenderer meshRendererL1 = shoesLeft1.GetComponent<MeshRenderer>();
        if (meshRendererL1 != null)
        {
            meshRendererL1.enabled = !meshRendererL1.enabled;
        }

        MeshRenderer meshRendererR1 = shoesRight1.GetComponent<MeshRenderer>();
        if (meshRendererR1 != null)
        {
            meshRendererR1.enabled = !meshRendererR1.enabled;
        }

       // _invokeEvents.EventsExecuted();

    }
    
    public void ActivatePants()
    {

        SkinnedMeshRenderer skinnedMeshRenderer = jeans.GetComponent<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer != null)
        {
            skinnedMeshRenderer.enabled = !skinnedMeshRenderer.enabled;
        }

        SkinnedMeshRenderer skinnedMeshRenderer1 = jeans1.GetComponent<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer1 != null)
        {
            skinnedMeshRenderer1.enabled = !skinnedMeshRenderer1.enabled;
        }

       // _invokeEvents.EventsExecuted();

    }

    public void ActivateJacket()
    {

        SkinnedMeshRenderer skinnedMeshRenderer = jacket.GetComponent<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer != null)
        {
            skinnedMeshRenderer.enabled = !skinnedMeshRenderer.enabled;
        }

        SkinnedMeshRenderer skinnedMeshRenderer1 = jacket1.GetComponent<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer1 != null)
        {
            skinnedMeshRenderer1.enabled = !skinnedMeshRenderer1.enabled;
        }

        // _invokeEvents.EventsExecuted();

    }

    public void ActivateVRoutfit()
    {
        isVrAvatarActive = !isVrAvatarActive;
        vrAvatar.SetActive(!isVrAvatarActive);
        vrAvatarClothed.SetActive(isVrAvatarActive);
        ActivateShoes();
        ActivatePants();
        ActivateJacket();

        MeshRenderer meshRendererC = mannequinController.GetComponent<MeshRenderer>();
        if (meshRendererC != null)
        {
            meshRendererC.enabled = !meshRendererC.enabled;
        }
        
        MeshRenderer meshRendererV = voodooMannequin.GetComponent<MeshRenderer>();
        if (meshRendererV != null)
        {
            meshRendererV.enabled = !meshRendererV.enabled;
        }
        
        MeshRenderer meshRendererB= mannequinBase.GetComponent<MeshRenderer>();
        if (meshRendererB != null)
        {
            meshRendererB.enabled = !meshRendererB.enabled;
        }



    }
}
