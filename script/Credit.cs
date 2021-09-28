using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
 
    public GameObject DirUp, CreditText;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Menu");
    }
    private void Update()
    {
        CreditText.transform.position = Vector3.MoveTowards(CreditText.transform.position, DirUp.transform.position, 50f * Time.deltaTime);
    }
    public void OnBackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
