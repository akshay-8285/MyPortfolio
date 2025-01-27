using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class UserData
{
    public string Name;
    public int Coins;

    public UserData()
    {
        Name = "Guest_" + Random.Range(1111, 99999);
        Coins = 200;
    }
}
