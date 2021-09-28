using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrasArti : MonoBehaviour
{
    public GameObject BoxTemp, Rotule, BrasMouvant, BrasPreneur, Chariot1;
    public Transform BrasPrenneurPosInit, BrasPrenneurPosTake, BrasMouvantBas, BrasMouvantHaut;
    public bool BoxIsTaked = false, Rot = false;
    public int EtapeTaked = 1, FileAttente = 0;
    public float Spd = 0.01f;
    Quaternion RotuleInit, RotuleFinal, RotVerif; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Step5")
        {
            BoxTemp = other.gameObject;

            BoxTemp.GetComponent<MoovingBox>().Spd = 0;
            BoxTemp.GetComponent<MoovingBox>().IsMooving = false;
            BoxTemp.GetComponent<Rigidbody>().useGravity = false;
            BoxTemp.GetComponent<Rigidbody>().isKinematic = true;
            BoxTemp.transform.SetParent(BrasPreneur.transform);
            BoxTemp.tag = "Taked";
            EtapeTaked = 2;
            Chariot1.GetComponent<ChariotController1>().IsTransfert = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Chariot1 = GameObject.Find("Transfers1");
        RotuleInit = Quaternion.Euler(Vector3.zero);
        RotuleFinal = Quaternion.Euler(0, 0, -180);
        RotVerif = Quaternion.Euler(-90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Rot == true)
        {
            RotationRotuleInit();
        }
        if (FileAttente > 0)
        {
            BoxIsTaked = true;
        }
        else
        {
            BoxIsTaked = false;
        }
        if (BoxIsTaked)
        {
            switch (EtapeTaked)
            {
                case 1:
                    BrasPreneur.transform.position = Vector3.MoveTowards(BrasPreneur.transform.position, BrasPrenneurPosTake.position, Spd);
                    break;
                case 2:
                    BrasMouvant.transform.position = Vector3.MoveTowards(BrasMouvant.transform.position, BrasMouvantHaut.position, Spd);
                    if (BrasMouvant.transform.position == BrasMouvantHaut.position)
                    {
                        EtapeTaked++;
                    }
                    break;
                case 3:
                   
                    BrasPreneur.transform.position = Vector3.MoveTowards(BrasPreneur.transform.position, BrasPrenneurPosInit.position, Spd);
                    if (BrasPreneur.transform.position == BrasPrenneurPosInit.position)
                    {
                        EtapeTaked++;
                    }
                    break;
                case 4:
                    Quaternion TempRot = Rotule.transform.rotation;
                    Rotule.transform.rotation = Quaternion.Slerp(TempRot, RotuleFinal, 0.15f);
                    break;
                case 5:
                    TempRot = Rotule.transform.rotation;
                    Rotule.transform.rotation = Quaternion.Slerp(TempRot, RotuleInit, 0.4f);
                    BrasMouvant.transform.position = Vector3.MoveTowards(BrasMouvant.transform.position, BrasMouvantBas.position, 0.05f);
                    if (BrasMouvant.transform.position == BrasMouvantBas.position)
                    {
                        Rot = false;
                        EtapeTaked++;
                    }
                    break;
                case 6:
                    FileAttente--;
                    EtapeTaked = 1;
                    break;
            }
        }
       
    }

    public void RotationRotuleInit()
    {
    }
}
