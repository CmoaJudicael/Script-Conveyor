using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControllerC4 : MonoBehaviour
{
    public GameObject Stepe2, StartBox;
    public bool Work = true;

    void Start()
    {
        StartBox = GameObject.Find("Machine Start");
        Stepe2.GetComponent<MoovingBox>().Spd = StartBox.GetComponent<StartingBox>().SpdBox;
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Controller");
        if (other.tag == "Step1")
        {
            if (Work == true)
            {
                Debug.Log("Lunch Ondestroy");
                Vector3 EtepePos = other.transform.position;
                other.GetComponent<MoovingBox>().DestroyHim();

                Instantiate(Stepe2, EtepePos, Quaternion.identity);
                //Destroy(other);
                Work = false;
                StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 2;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Work = true;
    }
}
