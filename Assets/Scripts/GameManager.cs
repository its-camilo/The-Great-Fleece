using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get 
        {  
            if (instance == null)
            {
                Debug.LogError("GameManager is null");
            }
            return instance; 
        }
    }

    public bool HasCard 
    { 
        get;
        set;
    }

    public PlayableDirector introCutscene;

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            introCutscene.time = 60f;
            AudioManager.Instance.PlayMusic();
        }
    }
}
