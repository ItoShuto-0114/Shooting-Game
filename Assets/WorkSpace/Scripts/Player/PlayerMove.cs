using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float _moveSpeed = 10;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private GameObject _BulletPrefab;
    [SerializeField] private float _BulletSpeed = 10;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 velocity = new Vector2(h, v).normalized;

        _rigidbody2D.velocity = velocity * _moveSpeed;
    }
    void Shoot()
    {
        SoundManager.Instance?.PlayShootSe();
        GameObject bullet = Instantiate(_BulletPrefab, _muzzle.position, Quaternion.identity);
        if (bullet.TryGetComponent(out Rigidbody2D rigidBody2D))
        {
            Vector2 velocity = _muzzle.up * _BulletSpeed; rigidBody2D.velocity = velocity;
        }
    }
}
