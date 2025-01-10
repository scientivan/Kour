using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGame : MonoBehaviour
{
    
    int sceneIndex;
    public GameObject pauseMenu;
    public GameObject analog;
    public GameObject shootingButton;
    public GameObject analogOnly;
    public GameObject doubleSpeedButton;
    public GameObject crosshairGameObject;
    public PlayerVision playerVision;
    
    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex; // get Current sceneIndex

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void SettingsButtonInGame()
    {
        playerVision.enabled = false;
        Debug.Log(playerVision);
        pauseMenu.SetActive(true);
        analog.SetActive(false);
        shootingButton.SetActive(false);
        analogOnly.SetActive(false);
        doubleSpeedButton.SetActive(false);
        crosshairGameObject.SetActive(false);
        Time.timeScale = 0f;
    }
    
    
}
