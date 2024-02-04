using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    public Text displayer;
    public List<string> lines;
    private Camera vrCamera;
    public float distanceCamera = 5.0f;

    public int limitNbTextDisplayed = 30;
    // Start is called before the first frame update
    
    void Start()
    {
        lines = new List<string>();
        vrCamera = Camera.main;
    }

    public void Flush()
    {
        lines.Clear();
    }
    
    public void AddLine(string line)
    {
        lines.Add(line);
        if (lines.Count > limitNbTextDisplayed)
        {
            lines.RemoveAt(0);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        string content = "";
        foreach (string line in lines)
        {
            content += line + "\n";
        }
        displayer.text = content;
        

        Vector3 cameraPosition = vrCamera.transform.position;
        // Calculez la position de la console à la distance souhaitée de la caméra
        Vector3 targetPosition = cameraPosition + vrCamera.transform.forward * distanceCamera;
        // Faites en sorte que le GameObject de la console regarde toujours la caméra du joueur
        //transform.LookAt(cameraPosition);
        transform.LookAt(transform.position + (transform.position - cameraPosition));

        // Mettez à jour la position de la console
        transform.position = targetPosition;
       
    }
}
