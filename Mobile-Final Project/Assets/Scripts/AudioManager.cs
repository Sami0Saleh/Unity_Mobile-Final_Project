using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _fightAudio;
    [SerializeField]
    private AudioSource _backgroundAudio;
    public void RestartAudio()
    {
        _fightAudio.Stop();
        _backgroundAudio.Stop();
        _fightAudio.Play();
        _backgroundAudio.Play();
    }
}
