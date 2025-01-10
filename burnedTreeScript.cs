using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burnedTreeScript : MonoBehaviour
{
    public ParticleSystem burnedParticleSystem;
    private void OnParticleCollision(GameObject other)
    {
        burnedParticleSystem.Play();
    }
}
