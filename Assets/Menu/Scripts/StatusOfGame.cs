using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusOfGame : MonoBehaviour
{
    public static int coins = 0;
    public static int shipType = 1; // default 1

    public static void AddCoin()
    {
        coins += 1;
    }

    public static void SelectShipType(int typeOfShip)
    {
        shipType = typeOfShip;
    }

    public static int GetCoins()
    {
        return coins;
    }

    public static void MinusCoins(int minusAmount)
    {
        coins = coins - minusAmount;
    }
}