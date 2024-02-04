using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : Tools
{
    // [SerializeField] private GameObject childCylindre;
    // [SerializeField] private GameObject childCube;
    // Start is called before the first frame update    // [SerializeField] private GameObject childCylindre;
    // [SerializeField] private GameObject childCube;
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

    private void OnTriggerEnter(Collider other)
    {
        console.AddLine("Trigger Enter" + other.gameObject.name);
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
