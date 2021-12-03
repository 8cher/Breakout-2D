using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Auto_Destroy : MonoBehaviour
{
    private ParticleSystem particle;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (particle.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
