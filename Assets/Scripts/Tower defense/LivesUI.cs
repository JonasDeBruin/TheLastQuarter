using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public TMP_Text livesText;
    // Update is called once per frame
    void Update()
    {
        livesText.text = Player_Stats.Lives + " LIVES";
    }
}
