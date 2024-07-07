using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    public GameObject winCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag is "Player")
        {
            if (GameManager.Instance.HasCard)
            {
                winCutscene.SetActive(true);
            }

            else
            {
                Debug.Log("You must grab the key card");
            }
        }
    }
}
