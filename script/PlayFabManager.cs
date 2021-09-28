using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;


public class PlayFabManager : MonoBehaviour
{
    [Header("Windows Login")]
    public InputField nameInput;
    public GameObject GameMenu;
    [Header("Leaderboard")]
    public GameObject rowPrefab;
    public Transform rowsParent;
    public Text ErrorText;


    void Start()
    {
        Login();        
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
            Debug.Log("The Name "+name);
        }
        if (name == null)
        {
            if (PlayerPrefs.GetInt("IsGameMenu") == 1)
            {
                Debug.Log("No Display Name Create!");
                GameMenu.GetComponent<Menu>().SetIndexMenu(3);

            }
        }
        else
        {
            if (PlayerPrefs.GetInt("IsGameMenu") == 1)
            {
                GameMenu.GetComponent<Menu>().SetIndexMenu(0);
                GameMenu.GetComponent<Menu>().PanelLogin.SetActive(false);
            }
        }
    }
    public void SubmitNameButton()
    {
        ErrorText.text = "";
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }
    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name!");
        GameMenu.GetComponent<Menu>().SetIndexMenu(0);
        GameMenu.GetComponent<Menu>().PanelLogin.SetActive(false);
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
        ErrorText.text = error.GenerateErrorReport();
    }
    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "High Score",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }
    public void GetLeaderboard()
    {
        Debug.Log("GetLeaderboard");
        var request = new GetLeaderboardRequest
        {
            StatisticName = "High Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[2].text = item.DisplayName;
            texts[1].text = item.StatValue.ToString();

            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }

}
