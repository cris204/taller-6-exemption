using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    //Singleton

    private static PauseManager instance;
    public static PauseManager Instance
    {
        get
        {
            return instance;
        }
    }

    //Properties

    public bool isPaused = false;

    //Unity functions

    void Awake()
    {
        if (instance = null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}