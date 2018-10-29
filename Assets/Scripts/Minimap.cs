using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    void Start()
    {
        Debug.Log(Camera.allCamerasCount);

    }
    void Update()
    {
        GetComponent<Renderer>().material.mainTexture = Camera.allCameras[0].targetTexture;
    }
}
