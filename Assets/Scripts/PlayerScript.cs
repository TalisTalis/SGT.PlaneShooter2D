using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;

    public GameObject explosionPrefab;

    float minX;
    float maxX;
    float minY;
    float maxY;

    float offset = 0.8f;

    private void Start()
    {
        FindBoundaries();
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
        //Debug.Log(Input.GetAxis("Horizontal"));
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        float deltaY = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        float newXpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
        //float newYpos = transform.position.y + deltaY;
        transform.position = new Vector2(newXpos, newYpos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(gameObject);
        }
    }
}
