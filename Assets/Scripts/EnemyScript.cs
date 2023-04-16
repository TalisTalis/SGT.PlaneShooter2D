using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1f;
    public float health = 10f;

    public GameObject explosionPrefab;
    public Healthbar healthbar;

    float barSize = 1f;
    float damage = 0f;

    //public Transform gunPoint1;
    //public Transform gunPoint2;
    //public GameObject enemyBullet;

    void Start()
    {
        damage = barSize / health;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            DamageHealthbar();
            Destroy(other.gameObject);

            if (health <= 0)
            {
                Destroy(gameObject);
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, 0.9f);
            }
        }
    }

    void DamageHealthbar()
    {
        if (health > 0)
        {
            health -= 1f;
            barSize -= damage;
            healthbar.SetSize(barSize);
        }
    }
}
