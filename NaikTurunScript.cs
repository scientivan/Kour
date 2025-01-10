using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaikTurunScript : MonoBehaviour
{
    
    public float naikTurunForce;
    bool diAtas = true;
    public float Yatas;
    public float Ybawah;
    void Update()
    {
        if (transform.position.y < Yatas && diAtas == false)
        {
            transform.Translate(0f, naikTurunForce * Time.deltaTime, 0f);
        }
        if (transform.position.y >= Yatas)
        {
            transform.Translate(0f, -naikTurunForce * Time.deltaTime, 0f);
            diAtas = true;
        }
        if (transform.position.y > Ybawah && diAtas == true)
        {
            transform.Translate(0f, -naikTurunForce * Time.deltaTime, 0f);
        }
        if (transform.position.y <= Ybawah)
        {
            transform.Translate(0f, naikTurunForce * Time.deltaTime, 0f);
            diAtas = false;
        }
    }
}
