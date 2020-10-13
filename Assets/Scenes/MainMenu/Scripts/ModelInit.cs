using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInit : MonoBehaviour
{
    public static GameObject modelInit;
    public GameObject arModelToPlace;

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
