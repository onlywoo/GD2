using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObstacleController : MonoBehaviour
{
    public GameObject firstObstacles;
    public GameObject secondObstacles;
    public GameObject thirdObstacles;

    public GameObject[] enemys;

    public Button roundStarter;
    public Button increaseFiringSpeed;
    public Button increasePlayerSpeed;

    public float num;

    void Start()
    {
        Button rS = roundStarter.GetComponent<Button>();
        rS.onClick.AddListener(GenerateObstacles);

        Button iFS = increaseFiringSpeed.GetComponent<Button>();
        iFS.onClick.AddListener(GenerateObstacles);

        Button iPS = increasePlayerSpeed.GetComponent<Button>();
        iPS.onClick.AddListener(GenerateObstacles);
    }

    void GenerateObstacles()
    {
        num = Random.Range(0, 4);
    }

    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemys.Length > 0)
        {
            if (num == 0)
            {
                firstObstacles.SetActive(false);
                secondObstacles.SetActive(false);
                thirdObstacles.SetActive(false);
            }

            if (num == 1)
            {
                firstObstacles.SetActive(true);
                secondObstacles.SetActive(false);
                thirdObstacles.SetActive(false);
            }

            if (num == 2)
            {
                firstObstacles.SetActive(false);
                secondObstacles.SetActive(true);
                thirdObstacles.SetActive(false);
            }

            if (num == 3)
            {
                firstObstacles.SetActive(false);
                secondObstacles.SetActive(false);
                thirdObstacles.SetActive(true);
            }
        }

        else
        {
            firstObstacles.SetActive(false);
            secondObstacles.SetActive(false);
            thirdObstacles.SetActive(false);
        }
    }
}
