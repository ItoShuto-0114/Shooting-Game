using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 3f;
    private Transform _player;
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        _player = playerObj.transform;
    }
    void Update()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * _moveSpeed * Time.deltaTime);
    }



}
