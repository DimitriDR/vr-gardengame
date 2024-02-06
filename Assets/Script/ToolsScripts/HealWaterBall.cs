using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealWaterBall : MonoBehaviour
{
    // Start is called before the first frame update

    public Console console;
    public AudioClip clip;
    public AudioSource source;
    void Start()
    {
        //Destroy(gameObject, 2);
    }
    
    void OnCollisionEnter(Collider collider)
    {
        var obj = collider.gameObject.GetComponent<Garden>();
        if (obj != null)
        {
            obj.healGarden(1);
            console.AddLine(collider.name + " health : " + obj.GetLife());
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(this, 1);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
