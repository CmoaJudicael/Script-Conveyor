using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroWarningLight : MonoBehaviour
{
    public float ChangeTimeIntensity;
    int DeltaTime;
    public Light myLight;
    public bool AlarmeIsOn = false;
    public GameObject Gyro, Arrow;

    private void Start()
    {
        myLight = GetComponent<Light>();
        Arrow.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (AlarmeIsOn == false)
        {
            Arrow.SetActive(true);
            Debug.Log("light is on");
            AlarmeIsOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (AlarmeIsOn == true)
        {
            AlarmeIsOn = false;
            myLight.intensity = 0;
            DeltaTime = 0;
            Gyro.GetComponent<Renderer>().material.color = Color.white;
            Arrow.SetActive(false);
        }
    }

    private void Update()
    {
        if (AlarmeIsOn == true)
        {
            DeltaTime++;
            if (DeltaTime == ChangeTimeIntensity)
            {
                if (myLight.intensity == 1)
                {
                    Arrow.SetActive(true);
                    myLight.intensity = 0;
                    DeltaTime = 0;
                    Gyro.GetComponent<Renderer>().material.color = Color.white;
                }
                else
                {
                    Arrow.SetActive(false);
                    myLight.intensity = 1;
                    DeltaTime = 0;
                    Gyro.GetComponent<Renderer>().material.color = Color.red;

                }
            }
        }
    }
}
