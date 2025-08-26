using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletType _bulletType;
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _enemydamage = 10;
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
            var Enemy1 = collision.GetComponent<Enemy1>();
            if (Enemy1 != null)
            {
                Enemy1.PlayertoDamage(_enemydamage);
                Destroy(gameObject);
            }
        }
        if(_bulletType == BulletType.Enemybullet && collision.CompareTag("Player"))
        {
            var player = collision.GetComponentInParent<PlayerHealth>();
            if (player != null)
            {
                player.EnemytoPlayerDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
