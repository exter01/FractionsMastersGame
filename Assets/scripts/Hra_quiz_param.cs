using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Hra_quiz_param : MonoBehaviour
{
    //public static string playernamestr;//meno hraca z menu
    //public TMP_Text Playername; //meno hraca z menu
    public TMP_Text odpoved; // vybrana odpoved
    public TMP_Text score; // zobrazene skore
    public TMP_Text score_finish, score_finish_max; // zobrazene skore na konci v canvasscore
    public TMP_Text poradie;
    public CanvasGroup hernycanvas, scorecanvas, scoretopcanvas;
    public static int vybrana_odpoved, spravna_odpoved, priklad_cislo, act_score, act_bad;
    public static float cas_dlzka = 240f; //cas na vyber moznosti

    /*public GameObject Xko, Fajka, Xko_1, Xko_2, Xko_3;
    public TMP_Text Zadanie_1, Zadanie_2, Zadanie_3, Zadanie_4, Zadanie_5;
    public TMP_Text A_1, A_2, B_1, B_2, C_1, C_2;
    public GameObject X_1A, X_2A, X_3A, X_1X, X_2X, X_3X, X_1Y, X_2Y, X_3Y;*/

    //odpoved
    public GameObject Xko, Fajka, X_1A, X_2A, X_3A;
    public TMP_Text Zadanie_1, Zadanie_2, Zadanie_3, Zadanie_4, Zadanie_5, A_1, A_2, B_1, B_2, C_1, C_2;
    public GameObject X1_Biely, X1_Zlty, X1_Cerveny, X1_Zeleny, X2_Biely, X2_Zlty, X2_Cerveny, X2_Zeleny, X3_Biely, X3_Zlty, X3_Cerveny, X3_Zeleny;
    //odpoved porovnavanie
    public GameObject Odpoved_bg, Odpoved_bg2, Pomocny1_text, Pomocny2_text, X1_ciarka, X2_ciarka, X3_ciarka;
    //end porovnavanie
    //end odpoved


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
        X1_Biely.gameObject.SetActive(true);
        X1_Zlty.gameObject.SetActive(false);
        X2_Biely.gameObject.SetActive(true);
        X2_Zlty.gameObject.SetActive(false);
        X3_Biely.gameObject.SetActive(true);
        X3_Zlty.gameObject.SetActive(false);
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
                nastav_priklad("9", "8", "+", "7", "3", "19", "28", "83", "24", "72", "24");
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
                nastav_priklad("7", "8", "*", "3", "9", "21", "24", "7", "24", "21", "72");
                spravna_odpoved = 2; //1 je A, 2 je B, 3 je C
            }
            if (priklad_cislo == 2)
            {
                nastav_priklad("9", "4", "*", "12", "6", "98", "6", "43", "24", "9", "2");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 3)
            {
                nastav_priklad("3", "3", "*", "4", "2", "12", "6", "8", "6", "2", "1");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 4)
            {
                nastav_priklad("7", "5", "*", "9", "3", "21", "5", "63", "5", "70", "15");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 5)
            {
                nastav_priklad("3", "4", "*", "1", "2", "16", "8", "24", "8", "3", "8");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 6)
            {
                nastav_priklad("11", "12", "*", "6", "5", "66", "10", "11", "10", "25", "10");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 7)
            {
                nastav_priklad("5", "3", "*", "6", "5", "30", "10", "2", "1", "30", "6");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 8)
            {
                nastav_priklad("3", "4", "*", "8", "6", "1", "1", "24", "8", "16", "8");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 9)
            {
                nastav_priklad("9", "10", "*", "5", "3", "9", "2", "6", "2", "3", "2");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 10)
            {
                nastav_priklad("15", "16", "*", "24", "25", "9", "10", "45", "10", "38", "10");
                spravna_odpoved = 1;
            }
        }

        if (level_cislo == 4)//delenie
        {
            if (priklad_cislo == 1)
            {
                nastav_priklad("5", "4", ":", "15", "8", "6", "3", "2", "3", "10", "4");
                spravna_odpoved = 2; //1 je A, 2 je B, 3 je C
            }
            if (priklad_cislo == 2)
            {
                nastav_priklad("1", "8", ":", "3", "6", "1", "4", "5", "4", "10", "3");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 3)
            {
                nastav_priklad("7", "5", ":", "14", "3", "11", "10", "3", "10", "7", "10");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 4)
            {
                nastav_priklad("8", "12", ":", "8", "6", "4", "6", "9", "3", "1", "2");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 5)
            {
                nastav_priklad("1", "6", ":", "7", "2", "12", "21", "7", "12", "1", "21");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 6)
            {
                nastav_priklad("1", "10", ":", "1", "4", "2", "5", "10", "5", "8", "5");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 7)
            {
                nastav_priklad("11", "8", ":", "14", "7", "14", "12", "11", "16", "12", "16");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 8)
            {
                nastav_priklad("3", "2", ":", "2", "4", "12", "2", "10", "3", "3", "1");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 9)
            {
                nastav_priklad("18", "7", ":", "16", "6", "43", "20", "27", "28", "30", "28");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 10)
            {
                nastav_priklad("9", "8", ":", "7", "6", "27", "28", "54", "28", "33", "28");
                spravna_odpoved = 1;
            }
        }

        if (level_cislo == 5)//porovnavanie
        {
            if (priklad_cislo == 1)
            {
                Odpoved_bg.gameObject.SetActive(false);
                Odpoved_bg2.gameObject.SetActive(true);
                //Pomocny1_text.gameObject.SetActive(false);
                //Pomocny2_text.gameObject.SetActive(false);
                X1_ciarka.gameObject.SetActive(false);
                X2_ciarka.gameObject.SetActive(false);
                X3_ciarka.gameObject.SetActive(false);
                //Debug.Log("prvy priklad 5lvl");
                nastav_priklad("4", "5", "?", "6", "7", "<", "", ">", "", "=", "");
                spravna_odpoved = 1; //1 je A, 2 je B, 3 je C
            }
            if (priklad_cislo == 2)
            {
                nastav_priklad("8", "7", "?", "5", "4", "<", "", ">", "", "=", "");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 3)
            {
                nastav_priklad("7", "6", "?", "1", "2", "<", "", ">", "", "=", "");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 4)
            {
                nastav_priklad("33", "22", "?", "45", "67", "<", "", ">", "", "=", "");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 5)
            {
                nastav_priklad("19", "6", "?", "57", "18", "<", "", ">", "", "=", "");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 6)
            {
                nastav_priklad("55", "5", "?", "44", "4", "<", "", ">", "", "=", "");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 7)
            {
                nastav_priklad("28", "8", "?", "32", "12", "<", "", ">", "", "=", "");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 8)
            {
                nastav_priklad("15", "16", "?", "14", "11", "<", "", ">", "", "=", "");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 9)
            {
                nastav_priklad("3", "6", "?", "6", "12", "<", "", ">", "", "=", "");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 10)
            {
                nastav_priklad("12", "15", "?", "19", "22", "<", "", ">", "", "=", "");
                spravna_odpoved = 1;
            }
        }
    }

    void listok_enable()
    {
        Cas_zostava.cas_uplynul = false;
        vybrana_odpoved = 4; //aby sa vynulovala odpoved po potvrdeni //doriesit 
        //odpoved.text = string.Format("{0}", ""); // vynulujeme odpoved //doriesit
        priklad_cislo++;
        spravne_odpovede();
        //Cas_zostava.timeLeft = cas_dlzka;
        //Cas_zostava.timerIsRunning = true;
        if (priklad_cislo == 11) // po prejdeny vsetkych prikladov sa hra vypne, zatial
        {
            score_vyhodnotenie();
        }
    }

    public void vyber_odpoved1()
    {
        vybrana_odpoved = 1;
        //odpoved.text = string.Format("{0}", "A");
        X_1A.gameObject.SetActive(true);
        X_2A.gameObject.SetActive(false);
        X_3A.gameObject.SetActive(false);
        X1_Biely.gameObject.SetActive(false);
        X1_Zlty.gameObject.SetActive(true);
        X2_Zlty.gameObject.SetActive(false);
        X2_Biely.gameObject.SetActive(true);
        X3_Zlty.gameObject.SetActive(false);
        X3_Biely.gameObject.SetActive(true);
    }

    public void vyber_odpoved2()
    {
        vybrana_odpoved = 2;
        //odpoved.text = string.Format("{0}", "B");
        X_1A.gameObject.SetActive(false);
        X_2A.gameObject.SetActive(true);
        X_3A.gameObject.SetActive(false);
        X1_Biely.gameObject.SetActive(true);
        X1_Zlty.gameObject.SetActive(false);
        X2_Zlty.gameObject.SetActive(true);
        X2_Biely.gameObject.SetActive(false);
        X3_Zlty.gameObject.SetActive(false);
        X3_Biely.gameObject.SetActive(true);
    }

    public void vyber_odpoved3()
    {
        vybrana_odpoved = 3;
        //odpoved.text = string.Format("{0}", "C");
        X_1A.gameObject.SetActive(false);
        X_2A.gameObject.SetActive(false);
        X_3A.gameObject.SetActive(true);
        X1_Biely.gameObject.SetActive(true);
        X1_Zlty.gameObject.SetActive(false);
        X2_Zlty.gameObject.SetActive(false);
        X2_Biely.gameObject.SetActive(true);
        X3_Zlty.gameObject.SetActive(true);
        X3_Biely.gameObject.SetActive(false);
    }

    public void update_score()
    {
        score.text = string.Format("{0}", act_score);
        int temp = priklad_cislo+1;
        poradie.text = string.Format("{0}", temp);
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
                    X1_Zlty.gameObject.SetActive(false);
                }
                else if (vybrana_odpoved == 2 && spravna_odpoved == 2)
                {
                    act_score++;
                    Fajka.gameObject.SetActive(true);
                    X2_Zlty.gameObject.SetActive(false);
                }
                else if (vybrana_odpoved == 3 && spravna_odpoved == 3)
                {
                    act_score++;
                    Fajka.gameObject.SetActive(true);
                    X3_Zlty.gameObject.SetActive(false);
                }
                else
                {
                    act_bad++;
                    Xko.gameObject.SetActive(true);
                }

                if (spravna_odpoved == 1)
                {
                    X1_Zeleny.gameObject.SetActive(true);
                    X2_Biely.gameObject.SetActive(false);
                    X3_Biely.gameObject.SetActive(false);
                    X2_Cerveny.gameObject.SetActive(true);
                    X3_Cerveny.gameObject.SetActive(true);
                }
                else if (spravna_odpoved == 2)
                {
                    X2_Zeleny.gameObject.SetActive(true);
                    X1_Biely.gameObject.SetActive(false);
                    X3_Biely.gameObject.SetActive(false);
                    X1_Cerveny.gameObject.SetActive(true);
                    X3_Cerveny.gameObject.SetActive(true);
                }
                else if (spravna_odpoved == 3)
                {
                    X3_Zeleny.gameObject.SetActive(true);
                    X1_Biely.gameObject.SetActive(false);
                    X1_Biely.gameObject.SetActive(false);
                    X1_Cerveny.gameObject.SetActive(true);
                    X2_Cerveny.gameObject.SetActive(true);
                }
            }
        }
        else if (potvrdit_click == 1)
        {
            potvrdit_click = 0;
            vybrana_odpoved = 4; //aby sa vynulovala odpoved po potvrdeni

            potvrdit_click = 0;
            vybrana_odpoved = 4; //aby sa vynulovala odpoved po potvrdeni

            X1_Biely.gameObject.SetActive(true);
            X2_Biely.gameObject.SetActive(true);
            X3_Biely.gameObject.SetActive(true);

            X1_Cerveny.gameObject.SetActive(false);
            X2_Cerveny.gameObject.SetActive(false);
            X3_Cerveny.gameObject.SetActive(false);

            X1_Zeleny.gameObject.SetActive(false);
            X2_Zeleny.gameObject.SetActive(false);
            X3_Zeleny.gameObject.SetActive(false);

            X_1A.gameObject.SetActive(false);
            X_2A.gameObject.SetActive(false);
            X_3A.gameObject.SetActive(false);

            Fajka.gameObject.SetActive(false);
            Xko.gameObject.SetActive(false);
            update_score();
            listok_enable();
            //odpoved.text = string.Format("{0}", ""); // vynulujeme odpoved
        }
    }

    public void score_vyhodnotenie()
    {
        hernycanvas.gameObject.SetActive(false);
        scorecanvas.gameObject.SetActive(true);
        score_finish.text = string.Format("{0}", act_score);
        score_finish_max.text = string.Format("{0}", "10");
        if (act_score == 10)
        {
            scorecanvas.gameObject.SetActive(false);
            scoretopcanvas.gameObject.SetActive(true);
        }
    }

    public void ok_canvastop()
    {
        scoretopcanvas.gameObject.SetActive(false);
        scorecanvas.gameObject.SetActive(true);
    }

    public void QuitGame() //doriesit vyresetovanie hry NEJDE !
    {
        SceneManager.LoadScene("Menu");
        //Debug.Log("quit game");
    }

    // Start is called before the first frame update
    void Start()
    {
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
            //score_vyhodnotenie();
            priklad_cislo = 10;
        }
    }
}
