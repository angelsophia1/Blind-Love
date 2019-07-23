using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Obstacles = new GameObject[2];
    private int obstacleIndex;
    // Start is called before the first frame update
    void Start()
    {
        obstacleIndex = 0;
        InvokeRepeating("ShowObstacles",1f,2f);
    }

    void ShowObstacles()
    {
        if (Obstacles[0].activeSelf)
        {
            Obstacles[0].SetActive(false);
            return;
        }else if (Obstacles[1].activeSelf)
        {
            Obstacles[1].SetActive(false);
            return;
        }
        switch (obstacleIndex)
        {
            case 0:
                Obstacles[0].SetActive(true);
                break;
            case 1:
                Obstacles[1].SetActive(true);
                break;
        }
        obstacleIndex++;
        if (obstacleIndex > 1)
        {
            obstacleIndex = 0;
        }
    }
    public void StopGame()
    {
        CancelInvoke("ShowObstacles");
        Obstacles[0].SetActive(false);
        Obstacles[1].SetActive(false);
    }
}
