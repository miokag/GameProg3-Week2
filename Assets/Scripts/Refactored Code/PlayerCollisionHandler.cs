using UnityEngine;

[RequireComponent(typeof(PlayerEffects))]
public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayer;
    private PlayerEffects _playerEffects;

    private void Awake()
    {
        _playerEffects = GetComponent<PlayerEffects>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((wallLayer.value & (1 << hit.gameObject.layer)) > 0)
        {
            _playerEffects.PlayAudioClip();
            _playerEffects.PlayParticleEffect();
        }
    }
}