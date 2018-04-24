using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleClip  {



    AudioClip audiClip;


    public SingleClip(AudioClip  tmpClip)
    {

        audiClip = tmpClip;
    }

    AudioSource audioSource;


    public void Play(AudioSource tmpAudio)

    {
        audioSource = tmpAudio;

        audioSource.clip = audiClip;

        audioSource.Play();


    }


}
