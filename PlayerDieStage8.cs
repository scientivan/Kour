using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDieStage8 : MonoBehaviour
{
    public float restartDelay;
    /*public GameObject grappleGun;
    public PlayerVision playerVision;
    public RigidBodyPlayerMovement rigidBodyPlayerMovement;
    public Rigidbody rb;
    public GameObject movementCanvas;*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("Restart", restartDelay);
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

        // player.transform.position = new Vector3(-100f, 10f, 5f);

        //meteor.SetActive(false);
        //restartingMeteorSpawn = true;
    }
}
