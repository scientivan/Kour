using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TargetObject : MonoBehaviour
{
    public float health = 100f;
    
   
    public void TakeDamage(float Damage)
    {
        health -= Damage;
        Debug.Log(health);
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
