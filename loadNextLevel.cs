using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadNextLevel : MonoBehaviour
{

    int sceneIndex;
    int nextLevelIndex;
    [HideInInspector]
    public int prevIndex;
    void Update()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex > 4)
        {
             PlayerPrefs.SetInt("prevIndexLevel",sceneIndex);// Mengambil index scene diatas index 4(levelmenu,playmenu,completed,failed)
        }
        
        
    }

    
}
