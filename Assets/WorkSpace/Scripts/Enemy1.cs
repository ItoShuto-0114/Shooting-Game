using UnityEngine;
using UnityEngine.UI;
public class Enemy1 : MonoBehaviour
{
    [SerializeField] private Transform _Enemymuzzle;
    [SerializeField] private GameObject _BulletPrefab;
    [SerializeField] private float _BulletSpeed = 10;
    [SerializeField] private float _EnemyAttackInterval = 1;
    [SerializeField] private float _Enemy1Health = 100;
    [SerializeField] float _EnemycurrentHP = 100;
    [SerializeField] Image _image;
    float _timer = 0;
    void Start()
    {
        _EnemycurrentHP = _Enemy1Health;
    }
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
    public void PlayertoDamage(int _damage)
    {
        //0‚ð‰º‰ñ‚ç‚È‚¢‚æ‚¤‚É‚·‚é
        _EnemycurrentHP = Mathf.Max(_EnemycurrentHP - _damage, 0);
        //fillAmount‚É‘ã“ü
        _image.fillAmount = _EnemycurrentHP / _Enemy1Health;
        if (_EnemycurrentHP <= 0)
        {
            GameWin();
        }
    }
    void GameWin()
    {
        Debug.Log("Ÿ‚¿I");
    }
}
