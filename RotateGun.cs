using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public GrapplingHook grappling;
    public Transform playerBody;
    void Update()
    {
        if (!grappling.isGrappling())
        {
            return; // Kalok isgrappling false maka rotate gun gaada
        }
        else
        {

            transform.LookAt(grappling.GetGrapplePoint()); // Kalok isGrappling nya true, maka rotate gun sesuuai rotation grapplepoint
            
         }
    }
    private void LateUpdate()
    {
       
        if (!grappling.isGrappling())
        {
            return; // Kalok isgrappling false maka rotate gun gaada
        }
        else
        {
            playerBody.LookAt(grappling.GetGrapplePoint());

        }
    }
}
