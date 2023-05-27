using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum BattleStates { Start, PlayerTurn, EnemyTurn, Win, Lose}
public class BattleSystem : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public GameObject EnemyCharacter;
    
    public TMP_Text NemeyName;
    public Transform PlayerSpawn;
    public Transform EnemySpawn;
    public BattleStates State;

    UnitValues playerUnit;
    UnitValues enemyUnit;
    // Start is called before the first frame update
    void Start()
    {
        State = BattleStates.Start;
        SetupBattle();

    }
    void SetupBattle()
    {
        GameObject playerGameO =Instantiate(PlayerCharacter, PlayerSpawn);
        playerUnit = playerGameO.GetComponent<UnitValues>();
        GameObject enemyGameO=Instantiate(EnemyCharacter, EnemySpawn);
        enemyUnit = enemyGameO.GetComponent<UnitValues>();

        NemeyName.text = "Cameron The bald one";
    }    
    
}
