
using UnityEngine;

public class SnowScript : MonoBehaviour
{

    AimAssistScript aimAssist;
    TurretHealth turretHealth;
    int damage = 10;

    
    private void Awake()
    {
        aimAssist = FindObjectOfType<AimAssistScript>();
        turretHealth = FindObjectOfType<TurretHealth>();

    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Turret")
        {
            Debug.Log("Turret Colliding");
            Destroy(gameObject);
            turretHealth.TurretHealthDecrease(damage);
        }
        

        else
        {
            Destroy(gameObject, 0.1f);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "AimAssist")
        {
            Destroy(gameObject);
        }

    }
}
