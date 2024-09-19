using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class GravityControl : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rbHamster;
    float verticalVelocity;
    float buttonDownAcceleration;
    float buttonUpAcceleration;
    public UnityEvent PlaySound;
    bool downPressed;
    [SerializeField]
    SOStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        //sets from SOStats
        buttonDownAcceleration = playerStats.accelerationSpeed;
        buttonUpAcceleration = playerStats.regularSpeed;
        rbHamster.mass = playerStats.mass;
        rbHamster.drag = playerStats.drag;
        rbHamster.angularDrag = playerStats.drag;
    }
    private void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    downPressed = true;
        //}
        //else
        //{
        //    downPressed = false;
        //}
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        //if(downPressed)
        //{
        //    DownAcceleration();
        //}
        //else
        //{
        //    RegularAcceleration();
        //}
        rbHamster.AddForce(new Vector2(0,verticalVelocity));
    }
    //changes velocity added vertically according to button state
    public void DownAcceleration()
    {
        Debug.Log("Down");
        verticalVelocity = -buttonDownAcceleration;
    }
    public void RegularAcceleration()
    {
        Debug.Log("Up");
        verticalVelocity = -buttonUpAcceleration;
    }
    //Trust the process Sean
    public void MT()
    {

    }
}
