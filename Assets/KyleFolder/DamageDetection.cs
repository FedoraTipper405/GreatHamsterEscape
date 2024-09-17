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
    [SerializeField]
    SOStats playerStats;
    float damageTolerance;
    float minDamageSpeed;
    void Start()
    {
        damageTolerance = playerStats.damageTolerance;
        minDamageSpeed = playerStats.minDamageSpeed;
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
