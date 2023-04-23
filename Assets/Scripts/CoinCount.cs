using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public TMP_Text cointCountText;
    public TMP_Text coinsText;

    int count = 0;

    private void Update()
    {
        if (count >= 9999)
        {
            count = 9999;
        }

        coinsText.text = cointCountText.text = count.ToString();
    }

    public void AddCount()
    {
        count++;
    }
}
