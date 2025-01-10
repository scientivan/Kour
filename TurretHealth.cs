using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurretHealth : MonoBehaviour
{
    
    public int turretHealth;
    public Slider slider;
    public GameObject sliderEdges;
    public ParticleSystem burnEffect;
    public GameObject moncong;
    TurretAI turretAi;
    AudioSource explosionFx;
    bool exploded = false;
    private void Awake()
    {
        turretAi = GetComponent<TurretAI>();
    }
    private void Start()
    {
        explosionFx = GetComponent<AudioSource>();
        explosionFx.loop = false;
    }
    public void TurretHealthDecrease(int _turretHealth)
    {
        
        turretHealth -= _turretHealth;
        slider.value = turretHealth;
        if(turretHealth <= 0 && exploded == false)
        {
            explosionFx.Play();
            
            turretAi.laserLine.enabled = false;
            turretAi.enabled = false;
            sliderEdges.SetActive(false);
            burnEffect.Play();
            moncong.transform.rotation = Quaternion.Euler(60f, 0f, 0f);
            exploded = true;
        }
        Debug.Log(turretHealth);
    }

    
    

}
