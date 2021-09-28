using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControllerC2 : MonoBehaviour
{

    public GameObject Stepe4, StartBox;
    public bool Work = true;

    void Start()
    {
        StartBox = GameObject.Find("Machine Start");
        Stepe4.GetComponent<MoovingBox>().Spd = StartBox.GetComponent<StartingBox>().SpdBox;
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Controller");
        if (other.tag == "Step3")
        {
            if (Work == true)
            {
                Debug.Log("Lunch Ondestroy");
                Vector3 EtepePos = other.transform.position;
                other.GetComponent<MoovingBox>().DestroyHim();

                Instantiate(Stepe4, EtepePos, Quaternion.identity);
                //Destroy(other);
                Work = false;

                StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 4;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Work = true;
    }
}
