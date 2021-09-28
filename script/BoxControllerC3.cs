using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControllerC3 : MonoBehaviour
{

    public GameObject Stepe3, StartBox;
    public bool Work = true;
    void Start()
    {
        StartBox = GameObject.Find("Machine Start");
        Stepe3.GetComponent<MoovingBox>().Spd = StartBox.GetComponent<StartingBox>().SpdBox;
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Controller");
        if (other.tag == "Step2")
        {
            if (Work == true)
            {
                Debug.Log("Lunch Ondestroy");
                Vector3 EtepePos = other.transform.position;
                other.GetComponent<MoovingBox>().DestroyHim();

                Instantiate(Stepe3, EtepePos, Quaternion.identity);
                //Destroy(other);
                Work = false;
                StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 3;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Work = true;
    }
}
