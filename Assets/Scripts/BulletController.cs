using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    GameObject boom;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "body")
        {
            GameObject exp =  Instantiate(boom, transform.position, transform.rotation);
            Destroy(exp,0.7f);
            Destroy(gameObject);
        }
    }
}
