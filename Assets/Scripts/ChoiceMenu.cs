using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMenu : MonoBehaviour
{
    public GameObject mainCamera;
    public AudioClip[] sources = new AudioClip[2];
    public void PlayGuitar()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        FindObjectOfType<AudioSingleton>().gameObject.GetComponent<AudioSource>().clip = sources[0];
        FindObjectOfType<AudioSingleton>().gameObject.GetComponent<AudioSource>().Play();
    }
    public void PlayPiano()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        FindObjectOfType<AudioSingleton>().gameObject.GetComponent<AudioSource>().clip = sources[1];
        FindObjectOfType<AudioSingleton>().gameObject.GetComponent<AudioSource>().Play();
    }
}
