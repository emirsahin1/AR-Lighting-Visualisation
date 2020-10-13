using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteractions : MonoBehaviour
{
    private GameObject _arObject;
    public GameObject arObject
    {
        get { return _arObject; }
        set { _arObject = value; }
    }
    private ObjectPlacer objectPlacer;
    public SceneSwitcher sceneSwitcher;
    private float rotationSpeed = 0.18f;
    private float minimumScale = 0.02f;

    private void Start()
    {
        objectPlacer = GetComponent<ObjectPlacer>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            sceneSwitcher.switchScene(0);
        }
        Rotate();
        PinchtoZoom();
    }
    public void PinchtoZoom()
    {
        if (Input.touchCount == 2)
        {
            
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;


            float pinchAmount = deltaMagnitudeDiff * 0.008f * Time.deltaTime;


            if (!(pinchAmount > 0.0f && arObject.transform.localScale.x < minimumScale))
            {
                arObject.transform.localScale -= new Vector3(pinchAmount, pinchAmount, pinchAmount);
            }
            
        }
    }

    public void Rotate()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
                        
            if(touch.phase == TouchPhase.Moved)
            {
                Quaternion rotationX = Quaternion.Euler(0f, - touch.deltaPosition.x * rotationSpeed, 0f);
                arObject.transform.rotation = rotationX * arObject.transform.rotation;

            }
        }
    }
}
