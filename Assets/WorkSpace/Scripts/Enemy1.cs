using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private Transform _Enemymuzzle;
    [SerializeField] private GameObject _BulletPrefab;
    [SerializeField] private float _BulletSpeed = 10;
    [SerializeField] private float _EnemyAttackInterval = 1;
    float _timer = 0;
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _EnemyAttackInterval)
        {
            Shoot();
            _timer = 0;
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(_BulletPrefab, _Enemymuzzle.position, Quaternion.identity);
        if (bullet.TryGetComponent(out Rigidbody2D rigidBody2D))
        {
            Vector2 velocity = _Enemymuzzle.up * _BulletSpeed; rigidBody2D.velocity = velocity;
        }
    }
}
