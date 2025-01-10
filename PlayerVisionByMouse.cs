using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisionByMouse : MonoBehaviour
{
    public bool isLock;
    public float mouseSensi;
    float xRotation = 0f;
    public Transform playerBody;

    void Start()
    {
        if(isLock == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
      
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensi * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
