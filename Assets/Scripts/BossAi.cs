using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRate = 1f;
    public float bulletSpeed = 10f;
    public float minX = -50f;
    public float maxX = 50f;

    void Start()
    {
        minX = gameObject.transform.position.x - 50f;
        maxX = gameObject.transform.position.x + 50f;
        InvokeRepeating("SpawnBullet", 0f, spawnRate);
        
    }

    void SpawnBullet()
    {
        // Instantiate a new bullet at a random x position within the range [minX, maxX]
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        // Apply a downward force to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
    }
}
