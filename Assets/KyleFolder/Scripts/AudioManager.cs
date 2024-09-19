using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource _musicSource;
    [SerializeField]
    AudioSource _soundSource;
    [SerializeField]
    AudioClip[] _clip;
    [SerializeField]
    AudioClip _music;

    private void Start()
    {
        _musicSource.clip = _music;
        _musicSource.Play();
    }

    public void Sounds()
    {
        AudioClip clip = _clip[Random.Range(0, _clip.Length)];
        _soundSource.PlayOneShot(clip);
    }
}
