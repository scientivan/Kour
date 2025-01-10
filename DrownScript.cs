using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownScript : MonoBehaviour
{
    public Vector3 currentPosition;
    public float naikTurunForce;
    bool diAtas = true;
    private void Awake()
    {
        currentPosition = transform.position;
    }
    private void Update()
    {
        if(transform.position.y < 5 && diAtas == false)
        {
            transform.Translate(0f, naikTurunForce * Time.deltaTime, 0f);
        }
        if(transform.position.y >= 5)
        {
            transform.Translate(0f, -naikTurunForce * Time.deltaTime, 0f);
            diAtas = true;
        }
       if(transform.position.y > -0.5f && diAtas == true)
        {
            transform.Translate(0f, -naikTurunForce * Time.deltaTime, 0f);
        }
        if(transform.position.y <= -0.5f)
        {
            transform.Translate(0f, naikTurunForce * Time.deltaTime, 0f);
            diAtas = false;
        }
       
       
    }
 

}
