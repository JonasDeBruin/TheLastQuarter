using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    private void OnMouseDown()
    {
        if (TDGameManager.gameEnded) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!buildManager.CanBuild) return;

        if (turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        buildManager.BuiltTurretOnNode(this);
        
    }
    private void OnMouseEnter()
    {
        if (TDGameManager.gameEnded) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (buildManager.HasMoney) rend.material.color = hoverColor;
        else rend.material.color = notEnoughMoneyColor;
    }

    private void OnMouseExit()
    {
        if (TDGameManager.gameEnded) return;
        rend.material.color = startColor;
    }
}
