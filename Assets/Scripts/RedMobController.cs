using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RedMobController : MonoBehaviour
{
    Rigidbody2D rb2d;
    GameObject player;
    float xErr;
    float yErr;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine("moveError");
    }
    void Update()
    {
        player = GameObject.Find("body");
    }
    private void FixedUpdate()
    {
        //Vector3 dir =   player.transform.position - transform.position;
        Vector3 playerPos = player.transform.position;
        
        Vector3 dir = new Vector3(playerPos.x+xErr,playerPos.y+yErr,playerPos.z) - transform.position;
        float rng = dir.magnitude;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        if (rng < 2f)
        {
            rb2d.velocity = Vector3.zero;
        }
        else
        {
            rb2d.velocity = dir.normalized * 0.9f;
        }
    }
    IEnumerator moveError()
    {
        yield return new WaitForSeconds(0.5f);
        xErr = Random.Range(-1f, 1f);
        yErr = Random.Range(-1f, 1f);
        StartCoroutine("moveError");
    }
}
