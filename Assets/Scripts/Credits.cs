using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    //Properties

    [SerializeField]
    private Animator fade;
    
    //Unity funcitons

    void Start()
    {
        fade.Play("Fade01", -1, 0);

        SequenceOne();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Skip();
        }
    }
    
    //Class functions

    private void SequenceOne()
    {
        Debug.Log("Sequence 1"); //TODO: Sequence 1

        SequenceTwo();
    }

    private void SequenceTwo()
    {
        Debug.Log("Sequence 2"); //TODO: Sequence 2
    }

    private void Skip()
    {
        fade.Play("Fade02", -1, 0);

        LoadingManager.scene = 0; //Loads Menu scene
        LoadingManager.Loading();
    }

    //Coroutines

    private IEnumerator ResponseTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
}