using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Transform bar;

    private void Start()
    {

    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector2(size, 1f);
    }

}
