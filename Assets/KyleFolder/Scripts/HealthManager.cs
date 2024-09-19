using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptryHeart;
    public UnityEvent NoMoreHealth;
    [SerializeField]
    GameObject playerObj;
    void Start()
    {
        health = maxHealth;
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
