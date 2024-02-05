using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip clip;// fichier origine
    public AudioSource source;//là où on va être jouer le son
    public Console console;
    
    void Start()
    {
        // Destroy(gameObject, 5);
    }
    
    void OnTriggerEnter(Collider collider)
    {
        var cube = collider.gameObject.GetComponent<Enemy>();
        if (cube != null)
        {
            cube.TakeDamage(1);
            console.AddLine("Cube took damages: " + cube.health);
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(this, 1);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
