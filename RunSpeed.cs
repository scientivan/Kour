using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSpeed : MonoBehaviour
{
    int terakhir;

   
    public void ToggleSpeed()
    {
        
            if (PlayerPrefs.GetInt("Double", 0) == 0)
            {
                PlayerPrefs.SetInt("Double", 1);
                //Toggle RunSpeed Mati;
            }
            else
            {
                PlayerPrefs.SetInt("Double", 0);
                //Toggle RunSPEED nyala
            }
         
    }
    
}
