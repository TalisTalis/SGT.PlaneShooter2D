using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;

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
    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float newXpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
        //float newYpos = transform.position.y + deltaY;
        transform.position = new Vector2(newXpos, newYpos);
    }
}
