using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Button musicButton;
    public Sprite musicOn;
    public Sprite musicOff;

    Music music;
    // Start is called before the first frame update
    void Start()
    {
        music = FindObjectOfType<Music>(); // Cari di scene itu gameobject yang punya script music
        UpdateIcon();
    }

  

    // Update is called once per frame
   public void PauseSongs()
    {
        music.ToggleSound();
        UpdateIcon();
    }
    void UpdateIcon()
    {
        if(PlayerPrefs.GetInt("Muted",0) == 0)
        {
            AudioListener.volume = 1;
            musicButton.GetComponent<Image>().sprite = musicOn;
        }
        else
        {
            AudioListener.volume = 0;
            musicButton.GetComponent<Image>().sprite = musicOff;
        }
    }
}
