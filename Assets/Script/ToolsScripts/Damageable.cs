using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public long health = 100;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(long damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);// fuir dans les fait
        }
    }
}
