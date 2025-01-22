using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ParticleSystem particleSystem;

    public void PlayAudioClip()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void PlayParticleEffect()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}
