using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    public AudioClip clipToPlay;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = Camera.main.gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(clipToPlay);
            }
        }
    }
}
