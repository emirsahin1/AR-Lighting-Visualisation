using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onItemClick : MonoBehaviour
{
    private ModelInit modelInit;
    public void onClick(GameObject arModel)
    {
        modelInit = FindObjectOfType<ModelInit>();
        modelInit.setArModel(arModel);
    }
}
