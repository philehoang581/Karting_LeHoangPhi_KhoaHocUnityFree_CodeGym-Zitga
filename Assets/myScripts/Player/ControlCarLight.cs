using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCarLight : MonoBehaviour
{
    [HideInInspector]
    public bool brake;
    public CarLights carLights;
    public float speed;
    public Rigidbody carRigidbody;
    private void Start()
    {
        transform.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        speed= carRigidbody.velocity.magnitude; 

        // Brake Lights

        foreach (Light brakeLight in carLights.brakeLights)
        {
            if (brake || speed < 1.0f)
            {
                brakeLight.intensity = Mathf.MoveTowards(brakeLight.intensity, 8, 0.5f);
            }
            else
            {
                brakeLight.intensity = Mathf.MoveTowards(brakeLight.intensity, 0, 0.5f);

            }

            brakeLight.enabled = brakeLight.intensity == 0 ? false : true;
        }


        // Reverse Lights

        foreach (Light WLight in carLights.reverseLights)
        {
            if (speed > 2.0f)
            {
                WLight.intensity = Mathf.MoveTowards(WLight.intensity, 8, 0.5f);
            }
            else
            {
                WLight.intensity = Mathf.MoveTowards(WLight.intensity, 0, 0.5f);
            }
            WLight.enabled = WLight.intensity == 0 ? false : true;
        }
    }


    public void LightCar()
    {

    }

}
// Lights Setting ////////////////////////////////




[System.Serializable]
public class CarLights
{
    public Light[] brakeLights;
    public Light[] reverseLights;
}