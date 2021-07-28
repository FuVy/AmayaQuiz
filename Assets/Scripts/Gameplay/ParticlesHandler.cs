using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesHandler : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;
    
    public void StartEmission()
    {
        _particleSystem.Play();
    }
}
