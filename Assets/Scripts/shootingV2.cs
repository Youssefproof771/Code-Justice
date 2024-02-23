using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingV2 : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject bulletPrefab;
    private bool canShoot = true;
    [SerializeField] float shootDelay = 0.4f;
    Vector3 rotation;
    [SerializeField] float bulletSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);
        HandelShooting();
        if (transform.position.x <= mousePos.x)
        {
            gun.transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y));
        }
        else
        {
            gun.transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), -Mathf.Abs(transform.localScale.y));
        }
    }
    private void HandelShooting()
    {
        if (!canShoot) return;
        if (Input.GetMouseButton(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
            rotation.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = rotation * bulletSpeed;
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
