using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Music : MonoBehaviour
{
    bool isPlaying;
    AudioSource source;
    static Music instance = null;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        if(instance != null )
        {
            Destroy(gameObject);
            
        }
        else
        {
            instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }

  
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 2 && isPlaying == false ) // berenti
        {
           
            if(SceneManager.GetActiveScene().buildIndex > 2) // Selain Scene diatas 2, scene 35, stop lagunya(ganti ke lagu ingame)
            {
                source.Stop();
                isPlaying = true;
            }
            
        }
        else if (SceneManager.GetActiveScene().buildIndex < 3  && isPlaying == true || SceneManager.GetActiveScene().buildIndex == 35 ) 
        {
            source.Play();
            isPlaying = false;
        }

    }
    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
            //Suara nyala
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
            // Suara Mati
        }
    }

}
