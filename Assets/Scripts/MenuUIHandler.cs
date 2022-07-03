using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static TMPro.TMP_InputField;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScore;
    private string playerName;

    public void NewName(string input)
    {
        playerName = input;
        MainDataManager.instance.PlayerName = playerName;
    }

    public void NewBestScore(int bestScore)
    {
        MainDataManager.instance.BestScore = bestScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        MainDataManager.instance.LoadUserData();
        bestScore.text = "Best Score: " + MainDataManager.instance.PlayerName + " : " + MainDataManager.instance.BestScore;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MainDataManager.instance.SaveUserData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
