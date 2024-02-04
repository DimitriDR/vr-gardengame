using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    // Start is called before the first frame update
    AudioClip clip;// fichier origine
    AudioSource source;//là où on va être jouer le son
    public Console console;
    
    void Start()
    {
        // Destroy(gameObject, 5);
    }
    
    void OnTriggerEnter(Collider collider)
    {
        var cube = collider.gameObject.GetComponent<Damageable>();
        if (cube != null)
        {
            console.AddLine("Cube took damages");
            cube.TakeDamage(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
