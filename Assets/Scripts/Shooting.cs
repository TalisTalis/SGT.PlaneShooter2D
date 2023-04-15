using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(playerBullet, spawnPoint1.position, Quaternion.identity);
            Instantiate(playerBullet, spawnPoint2.position, Quaternion.identity);
        }
    }
}
