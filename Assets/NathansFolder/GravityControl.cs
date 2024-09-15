using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public UnityEvent PlaySound;
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
            PlaySound.Invoke();
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
