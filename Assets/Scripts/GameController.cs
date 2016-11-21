using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour
{
    

    [SerializeField]
    private GameObject Ganador1;
    [SerializeField]
    private GameObject Perdedor1;

    [SerializeField]
    private GameObject Ganador2;
    [SerializeField]
    private GameObject Perdedor2;

    [SerializeField]
    private Collider final;


    // Use this for initialization
    void Start()
    {
        Ganador1.SetActive(false);
        Ganador2.SetActive(false);
        Perdedor1.SetActive(false);
        Perdedor2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {



    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jugador1")
        {
            Ganador1.SetActive(true);
            Perdedor2.SetActive(true);
        }
        else 
        {
            Perdedor1.SetActive(true);
            Ganador2.SetActive(true);
        }
        final.enabled = false;  

    }
}
