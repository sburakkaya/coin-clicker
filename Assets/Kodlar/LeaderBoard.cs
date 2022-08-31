using System.Collections;
using System.Collections.Generic;
using LootLocker.Requests;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    int leaderboardID = 3676;
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;
    public TMP_InputField playerNameInputfield;

    public LeaderBoard leaderboard;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    public void SetPlayerName() 
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputfield.text, (response) => 
        {
            if (response.success) 
            {
                Debug.Log("Succesfully set player name");
                StartCoroutine(SetupRoutine());
                PlayerPrefs.SetString("playerPrefName",playerNameInputfield.text);
                Debug.Log(PlayerPrefs.GetString("playerPrefName"));
            }
            else 
            {
                Debug.Log("Could not set player name" + response.Error);
            }
        });
    }

    IEnumerator SetupRoutine() 
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighScoresRoutine();
    }

    IEnumerator LoginRoutine() 
    {
        bool done = false;

        LootLockerSDKManager.StartGuestSession((response) => {
            if (response.success)
            {
                Debug.Log("Succes");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Fail");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator SubmitScoreRoutine(int scoreToUpload) 
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) =>
        {
            if (response.success) 
            {
                Debug.Log("Score uploaded");
                done = true;
            }
            else 
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator FetchTopHighScoresRoutine() 
    {
        bool done = false;
        LootLockerSDKManager.GetScoreListMain(leaderboardID, 25, 0, (response) =>
        {
            if (response.success) 
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++) 
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name.Length > 8)
                    {
                        string prefName = PlayerPrefs.GetString("playerPrefName");
                        if (prefName == members[i].player.name)
                        {
                            tempPlayerNames += "<color=green>" + members[i].player.name.Substring(0,8) + "</color>";
                        }
                        else
                        {
                            tempPlayerNames += members[i].player.name.Substring(0,8);
                        }
                    }
                    else if(members[i].player.name != "") 
                    {
                        string prefName = PlayerPrefs.GetString("playerPrefName");
                        if (prefName == members[i].player.name)
                        {
                            tempPlayerNames += "<color=green>" + members[i].player.name + "</color>";
                        }
                        else
                        {
                            tempPlayerNames += members[i].player.name;
                        }
                    }
                    else 
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    //tempPlayerScores += members[i].score + "\n";
                    
                    if (members[i].score > 100000000)
                    {
                        tempPlayerScores += members[i].score/100000000 + "Qi" + "\n";
                    }
                    else if (members[i].score > 10000000)
                    {
                        tempPlayerScores += members[i].score/10000000 + "QA" + "\n";
                    }
                    else if (members[i].score > 1000000)
                    {
                        tempPlayerScores += members[i].score/1000000 + "T" + "\n";
                    }
                    else if (members[i].score > 100000)
                    {
                        tempPlayerScores += members[i].score/100000 + "B" + "\n";
                    }else if (members[i].score > 10000)
                    {
                        tempPlayerScores += members[i].score/10000 + "M" + "\n";
                    }else if (members[i].score > 1000)
                    {
                        tempPlayerScores += members[i].score/1000 + "K" + "\n";
                    }else
                    {
                        tempPlayerScores += members[i].score + "\n";
                    }
                    
                    tempPlayerNames += "\n";
                }
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else 
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
