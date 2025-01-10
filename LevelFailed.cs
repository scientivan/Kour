using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailed : MonoBehaviour
{
    Winning win;
    int previousScene;
    //Ambil prevscenenya di winning

     void Awake()
    {
        win = FindObjectOfType<Winning>();
    }

    private void Update()
    {
        previousScene = win.prevScene;
    }

    public void Retry()
    {
        SceneManager.LoadScene(previousScene);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
