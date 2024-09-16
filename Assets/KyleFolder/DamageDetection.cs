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
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            Debug.Log("Hit");
        }
    }

    void Update()
    {
        if (speed > 15)
        {
            if (rb.velocity.x <= speed * 0.75f)
            {
                TakeDamage.Invoke();
            }
        }
        speed = rb.velocity.x;
    }
}
