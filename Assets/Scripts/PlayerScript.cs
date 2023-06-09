using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    public float offset = 0.8f;
    public float health = 20f;

    public GameObject explosionPrefab;
    public GameObject damageEffectPrefab;
    public PlayerHealthbarScript playerHealthbar;
    public CoinCount cointCount;
    public GameController controller;
    public AudioSource audioSource;
    public AudioClip coinSound;
    public AudioClip damageSound;
    public AudioClip explosionSound;

    float minX;
    float maxX;
    float minY;
    float maxY;
    float barFillAmount = 1f;
    float damage = 0;

    private void Start()
    {
        FindBoundaries();
        damage = barFillAmount / health;
    }

    void FindBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + offset;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - offset;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + offset;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - offset;
    }
    void FixedUpdate()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
                newPos = new Vector2(Mathf.Clamp(newPos.x, minX, maxX), Mathf.Clamp(newPos.y, minY, maxY));
                transform.position = Vector2.Lerp(transform.position, newPos, speed * Time.deltaTime);
            }
        }
        else
        {
            float deltaX = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
            float deltaY = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
            float newXpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
            float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
            transform.position = new Vector2(newXpos, newYpos);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position, 0.5f);
            //audioSource.PlayOneShot(damageSound, 0.5f);
            Destroy(collision.gameObject);
            DamagePlayerHealthbar();

            GameObject damageEffect = Instantiate(damageEffectPrefab, collision.transform.position, Quaternion.identity);
            Destroy(damageEffect.gameObject, 0.2f);

            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, 2f);
                Destroy(gameObject);
                controller.Invoke("GameOver", 2f);
            }
        }

        if (collision.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coinSound, 1f);
            cointCount.AddCount();
            Destroy(collision.gameObject);
        }
    }

    void DamagePlayerHealthbar()
    {
        if (health > 0)
        {
            health -= 1;
            barFillAmount -= damage;
            playerHealthbar.SettAmount(barFillAmount);
        }
    }
}
