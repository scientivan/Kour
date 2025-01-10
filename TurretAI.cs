using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public float attackRange;
    public bool showRange;
    public Transform turretHead;
    private GameObject playerTarget;
    private float timer;
    public float shootCoolDown;
    public LineRenderer laserLine;
    
    public float timeToDestroy;
    public Transform muzzle;
    public GameObject bulletPrefabs;
    public GameObject Moncong;
    public float speed;
    
    // Start is called before the first frame update

   
    void Start()
    {
        InvokeRepeating("CheckForTarget", 0, 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTarget != null)
        {
            FollowTarget();
        }

        timer += Time.deltaTime;
        if(timer >= shootCoolDown)
        {
            if(playerTarget != null)
            {
                timer = 0;
                TurretShootingPlayer();
            }
        }
    }
    private void LateUpdate()
    {
        if (playerTarget != null)
        {

            Laser();
        }
    }
    private void CheckForTarget()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position,attackRange); // Colliders array buat ngecek object yang ada collidernya di range tersebut

        float distAway = Mathf.Infinity; // jangkauan seluruh dunia(Ga terlalu dong)

        for(int i = 0;i < colls.Length; i++) // Mengecek semua objek yang bercollider
        {
            if(colls[i].tag == "Body") //Object yang ada tag Playernya, Maka
            {
                float distance = Vector3.Distance(transform.position, colls[i].transform.position); // Hitung jarak dari turret ke player dan masukkan ke variabel distance

                if(distance < distAway) // jika jaraknya lebih kecil dari jangkauan seluruh dunia, Maka
                {
                    playerTarget = colls[i].gameObject; // Set gameobject di array collider itu yang tagnya player ke playerTarget
                    distAway = distance; // Gaterlalu dong fungsinya buat apa
                }
                
            }
        }
    }
    private void FollowTarget()
    {
        Vector3 targetDirection = playerTarget.transform.position - transform.position; // Menghitung jarak dari tower ke player dan memasukkan ke Vector3
        turretHead.forward = targetDirection * 2000f;
       
    }
    

    private void TurretShootingPlayer()
    {
        float distance = Vector3.Distance(transform.position, playerTarget.transform.position);
        Vector3 targetDirection = playerTarget.transform.position - Moncong.transform.position;
        if (distance < attackRange)
        {
            
            GameObject bulletGo =  Instantiate(bulletPrefabs, muzzle.transform.position, Quaternion.identity);
            
            Rigidbody rb = bulletGo.AddComponent<Rigidbody>();
            //bulletGo.transform.forward = targetDirection;
           
            rb.useGravity = false;
            
            rb.velocity = rb.transform.TransformDirection(targetDirection * speed);
            
            Destroy(bulletGo, timeToDestroy);
            
        }

    }
   
    void Laser()
    {
        float distance = Vector3.Distance(transform.position, playerTarget.transform.position);
        if (distance < attackRange)
        {
            laserLine.enabled = true;
            laserLine.SetPosition(0, turretHead.transform.position);

            laserLine.SetPosition(1, playerTarget.transform.position);
           
        }

        if (distance > attackRange)
        {
            laserLine.enabled = false;
        }


    }
    public void OnDrawGizmos()
    {
       if(showRange == true) 
       {
                Gizmos.color = Color.black; // Mewarnai Range yang ada didekat turret dengan warna Hitam
                Gizmos.DrawWireSphere(transform.position, attackRange);
       }
           
      // if(playerTarget != null)
        //{
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawLine(turretHead.transform.position, playerTarget.transform.position);
       // }
    
    }
}
