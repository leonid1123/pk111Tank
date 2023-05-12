using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject fireSmoke;
    Vector2 lookAt;
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bul = Instantiate(bullet,fireSmoke.transform.position,transform.rotation);
            bul.GetComponent<Rigidbody2D>().velocity = lookAt.normalized*10;
            Destroy(bul, 2f);
        }
    }
    void FixedUpdate()
    {
        Vector3 camPos = cam.ScreenToWorldPoint(Input.mousePosition);
        lookAt = camPos - transform.position;
        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
