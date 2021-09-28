using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControllerC5 : MonoBehaviour
{
    public GameObject Stepe1, StartBox;
    public bool Work = true;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Controller");
        if(other.tag == "Step0")
        {
            if(Work == true)
            {
                Debug.Log("Lunch Ondestroy");
                Vector3 EtepePos = other.transform.position;
                other.GetComponent<MoovingBox>().DestroyHim();

                Instantiate(Stepe1, EtepePos, Quaternion.identity);
                //Destroy(other);
                Work = false;
                StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 1;
            }
        }
       

    }
    public void OnTriggerExit(Collider other)
    {
        Work = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartBox = GameObject.Find("Machine Start");
        Stepe1.GetComponent<MoovingBox>().Spd = StartBox.GetComponent<StartingBox>().SpdBox;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
