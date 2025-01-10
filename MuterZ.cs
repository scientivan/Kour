
using UnityEngine;

public class MuterZ : MonoBehaviour
{
    public float putaranZ;
    
    void Update()
    {
        transform.Rotate(0f, 0f, putaranZ);
    }
}
