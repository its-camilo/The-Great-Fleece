using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public GameObject gameOverCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            Color color = new Color(.6f, .1f, .1f, .3f);
            render.material.SetColor("_TintColor", color);
            StartCoroutine(AlertRoutine());
        }
    }

    IEnumerator AlertRoutine()
    {
        yield return new WaitForSeconds(.5f);
        gameOverCutscene.SetActive(true);
    }
}


