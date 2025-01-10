using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelection : MonoBehaviour
{
    public int levelAt;
    public Button[] levelButtons;

    private void Start()
    {
        
        int levelAt = PlayerPrefs.GetInt("LevelAt", 39 ); // Cara kalok mo nambah level bisa ke unlock, harusnambahin level at ini
        Debug.Log("LevelAt: " + levelAt);
        for(int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 4 > levelAt)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
