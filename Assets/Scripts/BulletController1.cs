using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController1 : MonoBehaviour
{
    [SerializeField]
    GameObject boom;
    Collider2D[] me;
    void Start()
    {
        me = gameObject.GetComponentsInParent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != me[0])
        {
            GameObject exp =  Instantiate(boom, transform.position, transform.rotation);
            Destroy(exp,0.7f);
            Destroy(gameObject);
        }
    }
}
