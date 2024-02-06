using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterCanController : MonoBehaviour
{ 
    XRGrabInteractable xrGrabInteractable;
    
    private Quaternion initialRotation;
    public Console console;
    public GameObject waterBall;
    
    // Start is called before the first frame update
    private void Start()
    {
        initialRotation = transform.rotation;
    }
    // Update is called once per frame

    /**
     * Using the rotation of the water can to detect if the water is pouring
     */
    private void Update()
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion relativeRotation = Quaternion.Inverse(initialRotation) * currentRotation;
        Vector3 tiltAngle = relativeRotation.eulerAngles;
        
        if (130.0f > tiltAngle.z && tiltAngle.z > 30.0f) // not clean but it works approximately
        {
            var randomPos = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
            Instantiate(waterBall, randomPos, transform.rotation);
            console.AddLine("Water pouring");
        }
        
    }
}

