using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public int lastHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptryHeart;
    public UnityEvent NoMoreHealth;
    [SerializeField]
    GameObject playerObj;
    [SerializeField]
    GameObject[] healthStates = new GameObject[4];
    [SerializeField]
    GameObject hamsterSprite;
    void Start()
    {
        health = maxHealth;
        lastHealth = health;
    }

    private void Update()
    {
        //changes health sprite from full to empty depending on amount of health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptryHeart;
            }
        }
        if (lastHealth != health)
        {
            if (health == 3)
            {
                healthStates[0].gameObject.SetActive(true);
                healthStates[1].gameObject.SetActive(false);
                healthStates[2].gameObject.SetActive(false);
                healthStates[3].gameObject.SetActive(false);
            }
            if (health == 2)
            {
                healthStates[0].gameObject.SetActive(false);
                healthStates[1].gameObject.SetActive(true);
                healthStates[2].gameObject.SetActive(false);
                healthStates[3].gameObject.SetActive(false);
            }
            if (health == 1)
            {
                healthStates[0].gameObject.SetActive(false);
                healthStates[1].gameObject.SetActive(false);
                healthStates[2].gameObject.SetActive(true);
                healthStates[3].gameObject.SetActive(false);
            }
            if (health == 0)
            {
                healthStates[0].gameObject.SetActive(false);
                healthStates[1].gameObject.SetActive(false);
                healthStates[2].gameObject.SetActive(false);
                healthStates[3].gameObject.SetActive(true);
                hamsterSprite.SetActive(false);
            }
            lastHealth = health;
        }
        

    }
    //recieves from damage detection
    public void TakeDamage()
    {
        //decrease health
        health--;
        Debug.Log(health);
        //than if health is too low die and inform player death
        if (health <= 0)
        {
            //turns on blood particles
            playerObj.transform.GetChild(1).gameObject.SetActive(true);
            NoMoreHealth.Invoke();
            Debug.Log("Death");
        }
    }
}
