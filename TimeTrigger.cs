using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TimeTrigger : MonoBehaviour
{
    int satuDetik;
    public float currentTime = 30;
    public Text timeText;
    public GameObject textObject;
    int truefalse;
    // Start is called before the first frame update
    void Start()
    {
        timeText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (textObject.active == true)
        {
                currentTime -= 1 * Time.deltaTime;
                timeText.text = currentTime.ToString("0");

                if (currentTime <= 0)
                {
                    Debug.Log("You Lose");
                SceneManager.LoadScene(4);
                }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            textObject.SetActive(true);
        }
        
        
    }
}
