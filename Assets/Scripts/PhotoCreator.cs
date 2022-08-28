using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

// https://stackoverflow.com/questions/24496438/can-i-take-a-photo-in-unity-using-the-devices-camera 

public class PhotoCreator : MonoBehaviour
{
    WebCamTexture webCamTexture;
    public GameObject cameraViewfinder;
    public GameObject targetPhoto;
    public Button takePhotoButton;

    void Start()
    {
        webCamTexture = new WebCamTexture();
        cameraViewfinder.GetComponent<Renderer>().material.mainTexture = webCamTexture; //Add Mesh Renderer to the GameObject to which this script is attached to
        webCamTexture.Play();

        takePhotoButton.onClick.AddListener(TakeNewPhoto);
    }


    void TakeNewPhoto()
    {
        // TakePhoto();
        Debug.Log("Called");

        // NOTE - you almost certainly have to do this here:

        

        // it's a rare case where the Unity doco is pretty clear,
        // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
        // be sure to scroll down to the SECOND long example on that doco page 

        Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
        photo.SetPixels(webCamTexture.GetPixels());
        photo.Apply();



        targetPhoto.GetComponent<Renderer>().material.mainTexture = photo;
    }

    

}
