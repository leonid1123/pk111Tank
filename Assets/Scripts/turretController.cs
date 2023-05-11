using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 camPos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookAt = camPos - transform.position;
        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
