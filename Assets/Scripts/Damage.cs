using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    //reference of PlayerHealthScript
    //public (playerHealth script name) nameOfVariable;
     
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //nameOfVariable.TakeDamage(damage);
        }
    }
}
