using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    HealthManager healthManager;
    float speed;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (speed > 15)
        {
            if (rb.velocity.x <= speed * 0.75f)
            {
                healthManager.TakeDamage(1);
            }
        }
        speed = rb.velocity.x;
    }
}
