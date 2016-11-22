using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	[SerializeField]
    private PlayerController playerController;

    [HeaderAttribute("Animators")]
    
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Animator fadeAnimator;

    //Unity functions

    void Start()
    {
        playerController.enabled = false;
        fadeAnimator.SetTrigger("isFadeIn");
        PlayIntroAnimation();
    }

    //Class functions

    private void PlayIntroAnimation()
    {
        playerAnimator.SetTrigger("isIntro");
    }

    public void DisableAnimator()
    {
        playerAnimator.enabled = false;
    }
    
    public void EnableController()
    {
        playerController.enabled = true;
    }

    private void Blink()
    {
        fadeAnimator.SetTrigger("isBlink");
    }
}