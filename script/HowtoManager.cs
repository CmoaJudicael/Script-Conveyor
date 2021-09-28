using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowtoManager : MonoBehaviour
{
    public GameObject Howto;
    bool FirstTrigger = true;
    private void OnTriggerEnter(Collider other)
    {
        if (FirstTrigger)
        {
            Howto.GetComponent<StartingBox>().HowToPlayRule();
            FirstTrigger = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        FirstTrigger = true;
    }
    private void Start()
    {
        Howto.GetComponent<StartingBox>().isHowTo = true;
        Howto.GetComponent<StartingBox>().NbBox = 1;
    }
}
