using Components;
using Leopotam.Ecs;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private EcsEntity _entity;

    public EcsEntity Entity
    {
        set => _entity = value;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            _entity.Replace(new Dead());
        }
    }
}