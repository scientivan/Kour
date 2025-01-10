using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuterX : MonoBehaviour
{
    public float putaranX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(putaranX, 0f, 0f);
    }
}
