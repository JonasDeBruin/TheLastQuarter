using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Buildmanager in Scene");
            return;
        }
        instance = this;

    }

    public GameObject standardTurretPrefab;

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
        Debug.Log(turretToBuild.name);
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild () { return turretToBuild; }
}
