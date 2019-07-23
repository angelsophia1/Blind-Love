using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveMovement : MonoBehaviour
{
    private float speed = 10f;
    public static LoveState stateOfLove;
    public static GameObject[] particleEffects = new GameObject[3];
    public GameObject deathMenu;
    private bool immuneDamage = false;
    private int damageGot = 0;
    private Animator animator;
    private float countDown = 1f;
    private void Start()
    {
        animator = GetComponent<Animator>();
        stateOfLove = LoveState.Light;
        damageGot = 0;
        int i = 0;
        immuneDamage = false;
        foreach (Transform child in transform)
        {
            if (i<3)
            {
                particleEffects[i] = child.gameObject;
            }
            i++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition),speed*Time.deltaTime);
        if (immuneDamage)
        {
            countDown -= Time.deltaTime;
            if (countDown<0f)
            {
                countDown = 1f;
                immuneDamage = false;
            }
        }
    }
    public static void ChangeParticleEffects()
    {
        switch (stateOfLove)
        {
            case LoveState.Light:
                particleEffects[0].SetActive(true);
                particleEffects[1].SetActive(false);
                particleEffects[2].SetActive(false);
                break;
            case LoveState.Water:
                particleEffects[0].SetActive(false);
                particleEffects[1].SetActive(true);
                particleEffects[2].SetActive(false);
                break;
            case LoveState.Music:
                particleEffects[0].SetActive(false);
                particleEffects[1].SetActive(false);
                particleEffects[2].SetActive(true);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")&&!immuneDamage)
        {
            immuneDamage = true;
            damageGot++;
            animator.SetInteger("Damage", damageGot);
            if (damageGot>2)
            {
                Time.timeScale = 0f;
                deathMenu.SetActive(true);
            }
        }
    }
}
public enum LoveState
{
    Light, Water, Music
};

