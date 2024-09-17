using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayerDies()
    {
        StartCoroutine(DeathDelay());
    }
    IEnumerator DeathDelay()
    {
        Debug.Log("Hand");
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        yield return new WaitForSeconds(5);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
