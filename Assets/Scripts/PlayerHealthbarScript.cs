using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbarScript : MonoBehaviour
{
    public Image bar;

    public void SettAmount(float amount)
    {
        bar.fillAmount = amount;
    }
}
