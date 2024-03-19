using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private GameObject _grenadeVFX;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _damageAmount = 3f;

    private Rigidbody2D _rigidbody;
    private Vector2 _throwDirection;
    private Gun _gun;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddTorque(_moveSpeed);
    }

    public void Init(Gun gun, Vector2 grenadeSpawnPos, Vector2 mousePos)
    {
        _gun = gun;
        transform.position = grenadeSpawnPos;
        _throwDirection = (mousePos - grenadeSpawnPos).normalized;

    }
}
