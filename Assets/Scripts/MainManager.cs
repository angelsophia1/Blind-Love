using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainManager : MonoBehaviour
{
    public GameObject returnButton;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!returnButton.activeSelf)
            {
                Time.timeScale = 0;
                returnButton.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                returnButton.SetActive(false);
            }
        }
    }
    public void returnToStart()
    {
        Time.timeScale = 1;
        FindObjectOfType<AudioSingleton>().gameObject.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("Start");
    }
}
