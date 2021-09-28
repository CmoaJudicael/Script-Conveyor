using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingBox : MonoBehaviour
{
    public Transform dir1, dir2;
    public float Spd = 0.2f;
    public int ChoixDir = 1;
    Vector3 Dir;
    public bool IsMooving = true;
    public GameObject StartBox;

    private void Start()
    {
        StartBox = GameObject.Find("Machine Start");
    }
    // Update is called once per frame
    void Update()
    {
        switch (ChoixDir)
        {
            case 1:
                Dir = dir1.position;
                break;
            case 2:
                Dir = dir2.position;
                break;
        }
        if (IsMooving)
        {
            if (StartBox.GetComponent<StartingBox>().GameIsStarted == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, Dir, Spd);
            }
        }
    }
    public void DestroyHim()
    {
        Destroy(this.gameObject);
    }
}
