using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnRamps : MonoBehaviour
{
    [SerializeField]
    List<GameObject> hillPrefabs = new List<GameObject>();
    int trackPerGeneration = 500;
    // Start is called before the first frame update
    void Start()
    {
        AddTrack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddTrack()
    {
        for(int i = 0; i < trackPerGeneration; i++)
        {
            int randomIndex = Random.Range(0,hillPrefabs.Count);

              GameObject lastRamp = Instantiate(hillPrefabs[randomIndex], new Vector2(i*50,-10), Quaternion.identity);

        }
    }
}
