using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Fx;

    void Start()
    {
        Fx.loop = false;
        Fx.playOnAwake = false;
        Constants.AUDIO_MANAGER = this;
    }

    public void PlayFx(AudioClip clip)
    {
        Fx.clip = clip;
        Fx.Play();
    }
}



