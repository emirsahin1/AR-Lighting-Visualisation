using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAllign : MonoBehaviour
{
    private Camera camera; 
    void Start()
    {
        camera = Camera.main;

    }

    // Update is called once per frame 
    void LateUpdate()
    {
        transform.LookAt(camera.transform);
        transform.rotation = Quaternion.LookRotation(camera.transform.forward);
    }
}
