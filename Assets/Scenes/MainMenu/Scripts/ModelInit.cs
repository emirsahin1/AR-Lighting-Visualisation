using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInit : MonoBehaviour
{
    public static GameObject modelInit;
    private GameObject _arModelToPlace;
    public GameObject arModelToPlace { get { return _arModelToPlace; } set { _arModelToPlace = value; } }

    //Interactive means that lights can be moved.

    void Awake()
    {
        if(modelInit != null)
        {
            Destroy(gameObject);
            return;
        }
        modelInit = this.gameObject;
        GameObject.DontDestroyOnLoad(modelInit);
    }

    public void setArModel(GameObject arModel)
    {
        arModelToPlace = arModel;
    }
}
