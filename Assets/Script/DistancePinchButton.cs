using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using OculusSampleFramework;

public class DistancePinchButton : MonoBehaviour
{
    public UnityEvent OnPinchActivate;
    public Color normalColor;
    public Color highlightedColor;
    public float maxDistance = 5.0f;
    public GraphicRaycaster graphicRaycaster;
    public Camera mainCamera;

    private OVRHand _hand;
    public Image _buttonImage;
    private bool _isHighlighted;

    private void Start()
    {
        _buttonImage = GetComponent<Image>();
        _buttonImage.color = normalColor;
    }

    private void Update()
    {
        if (!_hand)
        {
            _hand = FindObjectOfType<OVRHand>();
        }

        if (_hand)
        {
            Debug.Log("Hand position: " + _hand.PointerPose.position);

            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = mainCamera.WorldToScreenPoint(_hand.transform.position);

            List<RaycastResult> results = new List<RaycastResult>();
            graphicRaycaster.Raycast(eventData, results);
            Debug.Log("Raycast results count: " + results.Count);

            bool isButtonHit = false;
                foreach (RaycastResult result in results)
                {
                    Debug.Log("Raycast hit: " + result.gameObject.name + ", Layer: " + LayerMask.LayerToName(result.gameObject.layer));
                    if (result.gameObject.layer == LayerMask.NameToLayer("Button") && result.gameObject == gameObject)
                    {
                        isButtonHit = true;
                        break;
                    }
                }
            
            if (isButtonHit)
            {
                if (!_isHighlighted)
                {
                    _isHighlighted = true;
                    _buttonImage.color = highlightedColor;
                }

                if (_hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
                {
                    Debug.Log("Pinch detected");
                    OnPinchActivate.Invoke();
                }
            }
            else
            {
                if (_isHighlighted)
                {
                    _isHighlighted = false;
                    _buttonImage.color = normalColor;
                }
            }

        }
    }
}


