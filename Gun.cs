using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public Text ammoText;
    public int ammo;
    
    public float damage;
    public float distance;
    public GameObject fpsCam;
    public GameObject gunFX;
    public GameObject impactEffect;
    public float DelayedSoundFx;
    private float nextTimeToFire = 0f;
    public float DelayedShootButton;
    public GameObject bulletPrefabs;
    public GameObject pistolMuzzle;
    public float bulletSpeed;
    public Animator shootingAnim;
   
    void Start()
    {
        ammoText.text = ammo.ToString("0");

    }


    public void Shoot()
    {

        if (Time.time >= nextTimeToFire && ammo > 0)
        {
            nextTimeToFire = Time.time + DelayedShootButton;
            muzzleFlash.Play();
            gunFX.SetActive(true);
            shootingAnim.SetBool("isShooting", true);
            Invoke("MatiinGunFx", DelayedSoundFx);
            
            ammo = ammo - 1;
            ammoText.text = ammo.ToString("0");

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, distance))
            {
                GameObject bulletGo = Instantiate(bulletPrefabs, pistolMuzzle.transform.position, Quaternion.identity);
                Rigidbody rb = bulletGo.AddComponent<Rigidbody>();

                rb.useGravity = false;
                rb.velocity = rb.transform.TransformDirection(fpsCam.transform.forward * bulletSpeed);

                Destroy(bulletGo, 10f);
            }

            if (hit.collider.tag != "Damage" || hit.collider.tag != "KnockBack")
            {
                GameObject Go = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(Go, 4f);
            }

           
        }


    }

   

    void MatiinGunFx()
    {
        gunFX.SetActive(false);
        shootingAnim.SetBool("isShooting", false);
    }
   
   
}