using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        if (TDGameManager.gameEnded) return;
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild( standardTurret);
    }
    public void SelectMissileLauncher()
    {
        if (TDGameManager.gameEnded) return;
        Debug.Log("Missile Launcer Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }


}
