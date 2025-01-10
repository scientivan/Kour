using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ThanksForPlaying : MonoBehaviour
{
    public void ReturnToPlayMenu()
    {
        SceneManager.LoadScene(0);
    }

}
