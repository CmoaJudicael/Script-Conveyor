using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject _AudioManager, PrefabAudio, PanelSettings, PanelMainMenu, MainCam, PanelLogin;
    public List<GameObject> WayPointCam = new List<GameObject>();
    public int MenuIndex = 3;
    public float Speed = 0.2f, SpdRot = 0.1f;
    public bool IsPlaying = false;

    private void Awake()
    {
        if (!GameObject.Find("Audio Source(Clone)"))
        {
            Instantiate(PrefabAudio);
        }

    }
    void Start()
    {
        _AudioManager = GameObject.Find("Audio Source(Clone)");
        PanelSettings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (MenuIndex)
        {
            case 3:
                MainCam.transform.position = Vector3.MoveTowards(MainCam.transform.position, WayPointCam[MenuIndex].transform.position, Speed);
                MainCam.transform.rotation = Quaternion.Slerp(MainCam.transform.rotation, WayPointCam[MenuIndex].transform.rotation, SpdRot);
                if (MainCam.transform.position == WayPointCam[MenuIndex].transform.position)
                {
                    PanelLogin.SetActive(true);
                }
                break;
            case 0://MainMenu
                MainCam.transform.position = Vector3.MoveTowards(MainCam.transform.position, WayPointCam[MenuIndex].transform.position, Speed);
                MainCam.transform.rotation = Quaternion.Slerp(MainCam.transform.rotation, WayPointCam[MenuIndex].transform.rotation, SpdRot);
                if (MainCam.transform.position == WayPointCam[MenuIndex].transform.position)
                {
                    PanelMainMenu.SetActive(true);
                }
                break;
            case 1://SettingsMenu
                MainCam.transform.position = Vector3.MoveTowards(MainCam.transform.position, WayPointCam[MenuIndex].transform.position, Speed);
                MainCam.transform.rotation = Quaternion.Slerp(MainCam.transform.rotation, WayPointCam[MenuIndex].transform.rotation, SpdRot);
                if (MainCam.transform.position == WayPointCam[MenuIndex].transform.position)
                {
                    PanelSettings.SetActive(true);
                }
                break;
            case 2://Classement
                MainCam.transform.position = Vector3.MoveTowards(MainCam.transform.position, WayPointCam[MenuIndex].transform.position, Speed);
                MainCam.transform.rotation = Quaternion.Slerp(MainCam.transform.rotation, WayPointCam[MenuIndex].transform.rotation, SpdRot);
                break;
        }
        
    }
    public void SetIndexMenu(int index)
    {
        MenuIndex = index;
    }
    public void OnStartButton()
    {

        _AudioManager.GetComponent<AudioManager>().SonInGame();
        SceneManager.LoadScene("Level");
    }
    public void OnSettingsMenu()
    {
        PanelMainMenu.SetActive(false);
        MenuIndex = 1;
    }
    public void OnHowToMenu()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void OnBackMenuButton()
    {
        PanelSettings.SetActive(false);
        MenuIndex = 0;
    }
    public void doExitGame()
    {
        Application.Quit();
    }
    public void OnClassement()
    {
        PanelMainMenu.SetActive(false);
        MenuIndex = 2;
    }
    public void OnCreditButton()
    {
        SceneManager.LoadScene("Credit");
    }
}
