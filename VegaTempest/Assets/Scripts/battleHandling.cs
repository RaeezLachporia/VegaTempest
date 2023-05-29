using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleHandling : MonoBehaviour
{
    [SerializeField] private Transform playerPrefab;
    [SerializeField] private Transform EnemyPrefab;

    private void Start()
    {
        spawnCharacters();
    }

    public void spawnCharacters()
    {
        
        Instantiate(playerPrefab, new Vector3(-50, 0), Quaternion.identity);
        Instantiate(EnemyPrefab, new Vector3(1376, 0), Quaternion.identity);
    }
}
