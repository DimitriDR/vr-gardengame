using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : Tools
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 2;
        durability = 100;
        durabilityLoseByHit = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        var obj = collider.gameObject.GetComponent<Enemy>();
        if (obj != null)
        {
            obj.TakeDamage(1);
            console.AddLine(collider.name + " took damages: " + obj.health);
            if (audioHitSound != null)
                AudioSource.PlayClipAtPoint(audioHitSound, transform.position);
            Destroy(this, 1);
            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // var collider = other.collider;
        // var cube = collider.GetComponent<Cube>();
        // if (cube != null) 
        console.AddLine("Collision Enter" + other.collider.gameObject.name);

    }
    
    void OnCollisionStay(Collision collision)
    {
        console.AddLine("Collision Stay" + collision.gameObject.name);
    }
    
    void OnCollisionExit(Collision collision)
    {
        console.AddLine("Collision Exit" + collision.gameObject.name);
    }
    

    
}
