using UnityEngine;

public class CollisionPintuCastle : MonoBehaviour
{
    public TurretAI turretDamage1;


    private void Update()
    {
        if(turretDamage1.enabled == false) // Jika script turretai mati, maka
        {
            gameObject.SetActive(false); // Matikan GameObject ini
        }
    }
}
