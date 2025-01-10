using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAimAssist : MonoBehaviour
{
    public TurretHealth Turrethealth;

    private void Update()
    {
        if (Turrethealth.turretHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
