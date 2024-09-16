using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandMovement : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Vector3 offset;
    public float speed;
    private float playerfurthestdis;
    public UnityEvent PlayOwnerSound;
    private bool _hasPlayed = false;

    void Start()
    {
        transform.position = player.position + offset;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void FixedUpdate()
    {
        if (Time.time > 4)
        {
            CheckCondition();
        }
    }

    public void ResetHand()
    {
        transform.position = player.position + offset;
    }

    private void CheckCondition()
    {
        if (player.transform.position.x > playerfurthestdis)
        {
            playerfurthestdis = player.transform.position.x;
            CallSound();
            _hasPlayed = true;
            ResetHand();

            if (GetComponent<SpriteRenderer>().enabled)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            if (GetComponent<SpriteRenderer>().enabled == false)
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            MoveHand();
            _hasPlayed = false;
        }
    }

    public void CallSound()
    {
        if (_hasPlayed == false)
        {
            PlayOwnerSound.Invoke();
        }
    }
    public void MoveHand()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }
}
