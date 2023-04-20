using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TeleprompterController : MonoBehaviour
{
    
    public RectTransform parentPanel;
    private List<string> _imageName;
    private int _imageNum = 0;
 
    // Use this for initialization
    void Start () 
    {
        _imageName = new List<string>();
        _imageName.Add ("Page1");
        _imageName.Add ("Page2");
        _imageName.Add ("Page3");
        _imageName.Add ("Page4");
    }
 
    public void LoadNextPic(bool LeftRight)
    {
        if(LeftRight)    // right if true
        {
            _imageNum ++;
            if (_imageNum > _imageName.Count - 1)
                _imageNum = 0;
        }
        else
        {
            _imageNum --;
            if(_imageNum < 0)
                _imageNum = _imageName.Count - 1;
        }
        string tempName = _imageName[_imageNum];
        
        
        
        Sprite mySprite =  Resources.Load <Sprite>(tempName);
        if (mySprite)
        {
            parentPanel.GetComponent<Image>().sprite = mySprite;
        } 
        else 
        {
            Debug.LogError("no sprite found ImageName = " + _imageName[_imageNum]);
        }
    }
}

