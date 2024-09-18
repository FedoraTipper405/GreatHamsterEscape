using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
    float movementDirection;
    [SerializeField]
    float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            movementDirection = -rotationSpeed;
        }
        else
        {
            movementDirection = rotationSpeed;
        }
        gameObject.transform.Rotate(0,0, movementDirection * gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude);
    }
}
