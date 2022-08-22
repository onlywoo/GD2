using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;

    public float speed = 1f;
    public float enemyHealth;

    public Vector3 playerPos;

    void Update()
    {
        playerPos = GameObject.Find("Player").transform.position;

        float move = speed * Time.deltaTime;

        transform.position += (playerPos - transform.position).normalized * move;

        if (enemyHealth <= 0)
        {
            Destroy(enemy);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)") 
        {
            enemyHealth -= 1;
        }

        if (collision.gameObject.name == "Player")
        {
            Destroy(enemy);
        }
    }   
}
