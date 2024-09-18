using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleValue : MonoBehaviour
{
    [SerializeField]
    float timeOnScreen;
    [SerializeField]
    float riseSpeed;
   public float timeAlive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //deletes floating text after certain amount of time alive
        timeAlive += Time.deltaTime;
        if(timeOnScreen > timeAlive)
        {
            //raises the text for visual effect
            gameObject.transform.Translate(0,riseSpeed,0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
