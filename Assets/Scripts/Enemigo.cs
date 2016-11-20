using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour {


    [SerializeField]
    private Transform objetivo;

    private NavMeshAgent agent;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(objetivo.position);
	}
}
