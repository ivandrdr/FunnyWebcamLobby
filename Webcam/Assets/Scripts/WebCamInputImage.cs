using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamInputImage : MonoBehaviour
{
    bool camAvailable;
    WebCamTexture webCam;

    public RawImage background;
    public AspectRatioFitter fit;

    private void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }
        for (int i = 0; i < devices.Length; i++)
        {
            webCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
        }

        if(webCam == null)
        {
            Debug.Log("Unable to find web camera");
            return;
        }

        webCam.Play();
        background.texture = webCam;
    }
}
