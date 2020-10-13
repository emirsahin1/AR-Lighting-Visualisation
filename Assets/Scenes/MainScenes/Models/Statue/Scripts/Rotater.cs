using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public Vector3 rotationDirection;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotationDirection, Time.deltaTime * 35);
    }
}
