using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModelManager : MonoBehaviour
{
    public GameObject[] models;
    public int modelNo;
    public void SetModel(int model)
    {
        Debug.Log("Model: " + model);
        modelNo = model;
        models[model].SetActive(true);
    }
}
