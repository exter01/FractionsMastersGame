using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu_param : MonoBehaviour
{
    public TMP_Text Playername;
    public CanvasGroup menucanvas, nickcanvas;
    public static bool nick_zadany = false;
    void Start()
    {
    }
    public void NewGame()
    {
        menucanvas.alpha = 1 - menucanvas.alpha;
        menucanvas.interactable = false;
        nickcanvas.alpha = 1 + nickcanvas.alpha;
        nickcanvas.interactable = true;
    }

    public void ContinueGame()
    {
        Debug.Log("Continue Game");
    }

    public void LoadLevelGame()
    {
        Debug.Log("Load level Game");
    }

    public void ShowScoreTable()
    {
        Debug.Log("Show score table");
    }

    public void NewGamewithnick()
    {
        nick_zadany = true;
        SceneManager.LoadScene("Hra");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT Game");
        Application.Quit();
    }

    public void BackMenufromnick()
    {
        Debug.Log("Back menu");
        nickcanvas.alpha = 1 - nickcanvas.alpha;
        nickcanvas.interactable = false;
        menucanvas.alpha = 1 + menucanvas.alpha;
        menucanvas.interactable = true;
    }

    void Update()
    {
        if(nick_zadany == true)
        {
            Debug.Log("Player name is: " + Playername.text);
            Hra_param.playernamestr = Playername.text;
        }
    }
}
