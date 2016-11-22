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

    [SerializeField]
    private PlayerController[] players;

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

    void Start()
    {
        players = FindObjectsOfType<PlayerController>();
    }

    void Update()
    {
        if (isPaused)
        {
            foreach(PlayerController player in players)
            {
                //player.enabled = false;
            }
        }
        else
        {
            foreach(PlayerController player in players)
            {
                //player.enabled = true;
            }
        }
    }
}