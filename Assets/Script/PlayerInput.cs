using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using UnityEngine.XR;

public class PlayerInput : MonoBehaviour
{

    private InputDevice targetDevice;

    float m_Acceleration;
    float m_Steering;

    bool m_FixedUpdateHappened;

    private bool accelerating = false;
    private bool breaking = false;
    private bool turningLeft = false;
    private bool turningRight = false;

    public float wheelDampening;
    
    public float Acceleration
    {
        get { return m_Acceleration; }
    }
    public float Steering
    {
        get { return m_Steering; }
    }

    void Update()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics =
            InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item  in devices)
        {
            /*Debug.Log(item.name + item.characteristics);/*#1#*/
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
        
        GetPlayerInput();

        if (accelerating)
        {
            m_Acceleration = 10f;
            wheelDampening = 500f;

        }
        else if (breaking)
        {
            m_Acceleration = -100f;
            wheelDampening = 500f;
        }
        else
        {
            m_Acceleration = 0f;
            wheelDampening = 500f;
        }


        if (turningLeft)
            m_Steering = -1f;
        else if (!turningLeft && turningRight)
            m_Steering = 1f;
        else
            m_Steering = 0f;


    }

    private void GetPlayerInput()
    {

        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float primaryButtonValue);
        if (primaryButtonValue > 0.1f)
        {
            Debug.Log("pressing primary button");
            accelerating = true;
        }
        if (primaryButtonValue < 0.1f)
        {
            Debug.Log("let go of accelerating");
            accelerating = false;
        }

        targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue);
        if (gripValue > 0.1f)
        {
            Debug.Log("trigger pressed " + gripValue);
            breaking = true;
        }
        if(gripValue < 0.1f)
        {
            breaking = false;
        }

        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        if (primary2DAxisValue != Vector2.left)
        {
            Debug.Log("primary axis" + primary2DAxisValue);
        }

        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool left);
        if (left)
        {
            turningLeft = true;
        }
        else
        {
            turningLeft = false;
        }

        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool right);
        if (right)
        {
            turningRight = true;
        }
        else
        {
            turningRight = false;
        }



    }
        
        /*if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            accelerating = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            accelerating = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
        {
            breaking = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
        {
            breaking = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
        {
            turningLeft = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
        {
            turningLeft = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
        {
            turningRight = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
        {
            turningRight = false;
        }*/
    }


