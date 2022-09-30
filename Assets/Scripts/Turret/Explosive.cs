using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    //For throwable explosives (grenade)
    public GameObject explosionEffect;
    bool hasExploded;
    
    public float explosionRadius;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy" && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }
}
