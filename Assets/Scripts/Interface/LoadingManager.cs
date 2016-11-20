using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class LoadingManager {

    //Properties

    public static int scene;

    private static int loading = 1;

    //Class functions

    public static void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }

    public static void Loading()
    {
        SceneManager.LoadScene(loading);
    }
}