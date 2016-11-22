using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
    
    //Properties

    [SerializeField]
    private Animator fade;
    
    //Unity functions

    void Start()
    {
        fade.Play("Fade01", -1, 0);
        LoadingManager.LoadScene();
        fade.Play("Fade02", -1, 0);
    }
}