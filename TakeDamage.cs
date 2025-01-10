using UnityEngine;
using UnityEngine.SceneManagement;
public class TakeDamage : MonoBehaviour
{
    
    float playerStayTimer = 0;
    public float floorDamage;
    public float Health;
    public Transform snowPrefabs;
    public float knockForce;
    CharacterController controller;
    CircleBarScript circleBar;
    float damage;
  
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        circleBar = FindObjectOfType<CircleBarScript>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Damage")
        {
            Health -= 10;
            circleBar.TakeHealth(Health);

            if (Health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
        if (other.tag == "KnockBack")
        {
            float dist =  Vector3.Distance(transform.position, snowPrefabs.transform.position);

                controller.SimpleMove(new Vector3(0, 0, dist * knockForce));

        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        


            if ( hit.collider.tag == "Lantai")
            {
            playerStayTimer += Time.deltaTime;
            damage = floorDamage * playerStayTimer;
            Health -= damage;

            circleBar.TakeHealth(Health);

            if (Health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
            Debug.Log(Health);
        }

        else
        {
            playerStayTimer = 0;
        }




    }



}
