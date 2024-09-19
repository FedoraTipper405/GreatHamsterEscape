using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour
{
    public float lastGroundedHeight;
    public UnityEvent DeathByWire;
    public GameObject HamsterSprite;
    public GameObject[] Ball = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //detects collision with the wire pit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("In WIres");

            HamsterSprite.SetActive(false);
            Ball[0].SetActive(false);
            Ball[1].SetActive(false);
            Ball[2].SetActive(false);
            Ball[3].SetActive(true);
            
            //calls to player death
            DeathByWire.Invoke();
            //enables the smokey death effect
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    //checks if player is within the ground "area". sets last grounded height to assist the camera zoom
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) { }
        {
            lastGroundedHeight = this.gameObject.transform.position.y;
        }
        
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 3) { }
    //    {
    //        lastGroundedHeight = this.gameObject.transform.position.y;
    //    }
    //}
  
}
