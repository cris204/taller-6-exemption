using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	[SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private Instructions instructions;

    [HeaderAttribute("Animators")]
    
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Animator fadeAnimator;

    //Unity functions

    void Awake()
    {
        playerController.enabled = false;    
    }

    void Start()
    {
        fadeAnimator.SetTrigger("isFadeIn");
        PlayIntroAnimation();
    }

    //Class functions

    private void PlayIntroAnimation()
    {
        playerAnimator.SetTrigger("isIntro");
    }

    public void ActiveFirstInstructions()
    {
        instructions.FirstInstructions();
    }
    
    public void EnabledController()
    {
        playerController.enabled = true;
    }

    public void DisabledController()
    {
        playerController.enabled = false;
    }
    
    public void DisableAnimator()
    {
        playerAnimator.enabled = false;
    }

    private void Blink()
    {
        fadeAnimator.SetTrigger("isBlink");
    }
}