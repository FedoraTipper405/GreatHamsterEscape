using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageDetection : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    float speed;
    public UnityEvent TakeDamage;
    public UnityEvent _HamsterDeath;
    [SerializeField]
    SOStats playerStats;
    float damageTolerance;
    float minDamageSpeed;
    void Start()
    {
        damageTolerance = playerStats.damageTolerance;
        minDamageSpeed = playerStats.minDamageSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            _HamsterDeath.Invoke();
        }
    }

    void Update()
    {
        if (speed > minDamageSpeed)
        {
            if (rb.velocity.x <= speed * damageTolerance)
            {
                TakeDamage.Invoke();
            }
        }
        speed = rb.velocity.x;
    }
}
