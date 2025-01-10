
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatteryHealthBar : MonoBehaviour
{
    public float restartDelay;
    public GameObject greenHealthBar;
    public GameObject yellowHealthBar;
    public GameObject redHealthBar;
    public bool isDamaged = false;

    private void Start()
    {
        greenHealthBar.SetActive(true);
      //  redHealthBar.SetActive(true);
        yellowHealthBar.SetActive(true);
    }
    void Update()
    {
        if(isDamaged == true)
        {
            Debug.Log("Testing Lancar");
            if(greenHealthBar.active == false && redHealthBar.active == true)
            {
                yellowHealthBar.SetActive(false);
            }
             if(yellowHealthBar.active == false) // Gaboleh pake else if
            {
                redHealthBar.SetActive(false);
              Invoke("Restart", restartDelay);
            }
            else
            {
                greenHealthBar.SetActive(false);
            }
            
            isDamaged = false;
        }
        
    }

    void Restart()
    {

        if (SceneManager.GetActiveScene().buildIndex == 40 || SceneManager.GetActiveScene().buildIndex == 41)
        {
            SceneManager.LoadScene(41);
        }
        if (SceneManager.GetActiveScene().buildIndex == 42)
        {
            SceneManager.LoadScene(42);
        }
        if (SceneManager.GetActiveScene().buildIndex == 43)
        {
            SceneManager.LoadScene(43);
        }
        if (SceneManager.GetActiveScene().buildIndex == 44)
        {
            SceneManager.LoadScene(44);
        }
        if (SceneManager.GetActiveScene().buildIndex == 45)
        {
            SceneManager.LoadScene(45);
        }


        /*if (SceneManager.GetActiveScene().buildIndex == 40 || SceneManager.GetActiveScene().buildIndex == 45)
        {
            SceneManager.LoadScene(45);
        }
        if (SceneManager.GetActiveScene().buildIndex == 41 || SceneManager.GetActiveScene().buildIndex == 46)
        {
            SceneManager.LoadScene(46);
        }
        if (SceneManager.GetActiveScene().buildIndex == 42 || SceneManager.GetActiveScene().buildIndex == 47)
        {
            SceneManager.LoadScene(47);
        }
        if (SceneManager.GetActiveScene().buildIndex == 43 || SceneManager.GetActiveScene().buildIndex == 48)
        {
            SceneManager.LoadScene(48);
        }
        if (SceneManager.GetActiveScene().buildIndex == 44 || SceneManager.GetActiveScene().buildIndex == 49)
        {
            SceneManager.LoadScene(49);
        }*/

    }

}


