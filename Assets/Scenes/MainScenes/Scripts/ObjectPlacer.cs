using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class ObjectPlacer : MonoBehaviour
{
    static List<ARRaycastHit> rayCastHits = new List<ARRaycastHit>();
    [SerializeField] private GameObject objectToPlace;

    private GameObject placedARObject;
    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private bool isObjectPlaced = false;
    private Vector3 objectScale;
    private ModelInit modelInit;

    public float prefabScale = 1;
    public float prefabRotation = 180;

    public GameObject placedPrefab
    {
        get
        {  return placedARObject; }
        set
        { placedARObject = value; }
    }

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        objectScale = new Vector3(prefabScale, prefabScale, prefabScale);
        aRPlaneManager = GetComponent<ARPlaneManager>();
    }
    private void Start()
    {
        modelInit = FindObjectOfType<ModelInit>();
        objectToPlace = modelInit.arModelToPlace;
    }
    /**
     * Checks to see if screen is touched and returns position
     * of the touch
     */
    bool TryGetTouchPosition(out Vector2 touchPosition, Touch touch)
    {

        if(Input.touchCount > 0) {
            touchPosition = touch.position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void deactivatePlanes()
    {
        aRPlaneManager.SetTrackablesActive(false);

        aRPlaneManager.enabled = false;
    }

    public void activatePlanes()
    {
        aRPlaneManager.SetTrackablesActive(true);
        aRPlaneManager.enabled = true;
        isObjectPlaced = false;
        Destroy(placedARObject);
    }

    void Update()
    {
        

        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        // Should not handle input if the player is pointing on UI.
        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }
        //If pointing at UI
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            return;
        }
        if (!TryGetTouchPosition(out Vector2 touchPosition, touch) || isObjectPlaced){
            return;
        }
        //If there is no touch position or an object has been placed, stop update.

        //If the raycast is on a plane, create a game object then deacticvate the planes.
        if(aRRaycastManager.Raycast(touchPosition, rayCastHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var hitPos = rayCastHits[0];

            placedPrefab = Instantiate(objectToPlace, hitPos.pose.position, hitPos.pose.rotation);

            placedPrefab.transform.localScale = objectScale;
            placedPrefab.transform.Rotate(0, prefabRotation, 0, Space.Self);

            isObjectPlaced = true;
            deactivatePlanes();

            gameObject.GetComponent<ObjectInteractions>().arObject = placedPrefab;
        }
    }
}
