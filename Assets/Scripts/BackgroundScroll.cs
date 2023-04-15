using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public new Renderer renderer;
    public float speed = 0.1f;

    private void Update()
    {
        //Vector2 offset = renderer.material.mainTextureOffset;
        //offset += new Vector2(0, speed * Time.deltaTime);
        //renderer.material.mainTextureOffset = offset;

        renderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
