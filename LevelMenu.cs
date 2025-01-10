using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public GameObject canvasFirstPage;
    public GameObject canvasSecondPage;

    int sceneIndex;

 
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(sceneIndex - 1);
    }
    public void NextLevelMenuScene()
    {
        canvasFirstPage.SetActive(false);
        canvasSecondPage.SetActive(true);
    }
    public void Level1()
    {
        SceneManager.LoadScene(sceneIndex + 4); //Level 1 indexnya 4
    }
    public void Level2()
    {
        SceneManager.LoadScene(sceneIndex + 5);
    }
    public void Level3()
    {
        SceneManager.LoadScene(sceneIndex + 6);
    }
    public void Level4()
    {
        SceneManager.LoadScene(sceneIndex +  7);
    }
    public void Level5()
    {
        SceneManager.LoadScene(sceneIndex + 8);
    }

    public void Level6()
    {
        SceneManager.LoadScene(sceneIndex + 9);
    }
    public void Level7()
    {
        SceneManager.LoadScene(sceneIndex + 10);
    }
    public void Level8()
    {
        SceneManager.LoadScene(sceneIndex + 11);
    }
    public void Level9()
    {
        SceneManager.LoadScene(sceneIndex + 12);
    }
    public void Level10()
    {
        SceneManager.LoadScene(sceneIndex + 13);
    }
    public void Level11()
    {
        SceneManager.LoadScene(sceneIndex + 14);
    }
    public void Level12()
    {
        SceneManager.LoadScene(sceneIndex + 15);
    }
    public void Level13()
    {
        SceneManager.LoadScene(sceneIndex + 16);
    }
    public void Level14()
    {
        SceneManager.LoadScene(sceneIndex + 17);
    }
    public void Level15()
    {
        SceneManager.LoadScene(sceneIndex + 18);
    }
    public void Level16()
    {
        SceneManager.LoadScene(sceneIndex + 19);
    }
    public void Level17()
    {
        SceneManager.LoadScene(sceneIndex + 20);
    }
    public void Level18()
    {
        SceneManager.LoadScene(sceneIndex + 21);
    }
    public void Level19()
    {
        SceneManager.LoadScene(sceneIndex + 22);
    }
    public void Level20()
    {
        SceneManager.LoadScene(sceneIndex + 23);
    }
    public void Level21()
    {
        SceneManager.LoadScene(sceneIndex + 24);
    }
    public void Level22()
    {
        SceneManager.LoadScene(sceneIndex + 25);
    }
    public void Level23()
    {
        SceneManager.LoadScene(sceneIndex + 26);
    }
    public void Level24()
    {
        SceneManager.LoadScene(sceneIndex + 27);
    }
    public void Level25()
    {
        SceneManager.LoadScene(sceneIndex + 28);
    }
    public void Level26()
    {
        SceneManager.LoadScene(sceneIndex + 29);
    }
    public void Level27()
    {
        SceneManager.LoadScene(sceneIndex + 30);
    }
    public void Level28()
    {
        SceneManager.LoadScene(sceneIndex + 31);
    }
    public void Level29()
    {
        SceneManager.LoadScene(sceneIndex + 32);
    }
    public void Level30()
    {
        SceneManager.LoadScene(sceneIndex + 33);
    }

    
    public void Level31()
    {
        SceneManager.LoadScene(sceneIndex + 34);
    }
    public void Level32()
    {
        SceneManager.LoadScene(sceneIndex + 35);
    }
    public void Level33()
    {
        SceneManager.LoadScene(sceneIndex + 36);
    }
    public void Level34()
    {
        SceneManager.LoadScene(sceneIndex + 37);
    }
    public void Level35()
    {
        SceneManager.LoadScene(sceneIndex + 38);
    }
    public void Level36()
    {
        SceneManager.LoadScene(sceneIndex + 39);
    }
    public void Level37()
    {
        SceneManager.LoadScene(sceneIndex + 41);
    }
    public void Level38()
    {
        SceneManager.LoadScene(sceneIndex + 42);
    }
    public void Level39()
    {
        SceneManager.LoadScene(sceneIndex + 43);
    }
    public void Level40()
    {
        SceneManager.LoadScene(sceneIndex + 44);
    }
    
    public void BackToLevelMenu1()
    {
        canvasFirstPage.SetActive(true);
        canvasSecondPage.SetActive(false);
    }

}
