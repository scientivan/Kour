
using UnityEngine;

public class SnowKnockBack : MonoBehaviour
{
    /*  public void OnTriggerEnter(Collider other)
      {
          if(other.tag !="AimAssist" )
          {
              Destroy(gameObject, 0.05f);
          }


      }*/
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "Player")
        {
            Destroy(gameObject, 0.05f);
        }
    }

}
