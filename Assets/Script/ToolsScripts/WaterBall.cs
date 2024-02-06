using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip clip;
    public AudioSource source;
    public Console console;
    
    void Start()
    {
        // Destroy(gameObject, 5);
    }
    
    void OnTriggerEnter(Collider collider)
    {
        var obj = collider.gameObject.GetComponent<Enemy>();
        if (obj != null)
        {
            obj.TakeDamage(1);
            console.AddLine(collider.name + " took damages: " + obj.health);
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(this, 1);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
