using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonsFunction : MonoBehaviour {

    //Properties

    [SerializeField]
    private GameObject logo;
    [SerializeField]
    private GameObject firstScreen;
    [SerializeField]
    private GameObject filter;
    [SerializeField]
    private Animator fade;

    [Header("Menus")]

    [SerializeField]
    private GameObject[] menuScreens = new GameObject[2];
    [SerializeField]
    private GameObject[] optionsScreens = new GameObject[3];
    [SerializeField]
    private GameObject[] dialogBoxes = new GameObject[2];

    [Header("EventSystem References")]

    [SerializeField]
    private EventSystem eventSystem = EventSystem.current;
    [SerializeField]
    private GameObject[] menuButtons = new GameObject[2];
    [SerializeField]
    private GameObject[] optionButtons = new GameObject[3];
    [SerializeField]
    private GameObject[] dialogBoxesButtons = new GameObject[2]; 

    //Unity functions

    void Awake()
    {
        eventSystem = FindObjectOfType<EventSystem>();    
    }
    
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

            eventSystem.SetSelectedGameObject(menuButtons[0]);
        }
    }

    //Class functions

    private void ActiveScreens(GameObject[] screens, bool state)
    {
        foreach(GameObject screen in screens)
        {
            screen.SetActive(state);
        }
    }

    private void ActiveButtons(Button[] buttons, bool state)
    {
        foreach(Button button in buttons)
        {
            button.enabled = state;
        }
    }

    //Buttons functions - Main menu --------------------------------------------------

    public void Options()
    {
        menuScreens[0].SetActive(false);
        menuScreens[1].SetActive(true);
        eventSystem.SetSelectedGameObject(menuButtons[1]);
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
        eventSystem.SetSelectedGameObject(optionButtons[optionScreen]);
    }

    public void BackToMenu()
    {
        menuScreens[1].SetActive(false);
        menuScreens[0].SetActive(true);
        eventSystem.SetSelectedGameObject(menuButtons[0]);
    }

    public void BackToOptions(int optionsScreen)
    {
        fade.Play("Fade02", -1, 0);

        optionsScreens[optionsScreen].SetActive(false); //Option screen is disable
        logo.SetActive(true);
        menuScreens[1].SetActive(true); //Options menu is enable
        eventSystem.SetSelectedGameObject(menuButtons[1]);
    }

    //Buttons function - Dialog boxes

    public void ActiveDialogBox(int dialogBox)
    {
        filter.SetActive(true);
        dialogBoxes[dialogBox].SetActive(true); //Enable dialog box

        Button[] buttons =  menuButtons[dialogBox].transform.parent.GetComponentsInChildren<Button>();
        ActiveButtons(buttons,false);

        eventSystem.SetSelectedGameObject(dialogBoxesButtons[dialogBox]);
    }

    public void DesactiveDialogBox(int dialogBox)
    {
        filter.SetActive(false);
        dialogBoxes[dialogBox].SetActive(false); //Disable dialog box

        Button[] buttons =  menuButtons[dialogBox].transform.parent.GetComponentsInChildren<Button>();
        ActiveButtons(buttons,true);

        eventSystem.SetSelectedGameObject(menuButtons[dialogBox]);
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