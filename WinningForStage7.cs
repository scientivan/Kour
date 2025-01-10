
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinningForStage7 : MonoBehaviour
{
    public TurretAI turretAI;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && turretAI.enabled == false) // Kalok turret dah hancur, maka 
        {
            
            SceneManager.LoadScene(3);
        }
    }
}
