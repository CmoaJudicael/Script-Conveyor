using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckLoad : MonoBehaviour
{
    public GameObject TruckWayInit, TruckWayFinal, BrasArt, StartBox;
    List<GameObject> Chargement = new List<GameObject>();
    public int NbBox = 0, EtapeChange = 1, PublicNbBox;
    bool ChangeLevel = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Taked")
        {
            Debug.Log("Box in the truck");
            other.GetComponent<MoovingBox>().DestroyHim();
            Chargement[NbBox].SetActive(true);
            NbBox++;
            BrasArt.GetComponent<BrasArti>().EtapeTaked++;
            StartBox.GetComponent<StartingBox>().NbInstantiateBox--;
            StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 50;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartBox = GameObject.Find("Machine Start");
        BrasArt = GameObject.Find("VentouseBrasArti");
        TruckWayInit = GameObject.Find("TruckWayInit");
        TruckWayFinal = GameObject.Find("TruckWayFinal");
        for(int i = 1; i < 17; i++)
        {
            GameObject Temp = GameObject.Find("LoadTruck (" + i + ")");
            Chargement.Add(Temp);
            Temp.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( StartBox.GetComponent<StartingBox>().NLevel <= 25)
        {
            switch(StartBox.GetComponent<StartingBox>().NLevel)
            {
                case 1:
                    PublicNbBox = 3;
                    if (NbBox == 3)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 2:
                    PublicNbBox = 4;
                    if (NbBox == 4)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 3:
                    PublicNbBox = 4;
                    if (NbBox == 4)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 4:
                    PublicNbBox = 5;
                    if (NbBox == 5)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 5:
                    PublicNbBox = 5;
                    if (NbBox == 5)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 6:
                    PublicNbBox = 6;
                    if (NbBox == 6)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 7:
                    PublicNbBox = 6;
                    if (NbBox == 6)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 8:
                    PublicNbBox = 7;
                    if (NbBox == 7)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 9:
                    PublicNbBox = 7;
                    if (NbBox == 7)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 10:
                    PublicNbBox = 8;
                    if (NbBox == 8)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 11:
                    PublicNbBox = 8;
                    if (NbBox == 8)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 12:
                    PublicNbBox = 9;
                    if (NbBox == 9)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 13:
                    if (NbBox == 9)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 14:
                    PublicNbBox = 10;
                    if (NbBox == 10)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 15:
                    PublicNbBox = 10;
                    if (NbBox == 10)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 16:
                    PublicNbBox = 11;
                    if (NbBox == 11)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 17:
                    PublicNbBox = 11;
                    if (NbBox == 11)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 18:
                    PublicNbBox = 12;
                    if (NbBox == 12)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 19:
                    PublicNbBox = 12;
                    if (NbBox == 12)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 20:
                    PublicNbBox = 13;
                    if (NbBox == 13)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 21:
                    if (NbBox == 13)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 22:
                    if (NbBox == 14)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 23:
                    PublicNbBox = 14;
                    if (NbBox == 14)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 24:
                    PublicNbBox = 15;
                    if (NbBox == 15)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;
                case 25:
                    PublicNbBox = 16;
                    if (NbBox == 15)
                    {
                        Debug.Log("Change Level");
                        StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                        StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                        ChangeLevel = true;
                    }
                    break;

            }

        }
        else
        {
            PublicNbBox = 16;
            if (NbBox == 16)
            {
                Debug.Log("Change Level");
                StartBox.GetComponent<StartingBox>().GameIsStarted = false;
                StartBox.GetComponent<StartingBox>().Score = StartBox.GetComponent<StartingBox>().Score + 10;
                ChangeLevel = true;
            }
        }

        if (ChangeLevel)
        {
            switch(EtapeChange)
            {
                case 1:
                    Debug.Log("Case 1, EtapeChange " + EtapeChange);
                    EtapeChange++;
                    break;
                case 2:
                    Debug.Log("Case 2, EtapeChange " + EtapeChange);
                    this.transform.position = Vector3.MoveTowards(transform.position, TruckWayFinal.transform.position, 0.5f);
                    if (transform.position == TruckWayFinal.transform.position)
                    {
                        EtapeChange++;
                    }
                    break;
                case 3:
                    Debug.Log("Case 3, EtapeChange " + EtapeChange + "/n NbBox : " + NbBox);
                    int dBox = NbBox + 1;
                    for (int i = 1; i < dBox; i++)
                    {
                        NbBox--;
                        Debug.Log("NbBox : " + NbBox + " Décrementer");
                        Chargement[NbBox].SetActive(false);
                    }
                    EtapeChange++;
                    break;
                case 4:
                    Debug.Log("Case 4, EtapeChange " + EtapeChange);
                    this.transform.position = Vector3.MoveTowards(transform.position, TruckWayInit.transform.position, 0.5f);
                    if (this.transform.position == TruckWayInit.transform.position)
                    {
                        EtapeChange++;
                    }
                    break;
                case 5:
                    Debug.Log("Case 5, EtapeChange " + EtapeChange);
                    StartBox.GetComponent<StartingBox>().LevelUp();
                    ChangeLevel = false;
                    EtapeChange = 1;
                    break;
            }
        }
    }
}
