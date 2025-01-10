using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleBarScript : MonoBehaviour
{
    public Image _bar;
   
    public Text healthText;
    public float healthValue;
    
    void Update()
    {
        HealthChange();
    }
    void HealthChange()
    {
        float amount = (healthValue / 100f) * 180 / 360 * 2;
        _bar.fillAmount = amount;
       
    }
    public void TakeHealth(float _health)
    {
        healthValue = _health;
        healthText.text = _health.ToString("0");
    }

}
