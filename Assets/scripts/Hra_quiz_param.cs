using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Hra_quiz_param : MonoBehaviour
{
    public static string playernamestr;//meno hraca z menu
    public TMP_Text Playername; //meno hraca z menu
    public TMP_Text odpoved; // vybrana odpoved
    public TMP_Text score; // zobrazene skore
    public TMP_Text score_finish; // zobrazene skore na konci v canvasscore
    public CanvasGroup hernycanvas, scorecanvas;
    public static int vybrana_odpoved;
    public static int spravna_odpoved;
    public static int priklad_cislo;
    public static int act_score;
    public static float cas_dlzka = 25f; //cas na vyber moznosti

    public GameObject Xko, Fajka, Xko_1, Xko_2, Xko_3;
    public TMP_Text Zadanie_1, Zadanie_2, Zadanie_3, Zadanie_4, Zadanie_5;
    public TMP_Text A_1, A_2, B_1, B_2, C_1, C_2;
    public GameObject X_1A, X_2A, X_3A, X_1X, X_2X, X_3X, X_1Y, X_2Y, X_3Y;

    public static int potvrdit_click; //pri odpovediach je dva krat button odpoved
    public static int pocet_zobraz_list;

    public static int level_cislo = 0; // vyebrame level, plus, minus atd...

    public void nastav_priklad(string Z1, string Z2, string Z3, string Z4, string Z5, string A1, string A2, string B1, string B2, string C1, string C2)
    {
        Zadanie_1.text = string.Format("{0}", Z1);
        Zadanie_2.text = string.Format("{0}", Z2);
        Zadanie_3.text = string.Format("{0}", Z3);
        Zadanie_4.text = string.Format("{0}", Z4);
        Zadanie_5.text = string.Format("{0}", Z5);
        A_1.text = string.Format("{0}", A1);
        A_2.text = string.Format("{0}", A2);
        B_1.text = string.Format("{0}", B1);
        B_2.text = string.Format("{0}", B2);
        C_1.text = string.Format("{0}", C1);
        C_2.text = string.Format("{0}", C2);
    }

    public void spravne_odpovede()
    {
        if(level_cislo == 1)//scitanie
        {
            if (priklad_cislo == 1)
            {
                nastav_priklad("1", "7", "+", "3", "7", "4", "7", "4", "14", "6", "10");
                spravna_odpoved = 1; //1 je A, 2 je B, 3 je C
            }
            if (priklad_cislo == 2)
            {
                nastav_priklad("3", "5", "+", "1", "5", "8", "6", "4", "10", "4", "5");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 3)
            {
                nastav_priklad("6", "11", "+", "3", "11", "9", "11", "12", "22", "16", "14");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 4)
            {
                nastav_priklad("1", "3", "+", "8", "9", "4", "17", "9", "12", "11", "9");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 5)
            {
                nastav_priklad("5", "18", "+", "1", "12", "23", "13", "6", "30", "13", "36");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 6)
            {
                nastav_priklad("3", "4", "+", "1", "6", "4", "10", "11", "12", "7", "12");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 7)
            {
                nastav_priklad("5", "6", "+", "1", "4", "13", "12", "11", "5", "6", "10");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 8)
            {
                nastav_priklad("3", "4", "+", "4", "3", "7", "4", "25", "12", "7", "7");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 9)
            {
                nastav_priklad("5", "8", "+", "3", "7", "13", "10", "34", "56", "59", "56");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 10)
            {
                nastav_priklad("8", "13", "+", "11", "15", "19", "28", "263", "195", "264", "195");
                spravna_odpoved = 2;
            }
        }

        if (level_cislo == 2)//odcitavanie
        {
            if (priklad_cislo == 1)
            {
                nastav_priklad("4", "5", "-", "3", "10", "1", "2", "1", "5", "1", "10");
                spravna_odpoved = 1; //1 je A, 2 je B, 3 je C
            }
            if (priklad_cislo == 2)
            {
                nastav_priklad("15", "4", "-", "7", "8", "8", "8", "20", "8", "23", "8");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 3)
            {
                nastav_priklad("1", "6", "-", "1", "8", "1", "2", "2", "24", "1", "24");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 4)
            {
                nastav_priklad("5", "8", "-", "1", "4", "4", "8", "6", "8", "3", "8");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 5)
            {
                nastav_priklad("1", "2", "-", "1", "3", "2", "6", "1", "6", "4", "6");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 6)
            {
                nastav_priklad("5", "2", "-", "2", "5", "21", "10", "3", "10", "25", "10");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 7)
            {
                nastav_priklad("15", "12", "-", "5", "7", "15", "28", "20", "28", "10", "28");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 8)
            {
                nastav_priklad("23", "10", "-", "11", "8", "12", "40", "37", "40", "33", "40");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 9)
            {
                nastav_priklad("16", "8", "-", "15", "8", "1", "8", "8", "8", "8", "1");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 10)
            {
                nastav_priklad("22", "11", "-", "33", "22", "11", "11", "10", "2", "1", "2");
                spravna_odpoved = 3;
            }
        }

        if (level_cislo == 3)//nasobenie
        {
            if (priklad_cislo == 1)
            {
                nastav_priklad("1", "2", "*", "1", "3", "5", "6", "3", "4", "2", "5");
                spravna_odpoved = 1; //1 je A, 2 je B, 3 je C
            }
            if (priklad_cislo == 2)
            {
                nastav_priklad("1", "5", "+", "4", "3", "5", "8", "23", "15", "6", "7");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 3)
            {
                nastav_priklad("2", "3", "+", "1", "6", "7", "5", "3", "9", "5", "6");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 4)
            {
                nastav_priklad("4", "5", "+", "1", "10", "5", "15", "9", "10", "9", "11");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 5)
            {
                nastav_priklad("4", "3", "+", "7", "5", "41", "15", "38", "15", "11", "8");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 6)
            {
                nastav_priklad("8", "7", "+", "6", "5", "14", "12", "80", "35", "82", "35");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 7)
            {
                nastav_priklad("12", "2", "+", "12", "2", "12", "4", "24", "4", "12", "1");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 8)
            {
                nastav_priklad("9", "4", "+", "6", "7", "86", "28", "85", "28", "87", "28");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 9)
            {
                nastav_priklad("4", "8", "+", "7", "9", "93", "72", "23", "18", "11", "17");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 10)
            {
                nastav_priklad("12", "8", "+", "14", "4", "26", "12", "45", "8", "5", "1");
                spravna_odpoved = 3;
            }
        }

        if (level_cislo == 4)//delenie
        {
            if (priklad_cislo == 1)
            {
                nastav_priklad("1", "2", "/", "1", "3", "5", "6", "3", "4", "2", "5");
                spravna_odpoved = 1; //1 je A, 2 je B, 3 je C
            }
            if (priklad_cislo == 2)
            {
                nastav_priklad("1", "5", "+", "4", "3", "5", "8", "23", "15", "6", "7");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 3)
            {
                nastav_priklad("2", "3", "+", "1", "6", "7", "5", "3", "9", "5", "6");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 4)
            {
                nastav_priklad("4", "5", "+", "1", "10", "5", "15", "9", "10", "9", "11");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 5)
            {
                nastav_priklad("4", "3", "+", "7", "5", "41", "15", "38", "15", "11", "8");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 6)
            {
                nastav_priklad("8", "7", "+", "6", "5", "14", "12", "80", "35", "82", "35");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 7)
            {
                nastav_priklad("12", "2", "+", "12", "2", "12", "4", "24", "4", "12", "1");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 8)
            {
                nastav_priklad("9", "4", "+", "6", "7", "86", "28", "85", "28", "87", "28");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 9)
            {
                nastav_priklad("4", "8", "+", "7", "9", "93", "72", "23", "18", "11", "17");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 10)
            {
                nastav_priklad("12", "8", "+", "14", "4", "26", "12", "45", "8", "5", "1");
                spravna_odpoved = 3;
            }
        }
    }

    void listok_enable()
    {
        Cas_zostava.cas_uplynul = false;
        vybrana_odpoved = 4; //aby sa vynulovala odpoved po potvrdeni //doriesit 
        odpoved.text = string.Format("{0}", ""); // vynulujeme odpoved //doriesit
        priklad_cislo++;
        spravne_odpovede();
        Cas_zostava.timeLeft = cas_dlzka;
        Cas_zostava.timerIsRunning = true;
        if (priklad_cislo == 11) // po prejdeny vsetkych prikladov sa hra vypne, zatial
        {
            score_vyhodnotenie();
        }
    }

    public void vyber_odpoved1()
    {
        vybrana_odpoved = 1;
        odpoved.text = string.Format("{0}", "A");
        X_1A.gameObject.SetActive(true);
        X_2A.gameObject.SetActive(false);
        X_3A.gameObject.SetActive(false);
    }

    public void vyber_odpoved2()
    {
        vybrana_odpoved = 2;
        odpoved.text = string.Format("{0}", "B");
        X_1A.gameObject.SetActive(false);
        X_2A.gameObject.SetActive(true);
        X_3A.gameObject.SetActive(false);
    }

    public void vyber_odpoved3()
    {
        vybrana_odpoved = 3;
        odpoved.text = string.Format("{0}", "C");
        X_1A.gameObject.SetActive(false);
        X_2A.gameObject.SetActive(false);
        X_3A.gameObject.SetActive(true);
    }

    public void update_score()
    {
        score.text = string.Format("{0}", act_score);
    }

    public void Potvrdit_odpoved()
    {
        if (potvrdit_click == 0)
        {
            if (vybrana_odpoved != 4)
            {
                potvrdit_click = 1;
                if (vybrana_odpoved == 1 && spravna_odpoved == 1)
                {
                    act_score++;
                    Fajka.gameObject.SetActive(true);
                }
                else if (vybrana_odpoved == 2 && spravna_odpoved == 2)
                {
                    act_score++;
                    Fajka.gameObject.SetActive(true);
                }
                else if (vybrana_odpoved == 3 && spravna_odpoved == 3)
                {
                    act_score++;
                    Fajka.gameObject.SetActive(true);
                }
                else
                {
                    //bomb++;
                    Xko.gameObject.SetActive(true);
                }

                if (spravna_odpoved == 1)
                {
                    //X_1Y.gameObject.SetActive(true);
                    X_2X.gameObject.SetActive(true);
                    X_3X.gameObject.SetActive(true);
                }
                else if (spravna_odpoved == 2)
                {
                    X_1X.gameObject.SetActive(true);
                    // X_2Y.gameObject.SetActive(true);
                    X_3X.gameObject.SetActive(true);
                }
                else if (spravna_odpoved == 3)
                {
                    X_1X.gameObject.SetActive(true);
                    X_2X.gameObject.SetActive(true);
                    // X_3Y.gameObject.SetActive(true);
                }
            }
        }
        else if (potvrdit_click == 1)
        {
            potvrdit_click = 0;
            vybrana_odpoved = 4; //aby sa vynulovala odpoved po potvrdeni

            X_1A.gameObject.SetActive(false);
            X_2A.gameObject.SetActive(false);
            X_3A.gameObject.SetActive(false);

            X_1X.gameObject.SetActive(false);
            X_2X.gameObject.SetActive(false);
            X_3X.gameObject.SetActive(false);

            X_1Y.gameObject.SetActive(false);
            X_2Y.gameObject.SetActive(false);
            X_3Y.gameObject.SetActive(false);

            Fajka.gameObject.SetActive(false);
            Xko.gameObject.SetActive(false);
            update_score();
            listok_enable();
            //Debug.Log(vybrana_odpoved);
            odpoved.text = string.Format("{0}", ""); // vynulujeme odpoved
        }
    }

    public void score_vyhodnotenie()
    {
        hernycanvas.gameObject.SetActive(false);
        scorecanvas.gameObject.SetActive(true);
        score_finish.text = string.Format("{0} {1}", "Tvoje score je: ", act_score);
    }

    public void QuitGame() //doriesit vyresetovanie hry NEJDE !
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("quit game");
    }

    // Start is called before the first frame update
    void Start()
    {
        Playername.text = playernamestr; //meno hraca z menu
        vybrana_odpoved = 4;
        spravna_odpoved = 4;
        priklad_cislo = 0; 
        act_score = 0; 
        potvrdit_click = 0;
        pocet_zobraz_list = 0;
        update_score();//aby sa nastavilo score na 0
        listok_enable();//spusti prvu otazku
        Cas_zostava.timeLeft = cas_dlzka;
        Cas_zostava.timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cas_zostava.cas_uplynul == true)
        {
            listok_enable();
        }
    }
}
