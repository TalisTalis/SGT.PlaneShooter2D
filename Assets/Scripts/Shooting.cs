using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject flash;
    public Transform[] spawnPoint;

    public float bulletSpawnTime = 1f;

    private void Start()
    {
        flash.SetActive(false);
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
        foreach (var item in spawnPoint)
        {
            Instantiate(bullet, item.position, Quaternion.identity);
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            flash.SetActive(false);
        }
    }
}
