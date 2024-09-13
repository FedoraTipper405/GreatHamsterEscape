using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rbHamster;
    [SerializeField]
    float verticalVelocity = -10;
    [SerializeField]
    float buttonDownAcceleration;
    [SerializeField]
    float buttonUpAcceleration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DownAcceleration();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            RegularAcceleration();
        }
        rbHamster.AddForce(new Vector2(0,verticalVelocity));
    }
    void DownAcceleration()
    {
        verticalVelocity = -buttonDownAcceleration;
    }
    void RegularAcceleration()
    {
        verticalVelocity = -buttonUpAcceleration;
    }
}
