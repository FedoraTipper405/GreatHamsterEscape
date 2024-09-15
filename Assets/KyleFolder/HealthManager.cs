using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptryHeart;

    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
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

    public void TakeDamage()
    {
        health--;
        Debug.Log(health);
        if (health < 0)
        {
            Debug.Log("Death");
        }
    }
}
