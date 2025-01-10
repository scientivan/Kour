using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPintuCastle2Turret : MonoBehaviour
{
    public TurretAI turretDamage1;
    public TurretAI turretDamage2;
    
    private void Update()
    {
        if(turretDamage1.enabled == false && turretDamage2.enabled == false)
        {
           gameObject.SetActive(false);
        }
    }
}
