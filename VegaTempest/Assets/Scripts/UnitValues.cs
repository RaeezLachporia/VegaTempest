using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitValues : MonoBehaviour
{
    public string unitName;
    public int Damage;
    public int MaxHp;
    public int CurrentHp;

    public bool RemoveHealth(int dmg)
    {
        CurrentHp -= dmg;

        if (CurrentHp <= 0)

            return true;
        else
            return false;
    }
}
