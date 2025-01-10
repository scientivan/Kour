using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LantaiPanas : MonoBehaviour
{
    int damage;
    private int playerStay = 0;
    public int planeDamage;
    public  void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "Player")
        {
            playerStay += 1;
            Debug.Log(playerStay);
            damage = planeDamage * playerStay;
        }
    }
    public void GivenDamageFromHotPlane(int _health)
    {
        _health -= damage;
    }
}
