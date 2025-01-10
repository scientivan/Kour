using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserScriptStage8 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 40 || SceneManager.GetActiveScene().buildIndex == 41)
        {
            SceneManager.LoadScene(41);
        }
       
    }
}
