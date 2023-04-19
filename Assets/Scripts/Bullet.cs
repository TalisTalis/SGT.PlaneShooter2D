using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
    }
}
