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
        //sets from SOStats
        damageTolerance = playerStats.damageTolerance;
        minDamageSpeed = playerStats.minDamageSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detect if player has been grabbed by hand
        if (collision.gameObject.tag == "Hand")
        {
            //communicates with player death
            _HamsterDeath.Invoke();
        }
    }

    void Update()
    {
        //detects if speed is high enough to take damage
        if (speed > minDamageSpeed)
        {
            //detects if the speed lost with one frame is high enough to count as damage
            if (rb.velocity.x <= speed * damageTolerance)
            {
                //communicates with health manager
                TakeDamage.Invoke();
            }
        }
        speed = rb.velocity.x;
    }
}
