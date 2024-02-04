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
        // Enregistrez la rotation initiale de l'arrosoir
        initialRotation = transform.rotation;
    }
    // Update is called once per frame

    private void Update()
    {
        // Obtenez la rotation actuelle de l'arrosoir
        Quaternion currentRotation = transform.rotation;

        // Calculez la rotation relative à la rotation initiale
        Quaternion relativeRotation = Quaternion.Inverse(initialRotation) * currentRotation;

        // Obtenez l'inclinaison en utilisant l'angle d'Euler de la rotation relative
        Vector3 tiltAngle = relativeRotation.eulerAngles;

        // Utilisez l'inclinaison pour simuler le versement de l'eau ou effectuer d'autres actions en fonction de l'angle
        // Par exemple, si tiltAngle.x est positif, cela signifie que l'arrosoir penche vers l'avant, vous pouvez simuler le versement de l'eau en conséquence.
        // console.AddLine("Tilt Angle: " + tiltAngle);
        
        if (130.0f > tiltAngle.z && tiltAngle.z > 30.0f)
        {
            console.AddLine("Water pouring");
        }
        
    }
}

