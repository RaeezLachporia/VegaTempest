using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandling : MonoBehaviour
{
    [SerializeField] private Transform pfCharacterBattle;

    private void Start()
    {
        SpawnCharacters(true);
        SpawnCharacters(false);
    }

    private void SpawnCharacters(bool isPlayable)
    {
        Vector3 characterPosition;
        if (isPlayable)
        {
            characterPosition = new Vector3(-8, 0);
        }
        else
        {
            characterPosition = new Vector3(8, 0);
        }
        Instantiate(pfCharacterBattle, characterPosition, Quaternion.identity);
        
    }
}
