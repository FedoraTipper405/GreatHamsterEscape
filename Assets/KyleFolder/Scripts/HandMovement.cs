using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandMovement : MonoBehaviour
{
    [SerializeField]
    Transform _player;
    [SerializeField]
    Vector3 _offset;
    public float _speedOfOwner;
    private float _playerFurthestDis;
    public UnityEvent _playOwnerSound;
    private bool _hasPlayed = false;

    void Start()
    {
        transform.position = _player.position + _offset;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
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
        transform.position = _player.position + _offset;
    }

    private void CheckCondition()
    {
        if (_player.transform.position.x > _playerFurthestDis)
        {
            _playerFurthestDis = _player.transform.position.x;
            CallSound();
            _hasPlayed = true;
            ResetHand();

            if (gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled)
            {
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            if (gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled == false)
            {
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
            MoveHand();
            _hasPlayed = false;
        }
    }

    public void CallSound()
    {
        if (_hasPlayed == false)
        {
            _playOwnerSound.Invoke();
        }
    }
    public void MoveHand()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speedOfOwner);
    }
}
