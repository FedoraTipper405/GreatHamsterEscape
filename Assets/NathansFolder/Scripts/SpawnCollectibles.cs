using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectibles : MonoBehaviour
{
    [SerializeField]
    List<GameObject> collectPrefabs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        int randChance = Random.Range(0, 3);
        int randCollect = Random.Range(0, collectPrefabs.Count);
        if (randChance == 0)
        {
            Instantiate(collectPrefabs[randCollect], transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
