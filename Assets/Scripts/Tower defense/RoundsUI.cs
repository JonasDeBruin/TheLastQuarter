using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundsUI : MonoBehaviour
{
    public TMP_Text text;
    private void Update()
    {
        text.text = TDGameManager.roundsSurvived.ToString();
    }
}
