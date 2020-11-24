using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu_param : MonoBehaviour
{
    public TMP_Text Playername;
    public CanvasGroup menucanvas, nickcanvas, quizcanvas, autoricanvas;
    public static string Scena = "nothing";
    void Start()
    {
    }

    public void NewGame()// po kliknuti na novu hru, zobrazim input na nick
    {
        menucanvas.gameObject.SetActive(false);
        nickcanvas.gameObject.SetActive(true);
        Scena = "Hra";
    }

    public void CanvasQuiz_load()
    {
        menucanvas.gameObject.SetActive(false);
        quizcanvas.gameObject.SetActive(true);
    }

    public void CloseQuiz()
    {
        quizcanvas.gameObject.SetActive(false);
        menucanvas.gameObject.SetActive(true);
    }

    public void NewQuiz1()//scitenie zlomkov
    {
        quizcanvas.gameObject.SetActive(false);
        nickcanvas.gameObject.SetActive(true);
        Scena = "Hra-Quiz";
    }

    public void ContinueGame()
    {
        Debug.Log("Continue Game");
    }

    public void OpenQuizMenu()
    {
        CanvasQuiz_load();
    }

    public void ShowCredits()
    {
        menucanvas.gameObject.SetActive(false);
        autoricanvas.gameObject.SetActive(true);
    }

    public void CloseCredits()
    {
        autoricanvas.gameObject.SetActive(false);
        menucanvas.gameObject.SetActive(true);
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
        menucanvas.gameObject.SetActive(true);
    }

    void Update()
    {
        //
    }
}
