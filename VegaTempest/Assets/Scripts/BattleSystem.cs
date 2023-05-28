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
    
   
    public TMP_Text dialogueText;
    public Transform PlayerSpawn;
    public Transform EnemySpawn;
    public BattleStates State;

    public BattleHudInfo playerHud;
    public BattleHudInfo enemyHud;
    UnitValues playerUnit;
    UnitValues enemyUnit;
    // Start is called before the first frame update
    void Start()
    {
        State = BattleStates.Start;
        StartCoroutine(SetupBattle());

    }
    IEnumerator SetupBattle()
    {
        GameObject playerGameO =Instantiate(PlayerCharacter, PlayerSpawn);
        playerUnit = playerGameO.GetComponent<UnitValues>();
        GameObject enemyGameO=Instantiate(EnemyCharacter, EnemySpawn);
        enemyUnit = enemyGameO.GetComponent<UnitValues>();


        dialogueText.text = "2 friends decide to settle who is the better fighter, who will win";
        playerHud.setHud(playerUnit);
        enemyHud.setHud(enemyUnit);
        yield return new WaitForSeconds(2f);

        State = BattleStates.PlayerTurn;
        PlayerTurn();
  
    }   

    void PlayerTurn()
    {
        dialogueText.text = "choose an action";
    }
    
    public void AttackButtonClicked()
    {
        if(State!= BattleStates.PlayerTurn)
            return;

        StartCoroutine(playerAttacking());
    }

    public void HealButtonClicked()
    {
        if (State != BattleStates.PlayerTurn)
            return;

        StartCoroutine(playerIsHealing());
    }

    IEnumerator playerIsHealing()
    {
        playerUnit.Healing(5);
        playerHud.SetHp(playerUnit.CurrentHp);
        dialogueText.text = "You have healed the wounds you have sustained";
        yield return new WaitForSeconds(2f);

        State = BattleStates.EnemyTurn;
        StartCoroutine(EnemyTurn());
    }
    IEnumerator playerAttacking()
    {
        bool isDead = enemyUnit.RemoveHealth(playerUnit.Damage);
        dialogueText.text = "You land a shot successfully";
        yield return new WaitForSeconds(2f);
        enemyHud.SetHp(enemyUnit.CurrentHp);
        
        if (isDead)
        {
           State= BattleStates.Win;
            endBattle();
        }
        else
        {
            State = BattleStates.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

   

    IEnumerator EnemyTurn()
    {
        
        dialogueText.text = enemyUnit.unitName + " Is about to attack";
        yield return new WaitForSeconds(2f);

       
        dialogueText.text = enemyUnit.unitName + " has successfully landed and attack against you";
        yield return new WaitForSeconds(2f);
        bool isdead = playerUnit.RemoveHealth(enemyUnit.Damage);

        playerHud.SetHp(playerUnit.CurrentHp);
        yield return new WaitForSeconds(2f);

        if (isdead)
        {
            State = BattleStates.Lose;
            endBattle();
        }
        else
        {
            State = BattleStates.PlayerTurn;
            PlayerTurn();
        }
    }

    void endBattle()
    {
        if(State== BattleStates.Win)
        {
            dialogueText.text = "Your the winner of the fight";

        }
        else if(State == BattleStates.Lose)
        {
            dialogueText.text = "You saldy lose the fight";
        }
    }
}
