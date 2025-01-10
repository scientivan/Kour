using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
     {
       
         if (other.tag != "AimAssist")
         {
             Destroy(gameObject, 0.05f);
         }
         if(other.tag == "Map")
         {
             Destroy(gameObject, 0.05f);
         }
     }

}
