using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    bool BoxOnTheFloor = false, FirstTouch = false ;
    public int OnTimer, NbBox;
    public GameObject StartBox, C1, C2;
    public List<GameObject> BoxTomber = new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {
        if (NbBox> 0)
        {
            for (int i = 0; i < NbBox; i++)
            {
                if (other.gameObject == BoxTomber[i])
                {
                    FirstTouch = false;
                }
                else
                {
                    FirstTouch = true;
                }
            }
        }
        else if (NbBox == 0)
        {
            FirstTouch = true;
        }
        if (FirstTouch)
        {
            if (other.gameObject.tag == "Step0" || other.gameObject.tag == "Step1" || other.gameObject.tag == "Step2" || other.gameObject.tag == "Step3" || other.gameObject.tag == "Step4" || other.gameObject.tag == "Step5")
            {
                other.gameObject.GetComponent<MoovingBox>().IsMooving = false;
                BoxTomber.Add(other.gameObject);
                NbBox++;
                StartBox.GetComponent<StartingBox>().NbBoxTomber++;
                StartBox.GetComponent<StartingBox>().NbInstantiateBox--;
                if (other.gameObject == C1.GetComponent<ChariotController1>().BoxTemp.gameObject)
                {
                    if (C1.GetComponent<ChariotController1>().EtapeTr == 2)
                    {
                        Debug.Log("une boite est tombé durant le transfert");
                        C1.GetComponent<ChariotController1>().EtapeTr++;
                    }
                }
                else if (other.gameObject == C2.GetComponent<ChariotController2>().BoxTemp.gameObject)
                {
                    if (C2.GetComponent<ChariotController2>().EtapeTr == 2)
                    {
                        Debug.Log("une boite est tombé durant le transfert");
                        C2.GetComponent<ChariotController2>().EtapeTr++;
                    }
                }
            }
            FirstTouch = false;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (NbBox>0)
        {
            BoxOnTheFloor = true;
        }
        else if (NbBox == 0)
        {
            BoxOnTheFloor = false;
        }
        if (BoxOnTheFloor == true)
        {
            OnTimer++;
            if (OnTimer == 10)
            {
                OnTimer = 0;
                GameObject Temp = BoxTomber[0];
                BoxTomber.Remove(Temp);
                Destroy(Temp);
                NbBox--;
            }
        }
    }
}
