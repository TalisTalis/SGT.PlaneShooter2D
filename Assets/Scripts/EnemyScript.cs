using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1f;

    public GameObject explosionPrefab;

    //public Transform gunPoint1;
    //public Transform gunPoint2;
    //public GameObject enemyBullet;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("PlayerBullet"))
        {            
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.9f);
        }
    }
}
