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
        cameraObject.transform.position = new Vector3(playerObject.transform.position.x,playerObject.transform.position.y, -baseScreenSize);
        cameraObject.GetComponent<Camera>().orthographicSize = (playerObject.transform.position.y - playerObjectGroundCheck.lastGroundedHeight) * 1.25f+ baseScreenSize;
    }
}
