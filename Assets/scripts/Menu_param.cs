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
    public static string kam_idem = "nikam";

    void Start()
    {
        //
    }

    public void NewGame()// po kliknuti na novu hru, zobrazim input na nick
    {
        menucanvas.gameObject.SetActive(false);
        nickcanvas.gameObject.SetActive(true);
        kam_idem = "novahra";
    }

    public void NewGamewithnick()//vyplneny nick a ideme hrat
    {
        Debug.Log("Player name is: " + Playername.text);

        if(kam_idem == "novahra")
        {
            Hra_param.playernamestr = Playername.text;
            Hra_param.CELKOVESKORE = 0;
            Hra_param.aktualny_level = 1;
            Hra_loading_param.zobraz_uvod = true;
            SceneManager.LoadScene("Hra-loading");
        }

        if(kam_idem == "quiz1")
        {
            Hra_quiz_param.playernamestr = Playername.text;
            SceneManager.LoadScene("Hra-Quiz");
            Hra_quiz_param.level_cislo = 1;
            Debug.Log(Hra_quiz_param.level_cislo);
        }

        if (kam_idem == "quiz2")
        {
            Hra_quiz_param.playernamestr = Playername.text;
            SceneManager.LoadScene("Hra-Quiz");
            Hra_quiz_param.level_cislo = 2;
            Debug.Log(Hra_quiz_param.level_cislo);
        }

        if (kam_idem == "quiz3")
        {
            Hra_quiz_param.playernamestr = Playername.text;
            SceneManager.LoadScene("Hra-Quiz");
            Hra_quiz_param.level_cislo = 3;
            Debug.Log(Hra_quiz_param.level_cislo);
        }

        if (kam_idem == "quiz4")
        {
            Hra_quiz_param.playernamestr = Playername.text;
            SceneManager.LoadScene("Hra-Quiz");
            Hra_quiz_param.level_cislo = 4;
            Debug.Log(Hra_quiz_param.level_cislo);
        }
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
        kam_idem = "quiz1";
    }

    public void NewQuiz2()//odcitanie zlomkov
    {
        quizcanvas.gameObject.SetActive(false);
        nickcanvas.gameObject.SetActive(true);
        kam_idem = "quiz2";
    }

    public void NewQuiz3()//nasobenie zlomkov
    {
        quizcanvas.gameObject.SetActive(false);
        nickcanvas.gameObject.SetActive(true);
        kam_idem = "quiz3";
    }

    public void NewQuiz4()//delenie zlomkov
    {
        quizcanvas.gameObject.SetActive(false);
        nickcanvas.gameObject.SetActive(true);
        kam_idem = "quiz4";
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
        //nothing
    }
}
