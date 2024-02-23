using BarthaSzabolcs.Tutorial_SpriteFlash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{
    public int health;
    Rigidbody2D rb;
    [SerializeField] SimpleFlash flashEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            flashEffect.Flash();
            Vector2 dir = (transform.position - collision.transform.position).normalized;
            rb.AddForce (dir*10,ForceMode2D.Impulse);
            health -= 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            flashEffect.Flash();
            Vector2 dir = (transform.position - collision.transform.position).normalized;
            rb.AddForce(dir * 10, ForceMode2D.Impulse);
            health -= 10;
            Destroy(collision.gameObject);
        }
    }
}
