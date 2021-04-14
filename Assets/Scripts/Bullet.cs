using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    void Update()
    {
        Invoke("delMeth", 5);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect=Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
    public void delMeth()
    {
        Destroy(gameObject);
    }
}
