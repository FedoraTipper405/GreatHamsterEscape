using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float lastGroundedHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) { }
        {
            lastGroundedHeight = this.gameObject.transform.position.y;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        lastGroundedHeight = this.gameObject.transform.position.y;
    }
  
}
