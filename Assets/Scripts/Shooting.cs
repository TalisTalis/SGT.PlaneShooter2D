using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float bulletSpawnTime = 1f;

    private void Start()
    {
        StartCoroutine(Shoot());
    }
    private void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Fire();
        //}
    }

    void Fire()
    {
        Instantiate(playerBullet, spawnPoint1.position, Quaternion.identity);
        Instantiate(playerBullet, spawnPoint2.position, Quaternion.identity);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
        }
    }
}
