using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("AudioManager is null");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public AudioSource music;

    public void PlayMusic()
    {
        music.Play();
    }
}
