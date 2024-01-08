using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiterPart : MonoBehaviour
{
    [SerializeField] int attackValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Garden>() != null)
        {
            other.GetComponent<Garden>().GetHit(attackValue);
        }
    }
}
