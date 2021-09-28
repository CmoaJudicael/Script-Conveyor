using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotController1 : MonoBehaviour
{
    public List<GameObject> WayPointPos = new List<GameObject>();
    public List<GameObject> WayPointT = new List<GameObject>();
    public int ChariotPos = 1, ChariotTr = 1, EtapeTr = 1;
    public float Speed = 1f, SpeedTransfert = 1;
    public bool IsMoving = false, IsTransfert = false;
    public GameObject BoxTemp, SetParentClone, BrasArt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Step1")
        {
            BoxTemp = other.gameObject;
            BoxTemp.GetComponent<MoovingBox>().Spd = 0.2f;

        }
        else if (other.tag == "Step3")
        {
            BoxTemp = other.gameObject;
            BoxTemp.GetComponent<MoovingBox>().Spd = 0.2f;
        }
        else if (other.tag == "Step5")
        {
            BoxTemp = other.gameObject;
            BoxTemp.GetComponent<MoovingBox>().Spd = 0.2f;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Step1")
        {
            BoxTemp = other.gameObject;
            BoxTemp.GetComponent<MoovingBox>().IsMooving = false;
            BoxTemp.transform.SetParent(this.transform);
            if (EtapeTr == 1)
            {
                IsTransfert = true;
                ChariotTr = 1;
            }
            else if (EtapeTr == 2)
            {
                BoxTemp.transform.SetParent(SetParentClone.transform);
                BoxTemp.GetComponent<MoovingBox>().ChoixDir = 1;
                BoxTemp.GetComponent<MoovingBox>().Spd = 0.03f;
                BoxTemp.GetComponent<MoovingBox>().IsMooving = true;
                EtapeTr = 3;
            }
        }
        else if (other.tag == "Step3")
        {
            BoxTemp = other.gameObject;
            BoxTemp.GetComponent<MoovingBox>().IsMooving = false;
            BoxTemp.transform.SetParent(this.transform);
            if (EtapeTr == 1)
            {
                IsTransfert = true;
                ChariotTr = 2;
            }
            else if (EtapeTr == 2)
            {
                BoxTemp.transform.SetParent(SetParentClone.transform);
                BoxTemp.GetComponent<MoovingBox>().ChoixDir = 1;
                BoxTemp.GetComponent<MoovingBox>().Spd = 0.03f;
                BoxTemp.GetComponent<MoovingBox>().IsMooving = true;
                EtapeTr = 3;
            }
        }
        else if (other.tag == "Step5")
        {
            BoxTemp = other.gameObject;
            if (EtapeTr == 1)
            {
                BrasArt.GetComponent<BrasArti>().FileAttente++;
                BoxTemp.GetComponent<MoovingBox>().Spd = 0.05f;
                ChariotTr = 3;
                IsTransfert = true;
            }
        }
    }
    void Start()
    {

        BrasArt = GameObject.Find("VentouseBrasArti");
        SetParentClone = GameObject.Find("SetParentClone");
        for (int i = 1; i < 4; i++)
        {
            GameObject temp = GameObject.Find("PointA1 (" + i + ")");
            WayPointPos.Add(temp);
        }
        for (int i = 1; i < 3; i++)
        {
            GameObject temp = GameObject.Find("PointA2 (" + i + ")");
            WayPointT.Add(temp);
        }
    }

    public void MooveUp()
    {
        if (IsTransfert == false)
        {
            if (ChariotPos < 3)
            {
                ChariotPos++;
                IsMoving = true;
            }

        }
    }
    public void MooveDown()
    {
        if (IsTransfert == false)
        {
            if (ChariotPos > 1)
            {
                ChariotPos--;
                IsMoving = true;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsMoving == true)
        {
            switch (ChariotPos)
            {
                case 1:
                    transform.position = Vector3.MoveTowards(transform.position, WayPointPos[0].transform.position, Speed);
                    break;
                case 2:
                    transform.position = Vector3.MoveTowards(transform.position, WayPointPos[1].transform.position, Speed);
                    break;
                case 3:
                    transform.position = Vector3.MoveTowards(transform.position, WayPointPos[2].transform.position, Speed);
                    break;
            }

            int e = ChariotPos - 1;
            Debug.Log("Position Chariot : " + ChariotPos);
            Debug.Log("Int e : " + e);
            if (transform.position == WayPointPos[e].transform.position)
            {
                IsMoving = false;
            }
        }
        if (IsTransfert == true)
        {
            switch (ChariotTr)
            {
                case 1:
                    switch (EtapeTr)
                    {
                        case 1:
                            transform.position = Vector3.MoveTowards(transform.position, WayPointT[0].transform.position, SpeedTransfert);
                            if (transform.position == WayPointT[0].transform.position)
                            {
                                EtapeTr++;
                            }
                            break;
                        case 2:
                            if (BoxTemp != null)
                            {
                                BoxTemp.GetComponent<MoovingBox>().ChoixDir = 1;
                                BoxTemp.GetComponent<MoovingBox>().Spd = 0.2f;
                                BoxTemp.GetComponent<MoovingBox>().IsMooving = true;
                            }
                            break;
                        case 3:
                            transform.position = Vector3.MoveTowards(transform.position, WayPointPos[0].transform.position, SpeedTransfert);
                            if (transform.position == WayPointPos[0].transform.position)
                            {
                                EtapeTr++;
                            }
                            break;
                        case 4:
                            IsTransfert = false;
                            EtapeTr = 1;
                            break;
                    }
                    break;
                case 2:
                    switch (EtapeTr)
                    {
                        case 1:
                            transform.position = Vector3.MoveTowards(transform.position, WayPointT[1].transform.position, SpeedTransfert);
                            if (transform.position == WayPointT[1].transform.position)
                            {
                                EtapeTr++;
                            }
                            break;
                        case 2:
                            if (BoxTemp != null)
                            {
                                BoxTemp.GetComponent<MoovingBox>().ChoixDir = 1;
                                BoxTemp.GetComponent<MoovingBox>().Spd = 0.2f;
                                BoxTemp.GetComponent<MoovingBox>().IsMooving = true;
                            }
                            break;
                        case 3:
                            transform.position = Vector3.MoveTowards(transform.position, WayPointPos[1].transform.position, SpeedTransfert);
                            if (transform.position == WayPointPos[1].transform.position)
                            {
                                EtapeTr++;
                            }
                            break;
                        case 4:
                            IsTransfert = false;
                            EtapeTr = 1;
                            break;
                    }
                    break;
                case 3:
                    break;
            }

            int e = ChariotPos - 1;
            if (transform.position == WayPointPos[e].transform.position)
            {
                IsMoving = false;
            }
        }
    }
}
