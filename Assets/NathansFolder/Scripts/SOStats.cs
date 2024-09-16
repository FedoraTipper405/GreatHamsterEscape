using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SOStats" , menuName = "SO/SOStats")]
public class SOStats : ScriptableObject
{
    [SerializeField]
    public float accelerationSpeed = 500;
    public float damageTolerance = 0.8f;
    public float minDamageSpeed = 15;
    public float highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
