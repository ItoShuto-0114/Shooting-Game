using UnityEngine;

public class minion : MonoBehaviour
{
    [SerializeField] Transform _Minionmuzzle;
    [SerializeField] Transform _Minionmuzzle2;
    [SerializeField] GameObject _BulletPrefab;
    [SerializeField] private float _BulletSpeed = 10;
    [SerializeField] private float _AttackInterval = 5;
    [SerializeField] float _LifeTime;
    float _timer = 0;
    void Start()
    {
        if (_LifeTime > 0f)
            Destroy(gameObject, _LifeTime);
    }
        void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _AttackInterval)
        {
            Shoot();
            _timer = 0;
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(_BulletPrefab, _Minionmuzzle.position, _Minionmuzzle.rotation);
        if (bullet.TryGetComponent(out Rigidbody2D rigidbody2D))
        {
            Vector2 velocity = _Minionmuzzle.up * _BulletSpeed; rigidbody2D.velocity = velocity;
        }
        GameObject bullet2 = Instantiate(_BulletPrefab, _Minionmuzzle2.position, _Minionmuzzle2.rotation);
        if (bullet2.TryGetComponent(out Rigidbody2D rigidbody2D2))
        {
            Vector2 velocity = _Minionmuzzle2.up * _BulletSpeed; rigidbody2D2.velocity = velocity;
        }
    }
}
