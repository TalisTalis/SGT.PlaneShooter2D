using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1f;
    public float health = 10f;

    public GameObject explosionPrefab;
    public GameObject damageEffectPrefab;
    public GameObject coinPrefab;
    public Healthbar healthbar;

    public AudioSource audioSource;
    public AudioClip coinSound;
    public AudioClip damageSound;
    public AudioClip explosionSound;

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
            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position, 0.5f);
            //audioSource.PlayOneShot(damageSound, 0.5f);
            DamageHealthbar();
            Destroy(other.gameObject);
            GameObject damageEffect = Instantiate(damageEffectPrefab, other.transform.position, Quaternion.identity);
            Destroy(damageEffect.gameObject, 0.2f);

            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position, 0.3f);
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
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
