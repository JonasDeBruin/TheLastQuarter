using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool isTeleporterA;

    [SerializeField] private GameObject otherTeleporter;


    public IEnumerator WaitCollision()
    {
        Debug.Log("Wating");
        otherTeleporter.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        otherTeleporter.GetComponent<BoxCollider2D>().enabled = true;
    }
}