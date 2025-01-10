using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsScripts : MonoBehaviour
{
    public GameObject analogOnly;
    public GameObject settingsCanvas;
    public GameObject adjustmentCanvas;
    public GameObject pauseMenu;
    public GameObject analog;
    public GameObject shootingButton;
    public GameObject doubleSpeedButton;
    public GameObject crosshairGameObject;
    int sceneIndex;
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
  
    public void BackToMainMenu()
    {
        
        SceneManager.LoadScene(0); // memilih untuk kembali ke main menu yang indexnya adalah 0
        pauseMenu.SetActive(false);
        analog.SetActive(true);
       
        Time.timeScale = 1f;
    }
     public void BackToTheGame()
    {

        playerVision.enabled = true;
        pauseMenu.SetActive(false);
        analog.SetActive(true);
        shootingButton.SetActive(true);
        analogOnly.SetActive(true);
        doubleSpeedButton.SetActive(true);
        crosshairGameObject.SetActive(true);
        Time.timeScale = 1f;
        

        //SceneManager.LoadScene(sceneIndex - 1); // Memilih untuk kembali ke dalam game yang indexnya adalah 1
    }
    public void GoToAdjustmentScene()
    {
        adjustmentCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        shootingButton.SetActive(true);
        analogOnly.SetActive(true);
        doubleSpeedButton.SetActive(true);
        crosshairGameObject.SetActive(true);
    }
   public void BackToSettingsMenu() 
    {
        adjustmentCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
        shootingButton.SetActive(false);
        analogOnly.SetActive(false);
        doubleSpeedButton.SetActive(false);
        crosshairGameObject.SetActive(false);
    }

    
}
