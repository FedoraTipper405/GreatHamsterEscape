using System.Collections;
using System.Collections.Generic;
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
        //checks if player is far enough to remove old track and if its not currently doing it to avoid bugs
        if (playerObj.transform.position.x > trackCount * 50 - trackPieceLength*tracksAwayFromGeneration && waitToGenerate == false)
        {
                ReUseTrack();
        }
        //starts placing track if there is track to use
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
        //randomizes what hill from list is moved to the front
        int rand = Random.Range(0, hillsToUse.Count);
        hillsToUse[rand].transform.position = new Vector2(trackCount * 50, trackHeight);
        //adds said track to the queue of used pieces
        hillsInPlay.Enqueue(hillsToUse[rand]);
        //removes from used
        hillsToUse.RemoveAt(rand);
        //stores amount of track used to inform what position the next used needs to be
        trackCount++;
    }
    public void ReUseTrack()
    {
        waitToGenerate = true;
        //removes one third of the track
        for (int i = 0; i < (int)(hillsInPlay.Count / 3); i++)
        {
            //adds to the usable list and removes from queue
            hillsToUse.Add(hillsInPlay.Peek());
            hillsInPlay.Dequeue();
        }
        waitToGenerate = true;
    }
    public void AddTrack()
    {
        //starts the level off with a set amount of track randomly
        for(int i = 0; i < trackPerGeneration; i++)
        {
            int randomIndex = Random.Range(0,hillPrefabs.Count);

              GameObject lastRamp = Instantiate(hillPrefabs[randomIndex], new Vector2(i*50,trackHeight), Quaternion.identity);
            hillsInPlay.Enqueue(lastRamp);
            trackCount++;
        }
    }
}
