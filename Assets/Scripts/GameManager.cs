using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] enemys;
    public GameObject canvas;
    public GameObject player;
    public GameObject[] playerDeath;
    public GameObject upgrades;

    public int waveAmount;

    public Button roundStarter;
    public Button increaseFiringSpeed;
    public Button increasePlayerSpeed;

    void Start()
    {
        Button rS = roundStarter.GetComponent<Button>();
        rS.onClick.AddListener(SpawnEnemies);

        Button iFS = increaseFiringSpeed.GetComponent<Button>();
        iFS.onClick.AddListener(SpawnEnemies);

        Button iPS = increasePlayerSpeed.GetComponent<Button>();
        iPS.onClick.AddListener(SpawnEnemies);
    }

    void SpawnEnemies()
    {
        canvas.SetActive(false);
        player.SetActive(true);
        player.transform.position = new Vector2(-7, 0);
        upgrades.SetActive(true);

        waveAmount += Random.Range(5, 10);

        for (int x = 0; x < waveAmount; x++)
        {
            if (x >= ((waveAmount/3) *2))
            {
                var spawnedEnemy = Instantiate(enemy, new Vector3(7, 4, -1), Quaternion.identity);
                spawnedEnemy.name = $"Enemy";
            }
            else if (x >= waveAmount/3)
            {
                var spawnedEnemy = Instantiate(enemy, new Vector3(7, -4, -1), Quaternion.identity);
                spawnedEnemy.name = $"Enemy";
            }
            else
            {
                var spawnedEnemy = Instantiate(enemy, new Vector3(7, 0, -1), Quaternion.identity);
                spawnedEnemy.name = $"Enemy";
            }
        }
    }

    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        playerDeath = GameObject.FindGameObjectsWithTag("Player");

        if (enemys.Length == 0)
        {
            canvas.SetActive(true);
            player.SetActive(false);
        }
        
        if (playerDeath.Length == 0)
        {
            canvas.SetActive(true);

            for (int i = 0; i < enemys.Length; i++)
            {
                Destroy(enemys[i].gameObject);
            }
        }    
    }
}
