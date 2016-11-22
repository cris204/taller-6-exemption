using UnityEngine;
using System.Collections;

public class ButtonsFunctionPause : MonoBehaviour {

    //Properties

    [SerializeField]
    private GameObject pause;

    [Header("Pause menus/ Options screens")]

    [SerializeField]
    private GameObject[] pauseMenus = new GameObject[2];
    [SerializeField]
    private GameObject[] optionsScreens = new GameObject[3];
    [SerializeField]
    private GameObject exitDialogBox;

    //Unity functions

    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            PauseManager.Instance.isPaused = !PauseManager.Instance.isPaused;
        }

        if (PauseManager.Instance.isPaused)
        {
            pause.SetActive(true); //Pause menu is enable
        }
        else
        {
            pause.SetActive(false); //Pause menu is disable
        }
    }

    //Buttons functions - Pause --------------------------------------------------

    public void Resume()
    {
        PauseManager.Instance.isPaused = false;
    }

    public void Options()
    {
        pauseMenus[0].SetActive(false);
        pauseMenus[1].SetActive(true);
    }

    //Buttons function - Pause options

    public void ActiveOption (int optionScreen)
    {
        pauseMenus[1].SetActive(false);
        optionsScreens[optionScreen].SetActive(true); //Option screen is disable
    }

    public void BackToPause()
    {
        pauseMenus[1].SetActive(false);
        pauseMenus[0].SetActive(true);
    }

    public void BackToPauseOptions(int optionScreen)
    {
        optionsScreens[optionScreen].SetActive(false);
        pauseMenus[1].SetActive(true);
    }

    //Buttons function - Pause dialog boxes

    public void Exit_YES()
    {
        PauseManager.Instance.isPaused = false;

        LoadingManager.scene = 0; //Loads Main menu scene
        LoadingManager.Loading();
    }

    public void ExitDialogBox(bool state)
    {
        exitDialogBox.SetActive(state); //Dialog box is disable
    }
}