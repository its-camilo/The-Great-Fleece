using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    public AudioClip clipToPlay;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag is "Player")
        {
            AudioSource.PlayClipAtPoint(clipToPlay, Camera.main.transform.position);
        }
    }
}
