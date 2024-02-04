using System;
using ToolsScripts;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MediumWaterGun : LongRangeTools
{
    private void Start()
    {
        console.AddLine("[" + this.name + "] start");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton8) && isSelected)
        {
            GameObject ammo = Instantiate(ammoPrefab, transform.position, transform.rotation);
            ammo.GetComponent<Rigidbody>().AddForce(transform.forward * force);
        }
    }
    
    /**
     * Called when the tool is grabbed, to know when user can shoot
     */
    public void Grabbed()
    {
        console.AddLine("[" + this.name + "] activate");
        isSelected = true;
    }
    
    /**
     * Called when the tool is released, to know when user can't shoot
     */
    public void Released()
    {
        console.AddLine("[" + this.name + "] deactivate");
        isSelected = false;
    }
}
