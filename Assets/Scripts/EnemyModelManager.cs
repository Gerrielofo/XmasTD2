using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModelManager : MonoBehaviour
{
    public GameObject[] models;
    public int modelNo;
    public void SetModel(int model)
     {
        Debug.Log("modelID to load = " + model);
        modelNo = model;
        models[model].SetActive(true);
    }
}
