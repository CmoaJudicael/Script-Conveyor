using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChariotController2 : MonoBehaviour
{
    public List<GameObject> WayPointPos = new List<GameObject>();
    public List<GameObject> WayPointT = new List<GameObject>();
    public int ChariotPos = 1, ChariotTr = 1, EtapeTr = 1;
    public float Speed = 1, SpeedTransfert = 1;
    public bool IsMoving = false, IsTransfert = false;
    public GameObject BoxTemp, SetParentClone, ButoirSphere;
    public Quaternion PHaut, Pbas, sphere;

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Step2")
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
                BoxTemp.GetComponent<MoovingBox>().ChoixDir = 2;
                BoxTemp.GetComponent<MoovingBox>().Spd = 0.02f;
                BoxTemp.GetComponent<MoovingBox>().IsMooving = true;
                EtapeTr = 3;
            }
        }
        else if (other.tag == "Step4")
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
                BoxTemp.GetComponent<MoovingBox>().ChoixDir = 2;
                BoxTemp.GetComponent<MoovingBox>().Spd = 0.02f;
                BoxTemp.GetComponent<MoovingBox>().IsMooving = true;
                EtapeTr = 3;
            }
        }
        else if (other.tag == "Step0")
        {
            BoxTemp = other.gameObject;
            if (EtapeTr == 2)
            {
                EtapeTr++;
            }
            else if (EtapeTr == 4)
            {
                BoxTemp.GetComponent<MoovingBox>().Spd = 0.02f;
                EtapeTr = 1;
                IsTransfert = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Step2")
        {
            BoxTemp = other.gameObject;
            BoxTemp.GetComponent<MoovingBox>().Spd = 0.2f;

        }
        else if (other.tag == "Step4")
        {
            BoxTemp = other.gameObject;
            BoxTemp.GetComponent<MoovingBox>().Spd = 0.2f;
        }
        else if (other.tag == "Step0")
        {
            BoxTemp = other.gameObject;
            if (EtapeTr == 1)
            {
                IsTransfert = true;
                EtapeTr++;
                ChariotTr = 3;
                BoxTemp.GetComponent<MoovingBox>().Spd = 0.4f;
            }
            if (EtapeTr == 3)
            {
                EtapeTr++;
            }
        }
    }
    void Start()
    {
        PHaut = Quaternion.Euler(90, 0, 0);
        Pbas = Quaternion.Euler(0,0,0);
        ButoirSphere = GameObject.Find("ButoirSphere");
        SetParentClone = GameObject.Find("SetParentClone");
        for (int i = 1; i < 4; i++)
        {
            GameObject temp = GameObject.Find("PointB1 (" + i + ")");
            WayPointPos.Add(temp);
        }
        for (int i = 1; i < 3; i++)
        {
            GameObject temp = GameObject.Find("PointB2 (" + i + ")");
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
        if (ChariotPos == 1)
        {
            ButtoirOn();
        }
        else
        {
            ButtoirOff();
        }
        
        if (IsMoving == true)
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
                            if (BoxTemp!= null)
                            {
                                BoxTemp.GetComponent<MoovingBox>().ChoixDir = 2;
                                BoxTemp.GetComponent<MoovingBox>().Spd = 0.3f;
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
                                BoxTemp.GetComponent<MoovingBox>().ChoixDir = 2;
                                BoxTemp.GetComponent<MoovingBox>().Spd = 0.3f;
                                BoxTemp.GetComponent<MoovingBox>().IsMooving = true;
                            }
                            break;
                        case 3:
                            transform.position = Vector3.MoveTowards(transform.position, WayPointPos[2].transform.position, SpeedTransfert);
                            if (transform.position == WayPointPos[2].transform.position)
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
    void ButtoirOn()
    {

        ButoirSphere.transform.rotation = Quaternion.Slerp(Pbas, PHaut, 1);
    }
    void ButtoirOff()
    {

        ButoirSphere.transform.rotation = Quaternion.Slerp(PHaut, Pbas, 1);
    }
}
