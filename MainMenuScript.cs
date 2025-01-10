using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript: MonoBehaviour
{
    
    public GameObject exitCanvas;
    int sceneIndex;
    public AudioSource sourceFx;
    
     void Start()
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
    public void ClickPlayButton() // BackToTheGame
    {
       
        SceneManager.LoadScene(sceneIndex + 1); // Memilih Play game yang indexnya adalah 1
        
    }
    public void ExitGame()
    {

        exitCanvas.SetActive(true);
    }
    public void Credits()
    {
        SceneManager.LoadScene(sceneIndex + 2);
        
    }
    public void ExitPanel()
    {
        exitCanvas.SetActive(false);
    }
    public void LeaveGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    


}
