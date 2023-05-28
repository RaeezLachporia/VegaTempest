using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BattleHudInfo : MonoBehaviour
{
    
    public Slider HealthBar;
    public TMP_Text playerName;
    public void setHud(UnitValues unitval)
    {
        playerName.text = unitval.name;
        HealthBar.maxValue = unitval.MaxHp;
        HealthBar.value = unitval.CurrentHp;
    }

    public void SetHp(int hp)
    {
        HealthBar.value = hp;
    }
}
