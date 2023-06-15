using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{

    public TMP_Text moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + Player_Stats.Money.ToString();
    }
}
