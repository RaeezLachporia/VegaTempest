using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BattleStates { Start, PlayerTurn, EnemyTurn, Win, Lose}
public class BattleSystem : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public GameObject EnemyCharacter;

    public Transform PlayerSpawn;
    public Transform EnemySpawn;
    public BattleStates State;
    // Start is called before the first frame update
    void Start()
    {
        State = BattleStates.Start;
        SetupBattle();

    }
    void SetupBattle()
    {
        Instantiate(PlayerCharacter, PlayerSpawn);
        Instantiate(EnemyCharacter, EnemySpawn);
    }    
    
}
