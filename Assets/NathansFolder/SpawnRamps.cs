using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRamps : MonoBehaviour
{
    [SerializeField]
    List<GameObject> downRamps = new List<GameObject>();
    [SerializeField]
    List<GameObject> upRamps = new List<GameObject>();
    [SerializeField]
    GameObject firstPoint;
    GameObject pointToSpawnAt;
    bool instDownRamp = true;
    int trackPerGeneration = 500;
    // Start is called before the first frame update
    void Start()
    {
        pointToSpawnAt = firstPoint;
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
            int randomIndex = Random.Range(0,downRamps.Count);
            if (instDownRamp)
            {
              GameObject lastRamp = Instantiate(upRamps[randomIndex], pointToSpawnAt.transform.position, Quaternion.identity);
                pointToSpawnAt = lastRamp.transform.GetChild(0).transform.GetChild(0).gameObject;
                instDownRamp = !instDownRamp;
            }
            else
            {
                GameObject lastRamp = Instantiate(downRamps[randomIndex],pointToSpawnAt.transform.position,Quaternion.identity);
                pointToSpawnAt = lastRamp.transform.GetChild(0).transform.GetChild(0).gameObject;
                instDownRamp = !instDownRamp;
            }
        }
    }
}
