using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
   
    int sceneIndex;
    loadNextLevel nextLevel;
    [HideInInspector]
    public int prevScene;
    private void Start()
    {
        nextLevel = FindObjectOfType<loadNextLevel>(); // CARI GAMEOBJECT YANG MEMILIKI LOADNEXTLEVEL ATTACH DIDALAMYA
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        
    }
     void Update()
    {
        prevScene = PlayerPrefs.GetInt("prevIndexLevel"); // Mengambil index level yang sedang dimainin

        Debug.Log(prevScene); 
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (sceneIndex == 45)
        {
            SceneManager.LoadScene(46);
        }

        if (other.gameObject.tag == "Player")
        {
            // Debug.Log("You Win Bastard");
            SceneManager.LoadScene(3);
        }
       
        if (prevScene + 1  > PlayerPrefs.GetInt("LevelAt")) // prevscene + 1= sama dengan ngeload level yang indexnya +1
        {
            if(prevScene == 41)
            {
                PlayerPrefs.SetInt("LevelAt", prevScene - 1);
            }
            else
            {
                PlayerPrefs.SetInt("LevelAt", prevScene);
            }
           
           
          
        }
        
    }
    
    public void BackToMainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ContinueLevelButton()
    {
        if (prevScene == 40)
        {
            SceneManager.LoadScene(42);
        }
        else if (prevScene != 40)
        {
            SceneManager.LoadScene(prevScene + 1);
        }
       
       
    }
}
