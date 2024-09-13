using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(velocity > 15)
        {
            if (rb.velocity.x <= velocity * 0.75f)
            {
                Debug.Log("Hit");
            }
        } 
        velocity = rb.velocity.x; 
    }
}
