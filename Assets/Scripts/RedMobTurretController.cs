using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class RedMobTurretController : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject firePoint;
    GameObject player;
    Vector3 dir;
    bool canFire = true;

    void Start()
    {
        
    }
    private void Update()
    {
        player = GameObject.Find("body");
    }
    void FixedUpdate()
    {

        dir = player.transform.position - transform.position;
        float rng = dir.magnitude;
        if (rng<5 && canFire)
        {
            canFire = false;
            StartCoroutine("MobFire");
        }
    } 
    IEnumerator MobFire()
    {
        GameObject fire = Instantiate(bullet, firePoint.transform.position, transform.rotation);
        fire.GetComponent<Rigidbody2D>().velocity = (dir.normalized * 5) + new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),0); 
        yield return new WaitForSeconds(1);
        canFire = true;
    }
}
