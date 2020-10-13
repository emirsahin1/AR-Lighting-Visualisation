using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class LightDirection : MonoBehaviour
{
    [SerializeField] private ARCameraManager _arCameraManager;
    public GameObject debugger;

    public ARCameraManager arCameraManager
    {
        get { return _arCameraManager; }
        set { _arCameraManager = value; }
    }
    private Vector3 lightDirections;
    // Start is called before the first frame update
    void OnEnable()
    {
        //Add ARCameraFrameEventArgs to monitor events per frame
        if (arCameraManager != null)
        {
            arCameraManager.frameReceived += FrameChanged;
        }
    }

    void OnDisable()
    {
        //Remove listening event
        if (arCameraManager != null)
        {
            arCameraManager.frameReceived -= FrameChanged;
        }
    }

    void FrameChanged(ARCameraFrameEventArgs args)
    {
        if (args.lightEstimation.mainLightDirection.HasValue)
        {
            debugger.GetComponent<Text>().text = "LIGH " + args.lightEstimation.mainLightDirection.Value.ToString();
            gameObject.transform.localRotation = Quaternion.Euler(args.lightEstimation.mainLightDirection.Value);
        }
    }


}
