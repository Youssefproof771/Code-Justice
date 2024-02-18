using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine("DestroyCourotine");
    }
    IEnumerator DestroyCourotine()
    {
         
        yield return new WaitForSeconds(4);
        Destroy(gameObject); 
    }
}
