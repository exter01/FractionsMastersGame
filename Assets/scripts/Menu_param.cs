using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.EventSystems; //event
using TMPro;

public class Menu_param : MonoBehaviour
{
    public TMP_Text Playername;
    public CanvasGroup menucanvas, nickcanvas, quizcanvas;
    //public EventSystem menuevent;
    public static string Scena = "nothing";
    void Start()
    {
    }

    public void NewGame()// po kliknuti na novu hru, zobrazim input na nick
    {
        menucanvas.gameObject.SetActive(false);
        //menucanvas.alpha = 1 - menucanvas.alpha;
        //menucanvas.interactable = false;
        nickcanvas.gameObject.SetActive(true);
        //nickcanvas.alpha = 1 + nickcanvas.alpha;
        //nickcanvas.interactable = true;
        Scena = "Hra";
    }

    public void CanvasQuiz_load()
    {
        menucanvas.gameObject.SetActive(false);
        //menucanvas.alpha = 1 - menucanvas.alpha;
        //menucanvas.interactable = false;
        quizcanvas.gameObject.SetActive(true);
        //quizcanvas.alpha = 1 + quizcanvas.alpha;
        //quizcanvas.interactable = true;
    }

    public void NewQuiz1()//scitenie zlomkov
    {
        quizcanvas.gameObject.SetActive(false);
        //quizcanvas.alpha = 1 - quizcanvas.alpha;
        //quizcanvas.interactable = false;
        nickcanvas.gameObject.SetActive(true);
        //nickcanvas.alpha = 1 + nickcanvas.alpha;
        //nickcanvas.interactable = true;
        Scena = "Hra-Quiz";
    }

    public void ContinueGame()
    {
        Debug.Log("Continue Game");
    }

    public void LoadLevelGame()
    {
        Debug.Log("Load level Game");
        CanvasQuiz_load();
    }

    public void ShowScoreTable()
    {
        Debug.Log("Show score table");
    }

    public void NewGamewithnick()//vyplneny nick a ideme hrat
    {
        Debug.Log("Player name is: " + Playername.text);
        Hra_param.playernamestr = Playername.text;
        Hra_quiz_param.playernamestr = Playername.text;
        SceneManager.LoadScene(Scena);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT Game");
        Application.Quit();
    }

    public void BackMenufromnick()
    {
        Debug.Log("Back menu");
        nickcanvas.gameObject.SetActive(false);
        //nickcanvas.alpha = 1 - nickcanvas.alpha;
        //nickcanvas.interactable = false;
        menucanvas.gameObject.SetActive(true);
        //menucanvas.alpha = 1 + menucanvas.alpha;
        //menucanvas.interactable = true;
    }

    void Update()
    {
        //
    }
}
