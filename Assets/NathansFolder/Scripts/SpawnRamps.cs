using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnRamps : MonoBehaviour
{
    [SerializeField]
    List<GameObject> hillPrefabs = new List<GameObject>();
    [SerializeField]
    GameObject playerObj;
    int trackPerGeneration = 50;
    public int trackCount = 0;
    float trackHeight = -10;
   public Queue<GameObject> hillsInPlay = new Queue<GameObject>();
   public List<GameObject> hillsToUse = new List<GameObject>();
    bool waitToGenerate = false;
    float trackPieceLength = 50;
    int tracksAwayFromGeneration = 20;
    // Start is called before the first frame update
    void Start()
    {
        AddTrack();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj.transform.position.x > trackCount * 50 - trackPieceLength*tracksAwayFromGeneration && waitToGenerate == false)
        {
            Debug.Log("Player x" + playerObj.transform.position.x + "TrackPoint " + (trackCount / 2) * 50);
                ReUseTrack();
    
        }
        if (hillsToUse.Count > 0)
        {
           PlaceUsedTracks();
        }
        else
        {
            waitToGenerate = false;
        }
    }
    public void PlaceUsedTracks()
    {
        int rand = Random.Range(0, hillsToUse.Count);
        hillsToUse[rand].transform.position = new Vector2(trackCount * 50, trackHeight);
        hillsInPlay.Enqueue(hillsToUse[rand]);
        hillsToUse.RemoveAt(rand);
        trackCount++;
    }
    public void ReUseTrack()
    {
        waitToGenerate = true;
        for (int i = 0; i < (int)(hillsInPlay.Count / 3); i++)
        {
            hillsToUse.Add(hillsInPlay.Peek());
            hillsInPlay.Dequeue();
        }
        waitToGenerate = true;
    }
    public void AddTrack()
    {
        for(int i = 0; i < trackPerGeneration; i++)
        {
            int randomIndex = Random.Range(0,hillPrefabs.Count);

              GameObject lastRamp = Instantiate(hillPrefabs[randomIndex], new Vector2(i*50,trackHeight), Quaternion.identity);
            hillsInPlay.Enqueue(lastRamp);
            trackCount++;
        }
    }
}
