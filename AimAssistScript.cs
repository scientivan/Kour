using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssistScript : MonoBehaviour
{
    public GameObject Turret;
    public TurretAI turretAi;
    public float lookSpeed;
    public float maxAngle; // Radius aim assistnya
    public float maxAngleReset;
    private Quaternion targetRotation, lookAt;
    [HideInInspector]
    public TurretHealth turrethealth;
    public GameObject Camera;
    public float aimAssistRadius;
    private void Update()
    {
        //Di jarak berapa aim assistnya bakal nyala
        float zDistance = Turret.transform.position.z + transform.position.z; // Mencari jarak di z antara player dengan turret
       
        if (EnemyInFieldOfView(gameObject) && turretAi.enabled == true && zDistance <= -aimAssistRadius) // Makin besar aimassistradiusnya makin deket aim assistnya(berkebalikan)
        {
            Vector3 direction = Turret.transform.position - transform.position; // Mencari rotasi dari player untuk menghadap ke turet 
                                                                                // dengan cara mengurangi posisi vektor 3 player dengan mengurangi vektor3 posisi turret
            targetRotation = Quaternion.LookRotation(direction); // Masukin hasil selisih rotasi ke variabel targetRotation
            lookAt = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * lookSpeed);
            transform.rotation = lookAt; // Ngeaplikasiin ke rotasinya player
        }
        else if (EnemyInFieldOfViewNoResetPoint(gameObject))
        {
            return;
        }
        else
        {
            targetRotation = Quaternion.Euler(0, 0, 0); // Kembalikan ke asal rotasinya
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, Time.deltaTime * lookSpeed);
        }
       
    }

    bool EnemyInFieldOfView(GameObject looker)
    {

        Vector3 targetDir = Turret.transform.position - looker.transform.position; // Mencari selisih rotasi x,y,z player dengan turret
        // gets the direction to the enemy.

        float angle = Vector3.Angle(targetDir, looker.transform.forward); // Mencari selisih rotasi xyz dengan bentuk nilai derajat(float)
        // gets the angle based on the direction.

        if (angle < maxAngle) // Kalok selisih rotasi kita sama turretnya(dalam derajat), ada di radius turretnya, maka
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool EnemyInFieldOfViewNoResetPoint(GameObject looker)
    {
        Vector3 targetDir = Turret.transform.position - looker.transform.position;
        float angle = Vector3.Angle(targetDir, looker.transform.forward);

        if (angle < maxAngleReset)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    /*public void Aimassist()
    {
        RaycastHit hitAim;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hitAim))
        {

            if (hitAim.transform.tag == "Turret")
            {
                GameObject HitAim = hitAim.transform.gameObject;
                turrethealth = HitAim.GetComponentInParent(typeof(TurretHealth)) as TurretHealth;
            }
        }
    }*/

    
}
