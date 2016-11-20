using UnityEngine;
using System.Collections;

public class ButtonsFunction : MonoBehaviour {

    //Properties

    [SerializeField]
    private GameObject logo;
    [SerializeField]
    private GameObject firstScreen;
    [SerializeField]
    private GameObject filter;

    [Header("Menus")]

    [SerializeField]
    private GameObject[] menuScreens = new GameObject[2];
    [SerializeField]
    private GameObject[] optionsScreens = new GameObject[3];
    [SerializeField]
    private GameObject[] dialogBoxes = new GameObject[2];

    [Header("References")]

    [SerializeField]
    private Animator fade;

    //Unity functions

    void Start() //Setting first screen
    {
        logo.SetActive(false);
        firstScreen.SetActive(true);
        filter.SetActive(false);

        ActiveScreens(menuScreens, false);
        ActiveScreens(optionsScreens, false);
        ActiveScreens(dialogBoxes, false);

        fade.Play("Fade01");
    }

    void Update()
    {
        if (Input.anyKey && firstScreen.activeInHierarchy)
        {
            fade.Play("Fade02");

            firstScreen.SetActive(false);
            logo.SetActive(true);
            menuScreens[0].SetActive(true);
        }
    }

    //Class functions

    private void ActiveScreens(GameObject[] screens, bool state)
    {
        for (int i = 0; i < screens.Length; i++) screens[i].SetActive(state);
    }

    //Buttons functions - Main menu --------------------------------------------------

    public void Options()
    {
        menuScreens[0].SetActive(false);
        menuScreens[1].SetActive(true);
    }

    public void Credits()
    {
        LoadingManager.scene = 3; //Loads Credits scene
        LoadingManager.Loading();
    }

    //Buttons functions - Options

    public void ActiveOptions(int optionScreen)
    {
        menuScreens[1].SetActive(false); //Option menu is disable
        logo.SetActive(false);
        optionsScreens[optionScreen].SetActive(true); //Option screen is enable
    }

    public void BackToMenu()
    {
        menuScreens[1].SetActive(false);
        menuScreens[0].SetActive(true);
    }

    public void BackToOptions(int optionsScreen)
    {
        fade.Play("Fade02", -1, 0);

        optionsScreens[optionsScreen].SetActive(false); //Option screen is disable
        logo.SetActive(true);
        menuScreens[1].SetActive(true); //Options menu is enable
    }

    //Buttons function - Dialog boxes

    public void ActiveDialogBox(int dialogBox)
    {
        filter.SetActive(true);
        dialogBoxes[dialogBox].SetActive(true); //Enable dialog box
    }

    public void DesactiveDialogBox(int dialogBox)
    {
        filter.SetActive(false);
        dialogBoxes[dialogBox].SetActive(false); //Disable dialog box
    }

    public void Start_YES()
    {
        LoadingManager.scene = 2; //Loads Game scene
        LoadingManager.Loading();
    }

    public void Exit_YES()
    {
        Application.Quit();
    }
}