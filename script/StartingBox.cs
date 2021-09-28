using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartingBox : MonoBehaviour
{
    public int HowToIndex = 1;
    public GameObject Chariot2, Chariot1, StartButton;


    public PlayFabManager playFabManager;
    public float SpdBox = 0.02f, SpdStar = 15;
    int EvolutionLvl;
    public int Ontimer, TimerClick, click;
    public int NbBox = 3, NLevel = 1, NbInstantiateBox = 0, NbBoxTomber, NbStars = 3, NbStarsMemory, TempBoxTomber, Score;
    public bool GameIsStarted = false, IsLvlUp = false, isHowTo = false;
    public GameObject _AudioManager, PrefabStart, OnStartPos, Truck, PanelStart, PauseMenu, PauseButton, PanelGameOver, PanelNextLevel, PanelDeplacement, NewStars, PanelSettings, AdsManager;
    public Text Niveau, Camion, Tombe, EnAttente, NxtLvl, StartLvl, ScoreNxtLvlText, ScoreTabText, ScoreGOText, CommandText;
    public List<GameObject> StarNxtLevel = new List<GameObject>();
    public List<GameObject> NewStarInst = new List<GameObject>();
    public List<int> NbEtoileParNiveau = new List<int>();


    private void Awake()
    {
        if (!PlayerPrefs.HasKey("IsGameMenu"))
        {
            PlayerPrefs.SetInt("IsGameMenu", 0);
            PlayerPrefs.Save();
            Debug.Log("IsGameMenu = " + PlayerPrefs.GetInt("IsGameMenu"));
        }
        else
        {

            PlayerPrefs.SetInt("IsGameMenu", 2);
            Debug.Log("IsGameMenu = " + PlayerPrefs.GetInt("IsGameMenu"));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _AudioManager = GameObject.Find("Audio Source(Clone)");
        EvolutionLvl = 2;
        PrefabStart.GetComponent<MoovingBox>().Spd = SpdBox;
        click = Random.Range(5, 15);
    }

    // Update is called once per frame
    void Update()
    {
        CommandText.text = (Truck.GetComponent<TruckLoad>().PublicNbBox + " BOX");
        ScoreTabText.text = ("Score                  " + Score); ;
        ScoreNxtLvlText.text = Score.ToString();
        ScoreGOText.text = Score.ToString();
        if (NLevel == EvolutionLvl)
        {
            EvolutionLvl = EvolutionLvl + 2;
            NbBox++;
        }
        if (!IsLvlUp)
        {
            if (NbBoxTomber == (NbBox / 3))
            {
                NbStars = 2;
            }
            else if (NbBoxTomber == ((NbBox * 2) / 3))
            {
                NbStars = 1;
            }
        }
        if (NbBoxTomber == NbBox)
        {
            GameOver();
        }
        if (!isHowTo)
        {
            StartLvl.text = ("WELCOME TO THE LEVEL " + NLevel);
        }
        NxtLvl.text = ("WELCOME TO THE LEVEL " + NLevel);
        EnAttente.text = ("En Attente             " + NbInstantiateBox);
        Niveau.text = ("Level                      " + NLevel);
        Tombe.text = ("Tombe                    " + NbBoxTomber);
        Camion.text = ("Camion                   " + Truck.GetComponent<TruckLoad>().NbBox);
        if (GameIsStarted)
        {
            Ontimer++;
            if (Ontimer == 20)
            {
                TimerClick++;
                Ontimer = 0;
            }
            if (TimerClick == click)
            {
                TimerClick = 0;
                if (NbInstantiateBox < NbBox)
                {
                    click = Random.Range(5, 15);
                    NewBoxInst();
                }

            }
        }
        if (IsLvlUp)
        {
            switch (NbStars)
            {
                case 1:
                    NewStarInst[0].transform.position = Vector3.MoveTowards(NewStarInst[0].transform.position, StarNxtLevel[0].transform.position, SpdStar);
                    if (NewStarInst[0].transform.position == StarNxtLevel[0].transform.position)
                    {
                        IsLvlUp = false;
                        NbStarsMemory = NbStars;
                    }
                    break;

                case 2:
                    if (NewStarInst[0].transform.position == StarNxtLevel[0].transform.position)
                    {
                        if (NewStarInst[1].transform.position == StarNxtLevel[1].transform.position)
                        {
                            IsLvlUp = false;
                            NbStarsMemory = NbStars;
                        }
                        else
                        {
                            NewStarInst[1].transform.position = Vector3.MoveTowards(NewStarInst[1].transform.position, StarNxtLevel[1].transform.position, SpdStar);
                        }
                    }
                    else
                    {
                        NewStarInst[0].transform.position = Vector3.MoveTowards(NewStarInst[0].transform.position, StarNxtLevel[0].transform.position, SpdStar);
                    }
                    break;

                case 3:
                    if (NewStarInst[0].transform.position == StarNxtLevel[0].transform.position)
                    {
                        if (NewStarInst[1].transform.position == StarNxtLevel[1].transform.position)
                        {
                            if (NewStarInst[2].transform.position == StarNxtLevel[2].transform.position)
                            {
                                IsLvlUp = false;
                                NbStarsMemory = NbStars;
                            }
                            else
                            {
                                NewStarInst[2].transform.position = Vector3.MoveTowards(NewStarInst[2].transform.position, StarNxtLevel[2].transform.position, SpdStar);
                            }
                        }
                        else
                        {
                            NewStarInst[1].transform.position = Vector3.MoveTowards(NewStarInst[1].transform.position, StarNxtLevel[1].transform.position, SpdStar);
                        }
                    }
                    else
                    {
                        NewStarInst[0].transform.position = Vector3.MoveTowards(NewStarInst[0].transform.position, StarNxtLevel[0].transform.position, SpdStar);
                    }
                    break;
            }

        }
    }
    public void OnStartButton()
    {
        PanelStart.SetActive(false);
        Debug.Log("Game Start");
        GameIsStarted = true;
        NewBoxInst();
    }
    public void OnPauseButton()
    {
        PauseButton.SetActive(false);
        GameIsStarted = false;
        PauseMenu.SetActive(true);
        PanelSettings.SetActive(false);
    }
    void NewBoxInst()
    {
        Instantiate(PrefabStart, OnStartPos.transform.position, Quaternion.identity);
        NbInstantiateBox++;
    }
    public void NextLevel()
    {
        GameIsStarted = true;
        PanelNextLevel.SetActive(false);
        NbBoxTomber = 0;
        for (int i = 0; i < NbStarsMemory; i++)
        {
            Destroy(NewStarInst[i]);
        }
        NewStarInst.Clear();
    }
    public void LevelUp()
    {
        GameObject DepartEtoile = GameObject.Find("DepartStar");
        NLevel++;
        PanelNextLevel.SetActive(true);
        NxtLvl.text = ("NEXT LEVEL " + NLevel);
        NbEtoileParNiveau.Add(NbStars);
        switch (NbStars)
        {
            case 1:
                GameObject TempStars = Instantiate(NewStars, DepartEtoile.transform) as GameObject;
                NewStarInst.Add(TempStars);
                TempStars.transform.SetParent(StarNxtLevel[0].transform);
                break;
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    TempStars = Instantiate(NewStars, DepartEtoile.transform) as GameObject;
                    NewStarInst.Add(TempStars);
                    TempStars.transform.SetParent(StarNxtLevel[i].transform);
                }
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    TempStars = Instantiate(NewStars, DepartEtoile.transform) as GameObject;
                    NewStarInst.Add(TempStars);
                    TempStars.transform.SetParent(StarNxtLevel[i].transform);
                }
                break;
        }
        IsLvlUp = true;
    }
    public void GameOver()
    {
        TempBoxTomber = NbBoxTomber;
        NbBoxTomber = 0;
        PanelGameOver.SetActive(true);
        GameIsStarted = false;
        playFabManager.SendLeaderboard(Score);
    }
    public void ReStart()
    {
        SceneManager.LoadScene("Level");
    }
    public void OnExit()
    {
        _AudioManager.GetComponent<AudioManager>().SonOnMenu();
        SceneManager.LoadScene("Menu");
    }
    public void OnSettingsMenu()
    {
        PauseMenu.SetActive(false);
        PanelSettings.SetActive(true);
    }
    public void OnResume()
    {
        PauseButton.SetActive(true);
        GameIsStarted = true;
        PauseMenu.SetActive(false);
    }
    public void HowToPlayRule()
    {
        switch (HowToIndex)
        {
            case 1:
                NewBoxInst();
                GameIsStarted = true;
                StartButton.SetActive(false);
                StartLvl.text = ("New box Is coming");
                HowToIndex++;
                break;
            case 2:
                StartLvl.text = ("Use the cart to guide the box");
                HowToIndex++;
                break;
            case 3:
                StartLvl.text = ("the box follow the conveyor...");
                HowToIndex++;
                break;
            case 4:
                StartLvl.text = ("...and is transmit to another conveyor with the cart");
                HowToIndex++;
                break;
            case 5:
                StartLvl.text = ("Use Arrow to move a cart");
                PanelDeplacement.SetActive(true);
                HowToIndex++;
                break;
            case 6:
                StartLvl.text = ("The cart take the box");
                HowToIndex++;
                Chariot2.GetComponent<ChariotController2>().MooveUp();
                break;
            case 7:
                StartLvl.text = ("Guide the box to reach the truck");
                Chariot1.GetComponent<ChariotController1>().MooveUp();
                HowToIndex++;
                break;
            case 8:
                StartLvl.text = ("You level up when the truck is full");
                HowToIndex++;
                break;
            case 9:
                StartLvl.text = ("Thank You to read this Nice Play");
                GameIsStarted = false;
                StartButton.SetActive(true);
                HowToIndex++;
                break;
            case 10:
                PlayerPrefs.SetInt("IsGameMenu", 1);
                SceneManager.LoadScene("Menu");
                break;


        }

    }
}
