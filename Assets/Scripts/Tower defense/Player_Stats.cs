using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    private void Start()
    {
        Money = startMoney;
    }
}
