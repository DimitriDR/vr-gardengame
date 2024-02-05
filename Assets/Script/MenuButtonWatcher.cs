using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[System.Serializable]
public class MenuButtonEvent : UnityEvent<bool>{}
public class MenuButtonWatcher : MonoBehaviour
{
    public MenuButtonEvent menuButtonPress;
    public Console console;
    private bool lastButtonState = false;
    private bool appState = false;
    
    private List<InputDevice> devicesWithMenuButton = new List<InputDevice>();
    
    private void InputDevices_deviceConnected(InputDevice device)
    {
        bool discardedValue;
        if (device.TryGetFeatureValue(CommonUsages.menuButton, out discardedValue))
        {
            devicesWithMenuButton.Add(device);
            console.AddLine("[" + this.name + "] add device " + device.name);
        }
    }
    
    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (devicesWithMenuButton.Contains(device))
        {
            devicesWithMenuButton.Remove(device);
            console.AddLine("[" + this.name + "] remove device " + device.name);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        devicesWithMenuButton = new List<InputDevice>();
        RegisterDevices();
    }

    private void OnEnable()
    {
        RegisterDevices();
    }

    private void RegisterDevices()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (InputDevice device in allDevices)
            InputDevices_deviceConnected(device);
        
        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    // Update is called once per frame
    void Update()
    {
        bool tempState = false;
        foreach (var device in devicesWithMenuButton)
        {
            bool primaryButtonState = false;
            tempState =  device.TryGetFeatureValue(CommonUsages.menuButton, out primaryButtonState) && primaryButtonState
                || tempState;
        }
        //console.AddLine("call menuButtonPress with "+tempState);
        if (tempState != lastButtonState)
        {
            appState = !appState;
            menuButtonPress.Invoke(tempState);
            console.AddLine("Menu button pressed" + tempState);

        }
        lastButtonState = tempState;
    }
}
