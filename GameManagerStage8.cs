using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerStage8 : MonoBehaviour
{
    public float TimeStartMeteor;
    public float TimeStartFreeze;
    float timeToStartRainingMeteor = 0f;
    public PlayerVisionByMouse playerVisionByMouse;
    public GameObject grappleGun;
    float time = 0f;
    bool panelIsActive = false;
    bool lastPanelIsActive = false;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public PlayerVision playerVision;
    public RigidBodyPlayerMovement rigidBodyPlayerMovement;
    public Rigidbody rb;
    public GameObject movementCanvas;
 
    bool panel4Finish = false;
    bool playerAttribute = false;
    bool meteorStartRaining = false;
    public GameObject meteorRainGroup;
    void Start()
    {
        movementCanvas.SetActive(false);
        rigidBodyPlayerMovement.enabled = false; //Matiin playermovement diawal biar gabisa gerak
        rb.useGravity = false; // Matiin gravitasi di awal awal
        grappleGun.SetActive(false); // awal awal matiin grapple gun sama pergerakan cameranya dulu(bukan matiin kameranya)
        playerVision.enabled = false;
       //playerVisionByMouse.enabled = false;
     //   player.SetActive(false);
       // secondaryCamera.SetActive(true);
        //canvas.SetActive(false);
    }

    void Update()
    {
        time += 1 * Time.deltaTime; // Menambah 1 detik tiap 1 detik
        if (time >= TimeStartFreeze && panelIsActive == false) // Memasuki scene, Waduh gunungnya meletus, kita harus kabur dari sini
        {
            Time.timeScale = 0; // Memfreeze layarnya
            panel1.SetActive(true); //Nyalain canvasnya
            Debug.Log(time); // Ngetes doang
            panelIsActive = true; // Biar ga looping lagi kalok detiknya udah lebih dari 3
        }
        if (panel4Finish == true && playerAttribute == false)
        {
            
            rigidBodyPlayerMovement.enabled = true;
            rb.useGravity = true;
            movementCanvas.SetActive(true);
            playerAttribute = true;
        }
        
     if(lastPanelIsActive == true)
        {
            timeToStartRainingMeteor += 1 * Time.deltaTime;
            if(timeToStartRainingMeteor >= TimeStartMeteor && meteorStartRaining == false)
            {
                meteorRainGroup.SetActive(true);
                meteorStartRaining = true;
            }
        }
    }

    public void GoToPanel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        
    }
    public void GoToPanel3()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
        grappleGun.SetActive(true);
    }
    public void GoToPanel4()
    {
        panel3.SetActive(false);
        panel4.SetActive(true);
    }
    public void GoToGameScene()
    {
        panel4.SetActive(false);
        panel4Finish = true;
        Time.timeScale = 1f;
        lastPanelIsActive = true;
    }

}
