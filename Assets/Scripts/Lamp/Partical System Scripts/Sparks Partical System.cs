using System;
using UnityEngine;

public class SparksParticalSystem : MonoBehaviour
{
    [SerializeField] public ParticleSystem _ParticleSystem;

    private void Start()
    {
        if (_ParticleSystem == null)
        {
            Debug.Log($"Attach Partical System");
        }
    }
    
    //a method activated in animation via an event that includes a pertical effect of lamp sparks
    public void ActivationParticalSystem()
    {
        _ParticleSystem.Play();
    }
}
