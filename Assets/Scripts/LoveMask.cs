using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoveMask : MonoBehaviour
{
    public GameObject musicChoiceMenu,congratulationText;
    public GameObject[] countNumbers = new GameObject[4];
    private bool waterCompleted = false,musicedCompleted = false;
    private int numberOfGrassWatered, numberOfGrassMusiced, numberOfFlowerWatered, numberOfFlowerMusiced;
    private void Start()
    {
        waterCompleted = false;
        musicedCompleted = false;
        numberOfGrassWatered = 0;
        numberOfGrassMusiced = 0;
        numberOfFlowerWatered = 0;
        numberOfFlowerMusiced = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("River") && !waterCompleted)
        {
            if (LoveMovement.stateOfLove == LoveState.Light)
            {
                LoveMovement.stateOfLove = LoveState.Water;
                LoveMovement.ChangeParticleEffects();
            }
        }
        else if (collision.gameObject.CompareTag("Music"))
        {
            if (LoveMovement.stateOfLove == LoveState.Light && !musicedCompleted)
            {
                LoveMovement.stateOfLove = LoveState.Music;
                LoveMovement.ChangeParticleEffects();
                Time.timeScale = 0f;
                musicChoiceMenu.SetActive(true);
            }
        }else if (collision.gameObject.CompareTag("Grass"))
        {
            Grass grass = collision.GetComponent<Grass>();
            switch (LoveMovement.stateOfLove)
            {
                case LoveState.Water:
                    if (!grass.GetWatered())
                    {
                        if (numberOfGrassWatered<15)
                        {
                            grass.SetWatered();
                            numberOfGrassWatered++;
                            countNumbers[0].GetComponent<Text>().text = numberOfGrassWatered.ToString();
                        }                        
                    }
                    break;
                case LoveState.Music:
                    if (!grass.GetMusiced())
                    {
                        if (numberOfGrassMusiced < 15)
                        {
                            grass.SetMusiced();
                            numberOfGrassMusiced++;
                            countNumbers[2].GetComponent<Text>().text = numberOfGrassMusiced.ToString();
                        }
                    }
                    break;
            }
            CheckStatus();
        }
        else if (collision.gameObject.CompareTag("Flower"))
        {
            if (collision.GetComponent<Flower>())
            {
                Flower flower = collision.GetComponent<Flower>();
                switch (LoveMovement.stateOfLove)
                {
                    case LoveState.Water:
                        if (!flower.GetWatered())
                        {
                            if (numberOfFlowerWatered < 10)
                            {
                                flower.SetWatered();
                                numberOfFlowerWatered++;
                                countNumbers[1].GetComponent<Text>().text = numberOfFlowerWatered.ToString();
                            }
                        }
                        break;
                    case LoveState.Music:
                        if (!flower.GetMusiced())
                        {
                            if (numberOfFlowerMusiced < 10)
                            {
                                flower.SetMusiced();
                                numberOfFlowerMusiced++;
                                countNumbers[3].GetComponent<Text>().text = numberOfFlowerMusiced.ToString();
                            }
                        }
                        break;
                }
            }
            CheckStatus();
        }
    }
    private void CheckStatus()
    {
        switch (LoveMovement.stateOfLove)
        {
            case LoveState.Water:
                if (numberOfGrassWatered >14.5&& numberOfFlowerWatered > 9.5)
                {
                    LoveMovement.stateOfLove = LoveState.Light;
                    LoveMovement.ChangeParticleEffects();
                    waterCompleted = true;
                }
                break;
            case LoveState.Music:
                if (numberOfGrassMusiced > 14.5 && numberOfFlowerMusiced > 9.5)
                {
                    LoveMovement.stateOfLove = LoveState.Light;
                    LoveMovement.ChangeParticleEffects();
                    musicedCompleted = true;
                }
                break;
        }
        if (waterCompleted && musicedCompleted)
        {
            FindObjectOfType<GameManager>().StopGame();
            congratulationText.SetActive(true);
            StartCoroutine(WaitToNextScene());
        }
    }
    IEnumerator WaitToNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Credits");
    }
}
