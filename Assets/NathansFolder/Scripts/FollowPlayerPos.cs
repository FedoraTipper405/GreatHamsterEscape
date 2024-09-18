using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerPos : MonoBehaviour
{
    [SerializeField]
    GameObject cameraObject;
    [SerializeField]
    GameObject playerObject;
    GroundCheck playerObjectGroundCheck;
    [SerializeField]
    int baseScreenSize;
    // Start is called before the first frame update
    void Start()
    {
     playerObjectGroundCheck = playerObject.GetComponent<GroundCheck>();   
    }

    // Update is called once per frame
    void Update()
    {
        //follows player
        cameraObject.transform.position = new Vector3(playerObject.transform.position.x,playerObject.transform.position.y, -baseScreenSize);
        //changes size according to height. Ensures the track is always in frame below
        cameraObject.GetComponent<Camera>().orthographicSize = (playerObject.transform.position.y - playerObjectGroundCheck.lastGroundedHeight) + baseScreenSize;
    }
}
