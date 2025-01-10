using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [HideInInspector]
    public bool IsGrappling;
    RigidBodyPlayerMovement playerRB;
    public float damper;
    public float spring;
    public float massScale;
    private LineRenderer lineRenderer;
    public float hookDistance;
    Vector3 grapplePoint;
    public LayerMask Ground;
    public Transform gunTip, camera;
    public float maxDistance;
    private SpringJoint joint;
    public GameObject player;
    bool lineRendererActive = false;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerRB = FindObjectOfType<RigidBodyPlayerMovement>();
    }

    // public void OnMouseDown()
    // {
    //  StartGrapple();
    //}
    public void PointerDown() //Holding the fire button
    {
        StartGrapple();
       // playerRB.isGrappling = true;
    }
    public void PointerUp() // Releasing  the fire button
    {
        
        ReleaseGrapple();
        playerRB.isGrappling = false;
    }
    private void Update()
    {
        if ( playerRB.isJumping == true)
        {
            ReleaseGrapple();
            playerRB.isJumping = false;
            playerRB.isGrappling = false;
        }
       /* if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
            //playerRB.isGrappling = true;
        }
        if (Input.GetMouseButtonUp(0) || playerRB.isJumping == true)
        {
            ReleaseGrapple();
            
            playerRB.isJumping = false;
            playerRB.isGrappling = false;

        }*/

    }
   
    
    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, maxDistance, Ground))
        {
            grapplePoint = hit.point;
            joint = player.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.transform.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.5f;
            joint.minDistance = distanceFromPoint * 0.2f;

            joint.spring = spring;
            joint.damper = damper;
            joint.massScale = massScale;

            lineRenderer.positionCount = 2;
        }
    }
    void ReleaseGrapple()
    {
        lineRenderer.positionCount = 0;
        lineRendererActive = false;
        Destroy(joint);
    }
    void DrawRope()
    {
        if (joint == null)
        {
            return;
        }
        else
        {
            lineRenderer.SetPosition(0, gunTip.position);
            lineRenderer.SetPosition(1, grapplePoint);
            playerRB.isGrappling = true;

        }

    }

    public bool isGrappling()
    {
        return joint != null;
        
    }
    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}

