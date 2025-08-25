using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletType _bulletType;
    [SerializeField] private int _damage = 10;
    public enum BulletType
    {
        bullet,
        Enemybullet,
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);  // íeÇè¡Ç∑
        }
        if (_bulletType == BulletType.bullet && collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if(_bulletType == BulletType.Enemybullet && collision.CompareTag("Player"))
        {
            var player = collision.GetComponentInParent<PlayerHealth>();
            if (player != null)
            {
                player.Damage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
