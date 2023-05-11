using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField]
    float rotationSpeed = 1;
    [SerializeField]
    float speed = 1;
    float rot;
    float spd;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rot = Input.GetAxisRaw("Horizontal") * rotationSpeed;
        spd = Input.GetAxis("Vertical") * speed;
    }
    private void FixedUpdate()
    {
        rb2d.rotation -= rot;
        float x = 0 + spd * Mathf.Cos((rb2d.rotation + 90) * Mathf.Deg2Rad);
        float y = 0 + spd * Mathf.Sin((rb2d.rotation + 90) * Mathf.Deg2Rad);
        rb2d.velocity = new Vector2(x, y);
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(rb2d.velocity, 0.1f);
    }
}
