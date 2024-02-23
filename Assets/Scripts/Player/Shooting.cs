using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Shooting : MonoBehaviour
{
   Camera cam;
   Vector2 mousePos;
   [SerializeField] Transform shoulder;
   [SerializeField] float shootDelay;
   [SerializeField] Transform gunBarrel;
   [SerializeField] GameObject bulletPrefab;
   [SerializeField] float bulletSpeed;
   Vector2 dir;
   Rigidbody2D rb;
   bool canShoot = true;
   void Start()
   {
       cam = Camera.main;
       rb = GetComponent<Rigidbody2D>();
   }
   void Update()
   {
       AimHandler();
       HandelShooting();
   }
   private void AimHandler()
   {
       mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
       dir = mousePos - (Vector2)shoulder.position;
       float rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
       shoulder.transform.rotation = Quaternion.Euler(0, 0, rotation);
   }
   private void Flip(bool flip)
   {
       if (flip)
       {
           transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
       }
       else
       {
           transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
       }
   }

   private void HandelShooting()
   {
       if (!canShoot) return;
       if (Input.GetMouseButton(0))
       {
           GameObject bullet = Instantiate(bulletPrefab, gunBarrel.transform.position, shoulder.transform.rotation);
           dir.Normalize();
           bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
           //CamShake.instants.ShakeCamera(4,0.05f);
           StartCoroutine("delayShooting");
       }
   }

   IEnumerator delayShooting()
   {
       canShoot = false;
       yield return new WaitForSeconds(shootDelay);
       canShoot = true;
   }
}