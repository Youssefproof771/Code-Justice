using BarthaSzabolcs.Tutorial_SpriteFlash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    Animator animator;
    [SerializeField] SimpleFlash flashEffect;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Allybullet")) 
        {
            flashEffect.Flash();
            Destroy(collision.gameObject);
            health -= 10;
            if (health <= 0)
            {
                StartCoroutine("EnemyDies");
            }
        }
    }
    IEnumerator EnemyDies()
    {
        animator.SetBool("Dies", true);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
