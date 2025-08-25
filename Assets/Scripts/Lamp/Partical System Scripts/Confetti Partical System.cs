using UnityEngine;

public class ConfettiParticalSystem : MonoBehaviour
{
    
    public ParticleSystem _Confetti_1_ParticleSystem;
    public ParticleSystem _Confetti_2_ParticleSystem;
    private void Start()
    {
        if (_Confetti_1_ParticleSystem == null )
        {
            Debug.Log($"Attach Partical System");
        }
    }

    // method activated in animation via an event that includes a pertical effect
    public void ActivationParticalConfettiSystem()
    {
        _Confetti_1_ParticleSystem.Play();
        _Confetti_2_ParticleSystem.Play();
    }
}
