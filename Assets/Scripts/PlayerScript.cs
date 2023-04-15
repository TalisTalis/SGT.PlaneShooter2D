using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float newXpos = transform.position.x + deltaX;
        float newYpos = transform.position.y + deltaY;
        transform.position = new Vector2(newXpos, newYpos);
    }
}
