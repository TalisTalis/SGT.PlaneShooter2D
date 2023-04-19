using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public TMP_Text cointCountText;

    int count = 0;

    private void Update()
    {
        if (count >= 9999)
        {
            count = 9999;
        }

        cointCountText.text = count.ToString();
    }

    public void AddCount()
    {
        count++;
    }
}
