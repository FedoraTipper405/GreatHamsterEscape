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
        timeAlive += Time.deltaTime;
        if(timeOnScreen > timeAlive)
        {
            gameObject.transform.Translate(0,riseSpeed,0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
