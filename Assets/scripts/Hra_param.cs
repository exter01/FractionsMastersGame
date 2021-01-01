using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class Hra_param : MonoBehaviour
{
    public GameObject Player, Kral, Hojdacka;
    public static string playernamestr;//meno hraca z menu
    public TMP_Text Playername;//meno hraca z menu
    public static int CELKOVESKORE = 0, CELKOVESKORE_MAX = 0, aktualny_level;//sucet skore medzi levelmi, aktualny level
    public VideoPlayer saving_video;
    public TMP_Text poradie;
    public TMP_Text odpoved, score; // zobrazene skore
    public TMP_Text vyhodnotenie_score, vyhodnotenie_max_score, vyhodnotenie_max_score2, vyhodnotenie_score2;
    public CanvasGroup hernycanvas, otazkovycanvas, vysvetlovaniecanvas, savingcanvas, loadingcanvas, vyhodnoteniecanvas;
    public GameObject listok1, listok2, listok3, listok4, listok5, listok6, listok7, listok8, listok9, listok10, Save_Diskette;
    public GameObject listok11, listok12, listok13, listok14, listok15, listok16, listok17, listok18, listok19, listok20; //level 2
    public GameObject listok21, listok22, listok23, listok24, listok25, listok26, listok27, listok28, listok29, listok30; //level 3
    //public GameObject listok31, listok32, listok33, listok34, listok35, listok36, listok37, listok38, listok39, listok40; //level 4
    //public GameObject listok41, listok42, listok43, listok44, listok45, listok46, listok47, listok48, listok49, listok50; //level 5
    public GameObject Vysv_button_next, Vysv1_1, Vysv1_2, Vysv2_1, Vysv2_2, Vysv3_1, Vysv3_2, Vysv4_1, Vysv4_2, Vysv5_1, Vysv5_2;
    public GameObject Vysv2_1_1, Vysv2_1_2, Vysv2_2_1, Vysv2_2_2; //level 2
    public GameObject Vysv3_1_1, Vysv3_1_2, Vysv3_2_1, Vysv3_2_2, Vysv3_3_1, Vysv3_3_2; //level 3
    public GameObject Vysv4_1_1, Vysv4_1_2, Vysv4_2_1, Vysv4_2_2; //level 4
    public GameObject Vysv5_1_1, Vysv5_1_2, Vysv5_2_1, Vysv5_2_2; //level 5

    //odpoved
    public GameObject Xko, Fajka, X_1A, X_2A, X_3A;
    public TMP_Text Zadanie_1, Zadanie_2, Zadanie_3, Zadanie_4, Zadanie_5, A_1, A_2, B_1, B_2, C_1, C_2;
    public GameObject X1_Biely, X1_Zlty, X1_Cerveny, X1_Zeleny, X2_Biely, X2_Zlty, X2_Cerveny, X2_Zeleny, X3_Biely, X3_Zlty, X3_Cerveny, X3_Zeleny;
    //odpoved porovnavanie
    public GameObject Odpoved_bg, Odpoved_bg2, Pomocny1_text, Pomocny2_text, X1_ciarka, X2_ciarka, X3_ciarka;
    //end porovnavanie
    //end odpoved

    public static bool touch_kral, touch_save_diskette; //po dotknuti krala, diskety true cez playercontroller
    public static int listok; //1-show,2-showed,3-hide atd
    public static int vybrana_odpoved, spravna_odpoved; //v zaklade 4, aby nebola ziadna
    public static int priklad_cislo, act_score, kolocislo, pocetlistkov, pocet_zobraz_list;
    public static int potvrdit_click; //pri odpovedach je dva krat button odpoved
    public static bool prebehlo_vysvetlovanie;
    public static bool vysvetlujeme;
    private int vysv_faza;
    private int counter_move_obj, counter_move_obj2; //podskakovanie krala, diskety

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
        if(aktualny_level == 1)//scitanie
        {
            if (priklad_cislo == 1)
            {
                nastav_priklad("1", "2", "+", "1", "3", "5", "6", "3", "4", "2", "5");
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
                Cas_zostava.cas_uplynul = true; // po poslednom priklade zobrazime disketu
            }
        }

        if(aktualny_level == 2)//odcitanie
        {
            if (priklad_cislo == 1)
            {
                Debug.Log("prvy priklad 2lvl");
                nastav_priklad("2", "3", "-", "1", "2", "3", "6", "1", "6", "4", "6");
                spravna_odpoved = 2; //1 je A, 2 je B, 3 je C
            }
            if (priklad_cislo == 2)
            {
                nastav_priklad("7", "6", "-", "4", "6", "4", "6", "3", "2", "1", "2");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 3)
            {
                nastav_priklad("4", "5", "-", "6", "8", "2", "20", "1", "20", "2", "3");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 4)
            {
                nastav_priklad("6", "5", "-", "4", "6", "9", "15", "8", "15", "2", "15");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 5)
            {
                nastav_priklad("8", "10", "-", "5", "9", "3", "1", "3", "45", "11", "45");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 6)
            {
                nastav_priklad("7", "15", "-", "2", "10", "4", "15", "5", "15", "3", "15");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 7)
            {
                nastav_priklad("8", "8", "-", "5", "6", "1", "6", "3", "6", "4", "6");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 8)
            {
                nastav_priklad("21", "4", "-", "15", "4", "2", "3", "6", "4", "6", "3");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 9)
            {
                nastav_priklad("31", "8", "-", "11", "4", "20", "4", "20", "8", "9", "8");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 10)
            {
                nastav_priklad("20", "5", "-", "15", "5", "5", "5", "1", "5", "10", "5");
                spravna_odpoved = 1;
                Cas_zostava.cas_uplynul = true; // po poslednom priklade zobrazime disketu
            }
        }

        if(aktualny_level == 3)//nasobenie
        {
            if (priklad_cislo == 1)
            {
                Debug.Log("prvy priklad 3lvl");
                nastav_priklad("9", "4", "*", "2", "3", "3", "2", "4", "2", "6", "2");
                spravna_odpoved = 1; //1 je A, 2 je B, 3 je C
            }
            if (priklad_cislo == 2)
            {
                nastav_priklad("8", "3", "*", "9", "10", "12", "5", "72", "5", "24", "5");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 3)
            {
                nastav_priklad("12", "5", "*", "6", "8", "9", "5", "12", "5", "8", "5");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 4)
            {
                nastav_priklad("9", "7", "*", "10", "4", "12", "14", "40", "14", "45", "14");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 5)
            {
                nastav_priklad("4", "3", "*", "5", "6", "20", "9", "10", "9", "12", "9");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 6)
            {
                nastav_priklad("8", "11", "*", "14", "12", "22", "33", "25", "33", "28", "33");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 7)
            {
                nastav_priklad("3", "2", "*", "2", "4", "6", "4", "3", "4", "4", "4");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 8)
            {
                nastav_priklad("5", "5", "*", "6", "7", "8", "7", "6", "7", "14", "7");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 9)
            {
                nastav_priklad("19", "9", "*", "24", "12", "33", "9", "38", "9", "40", "9");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 10)
            {
                nastav_priklad("1", "2", "*", "5", "8", "10", "16", "8", "16", "5", "16");
                spravna_odpoved = 3;
                Cas_zostava.cas_uplynul = true; // po poslednom priklade zobrazime disketu
            }
        }

        if (aktualny_level == 4)//delenie
        {
            if (priklad_cislo == 1)
            {
                Debug.Log("prvy priklad 4lvl");
                nastav_priklad("1", "2", ":", "3", "4", "3", "3", "2", "3", "4", "3");
                spravna_odpoved = 2; //1 je A, 2 je B, 3 je C
            }
            if (priklad_cislo == 2)
            {
                nastav_priklad("4", "7", ":", "5", "8", "30", "35", "20", "35", "32", "35");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 3)
            {
                nastav_priklad("3", "4", ":", "5", "6", "12", "10", "7", "10", "9", "10");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 4)
            {
                nastav_priklad("10", "9", ":", "5", "4", "8", "9", "6", "9", "12", "9");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 5)
            {
                nastav_priklad("13", "2", ":", "8", "2", "13", "8", "15", "8", "12", "8");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 6)
            {
                nastav_priklad("7", "5", ":", "12", "9", "20", "21", "21", "20", "22", "20");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 7)
            {
                nastav_priklad("8", "4", ":", "8", "3", "2", "4", "5", "4", "3", "4");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 8)
            {
                nastav_priklad("5", "8", ":", "10", "6", "5", "4", "2", "8", "3", "8");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 9)
            {
                nastav_priklad("6", "9", ":", "15", "5", "6", "9", "2", "9", "4", "9");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 10)
            {
                nastav_priklad("3", "1", ":", "11", "3", "9", "11", "18", "11", "13", "11");
                spravna_odpoved = 1;
                Cas_zostava.cas_uplynul = true; // po poslednom priklade zobrazime disketu
            }
        }

        if (aktualny_level == 5)//porovnavanie
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
                Debug.Log("prvy priklad 5lvl");
                nastav_priklad("6", "2", "", "4", "5", "<", "", ">", "", "=", "");
                spravna_odpoved = 2; //1 je A, 2 je B, 3 je C
            }
            if (priklad_cislo == 2)
            {
                nastav_priklad("12", "9", "", "7", "5", "<", "", ">", "", "=", "");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 3)
            {
                nastav_priklad("4", "5", "", "8", "10", "<", "", ">", "", "=", "");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 4)
            {
                nastav_priklad("98", "43", "", "54", "68", "<", "", ">", "", "=", "");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 5)
            {
                nastav_priklad("15", "4", "", "12", "8", "<", "", ">", "", "=", "");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 6)
            {
                nastav_priklad("24", "11", "", "5", "4", "<", "", ">", "", "=", "");
                spravna_odpoved = 2;
            }
            if (priklad_cislo == 7)
            {
                nastav_priklad("3", "9", "", "6", "18", "<", "", ">", "", "=", "");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 8)
            {
                nastav_priklad("7", "5", "", "33", "12", "<", "", ">", "", "=", "");
                spravna_odpoved = 1;
            }
            if (priklad_cislo == 9)
            {
                nastav_priklad("13", "6", "", "39", "18", "<", "", ">", "", "=", "");
                spravna_odpoved = 3;
            }
            if (priklad_cislo == 10)
            {
                nastav_priklad("9", "8", "", "8", "9", "<", "", ">", "", "=", "");
                spravna_odpoved = 2;
                Cas_zostava.cas_uplynul = true; // po poslednom priklade zobrazime disketu
            }
        }
}

    void vysvetlovanie_enable()
    {
        prebehlo_vysvetlovanie = true;
        touch_kral = false;
        vysvetlujeme = true;
        hernycanvas.gameObject.SetActive(false);
        Hojdacka.SetActive(false);
        Player.SetActive(false);
        vysvetlovaniecanvas.gameObject.SetActive(true);
        vysvetlovanie_zobraz(vysv_faza);
    }

    void vysvetlovanie_zobraz(int vysv_faza)
    {
        if(aktualny_level == 1)
        {
            if (vysv_faza == 0)
            {
                Vysv1_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 1)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv1_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            if(vysv_faza == 2)
            {
                Vysv1_1.gameObject.SetActive(false);
                Vysv1_2.gameObject.SetActive(false);
                Vysv2_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 3)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv2_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            if (vysv_faza == 4)
            {
                Vysv2_1.gameObject.SetActive(false);
                Vysv2_2.gameObject.SetActive(false);
                Vysv3_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 5)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv3_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            if (vysv_faza == 6)
            {
                Vysv3_1.gameObject.SetActive(false);
                Vysv3_2.gameObject.SetActive(false);
                Vysv4_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 7)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv4_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            if (vysv_faza == 8)
            {
                Vysv4_1.gameObject.SetActive(false);
                Vysv4_2.gameObject.SetActive(false);
                Vysv5_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 9)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv5_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
        }

        if (aktualny_level == 2)//odcitanie
        {
            if(vysv_faza == 0)
            {
                Vysv2_1_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 1)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv2_1_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            if (vysv_faza == 2)
            {
                Vysv2_1_1.gameObject.SetActive(false);
                Vysv2_1_2.gameObject.SetActive(false);
                Vysv2_2_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 3)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv2_2_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            /*if (vysv_faza == 4)
            {
                Vysv2_2.gameObject.SetActive(false);
                Vysv3_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 5)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv3_1.gameObject.SetActive(false);
                Vysv3_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            if (vysv_faza == 6)
            {
                Vysv3_2.gameObject.SetActive(false);
                Vysv4_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 7)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv4_1.gameObject.SetActive(false);
                Vysv4_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            if (vysv_faza == 8)
            {
                Vysv4_2.gameObject.SetActive(false);
                Vysv5_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 9)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv5_1.gameObject.SetActive(false);
                Vysv5_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }*/
        }

        if (aktualny_level == 3)//nasobenie
        {
            if (vysv_faza == 0)
            {
                Vysv3_1_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 1)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv3_1_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            if (vysv_faza == 2)
            {
                Vysv3_1_1.gameObject.SetActive(false);
                Vysv3_1_2.gameObject.SetActive(false);
                Vysv3_2_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 3)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv3_2_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            if (vysv_faza == 4)
            {
                Vysv3_2_1.gameObject.SetActive(false);
                Vysv3_2_2.gameObject.SetActive(false);
                Vysv3_3_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 5)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv3_3_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
        }

        if (aktualny_level == 4)//delenie
        {
            if (vysv_faza == 0)
            {
                Vysv4_1_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 1)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv4_1_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            if (vysv_faza == 2)
            {
                Vysv4_1_1.gameObject.SetActive(false);
                Vysv4_1_2.gameObject.SetActive(false);
                Vysv4_2_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 3)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv4_2_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            /*if (vysv_faza == 4)
            {
                Vysv3_2_1.gameObject.SetActive(false);
                Vysv3_2_2.gameObject.SetActive(false);
                Vysv3_3_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 5)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv3_3_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }*/
        }

        if (aktualny_level == 5)//porovnavanie
        {
            if (vysv_faza == 0)
            {
                Vysv5_1_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 1)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv5_1_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            if (vysv_faza == 2)
            {
                Vysv5_1_1.gameObject.SetActive(false);
                Vysv5_1_2.gameObject.SetActive(false);
                Vysv5_2_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 3)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv5_2_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }
            /*if (vysv_faza == 4)
            {
                Vysv3_2_1.gameObject.SetActive(false);
                Vysv3_2_2.gameObject.SetActive(false);
                Vysv3_3_1.gameObject.SetActive(true);
                Vysvetlovanie_casovac.timerIsRunning = true;
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysvetlovanie_casovac.timeLeft = 2f;
            }
            if (vysv_faza == 5)
            {
                Vysvetlovanie_casovac.cas_uplynul = false;
                Vysv3_3_2.gameObject.SetActive(true);
                Vysv_button_next.gameObject.SetActive(true);
            }*/
        }

        if (aktualny_level == 6)
        {
            if (vysv_faza == 0)
            {
                QuitGame();
            }
        }
    }

    public void vysvetlovanie_next_but()
    {
        vysv_faza++;
        vysvetlovanie_zobraz(vysv_faza);
        Vysv_button_next.gameObject.SetActive(false);
        if(aktualny_level == 1 && vysv_faza == 10)
        {
            vysvetlujeme = false;
            next_vysvetlovanie();
        }

        if (aktualny_level == 2 && vysv_faza == 4)
        {
            vysvetlujeme = false;
            next_vysvetlovanie();
        }

        if (aktualny_level == 3 && vysv_faza == 6)
        {
            vysvetlujeme = false;
            next_vysvetlovanie();
        }

        if (aktualny_level == 4 && vysv_faza == 4)
        {
            vysvetlujeme = false;
            next_vysvetlovanie();
        }

        if (aktualny_level == 5 && vysv_faza == 4)
        {
            vysvetlujeme = false;
            next_vysvetlovanie();
        }
    }

    public void next_vysvetlovanie()
    {
        vysvetlovaniecanvas.gameObject.SetActive(false);
        hernycanvas.gameObject.SetActive(true);
        Hojdacka.SetActive(true);
        Player.SetActive(true);
        if(aktualny_level == 1 || aktualny_level == 4)
        {
            listok1.SetActive(true);
            listok2.SetActive(true);
            listok3.SetActive(true);
        }
        if (aktualny_level == 2)
        {
            listok11.SetActive(true);
            listok12.SetActive(true);
            listok13.SetActive(true);
        }
        if (aktualny_level == 3 || aktualny_level == 5)
        {
            listok21.SetActive(true);
            listok22.SetActive(true);
            listok23.SetActive(true);
        }
        Cas_zostava.timerIsRunning = true;
        Cas_zostava.timeLeft = 151f;//ukazuje time - 1//ma byt 151 //cas levelu
    }

    void saving_enable()
    {
        hernycanvas.gameObject.SetActive(false);
        Hojdacka.SetActive(false);
        Player.SetActive(false);
        
        savingcanvas.gameObject.SetActive(true);
        saving_video.Play();
    }

    void listok_enable()
    {
        pocet_zobraz_list++;
        priklad_cislo++;
        hernycanvas.gameObject.SetActive(false);
        Hojdacka.SetActive(false);
        Player.SetActive(false);
        otazkovycanvas.gameObject.SetActive(true);
        listok++;
        spravne_odpovede();
        if(pocet_zobraz_list == 3)
        {
            if(aktualny_level == 1 || aktualny_level == 4)
            {
                listok4.gameObject.SetActive(true);
                listok5.gameObject.SetActive(true);
                listok6.gameObject.SetActive(true);
                listok7.gameObject.SetActive(true);
            }
            if (aktualny_level == 2)
            {
                listok14.gameObject.SetActive(true);
                listok15.gameObject.SetActive(true);
                listok16.gameObject.SetActive(true);
                listok17.gameObject.SetActive(true);
            }
            if (aktualny_level == 3 || aktualny_level == 5)
            {
                listok24.gameObject.SetActive(true);
                listok25.gameObject.SetActive(true);
                listok26.gameObject.SetActive(true);
                listok27.gameObject.SetActive(true);
            }
        }
        if (pocet_zobraz_list == 7)
        {
            if (aktualny_level == 1 || aktualny_level == 5)
            {
                listok8.gameObject.SetActive(true);
                listok9.gameObject.SetActive(true);
                listok10.gameObject.SetActive(true);
            }
            if (aktualny_level == 2 || aktualny_level == 4)
            {
                listok18.gameObject.SetActive(true);
                listok19.gameObject.SetActive(true);
                listok20.gameObject.SetActive(true);
            }
            if (aktualny_level == 3)
            {
                listok28.gameObject.SetActive(true);
                listok29.gameObject.SetActive(true);
                listok30.gameObject.SetActive(true);
            }
        }
    }

    void listok_disable()
    {
        Debug.Log(listok);
        otazkovycanvas.gameObject.SetActive(false);
        hernycanvas.gameObject.SetActive(true);
        Hojdacka.SetActive(true);
        Player.SetActive(true);
        listok++;
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
        int temp = priklad_cislo + 1;
        poradie.text = string.Format("{0}", temp);
    }

    public void zobraz_save_diskette()//doriesit aby sa to nepustalo dokola
    {
        GameObject[] listky;
        Save_Diskette.gameObject.SetActive(true);
        listky = GameObject.FindGameObjectsWithTag("Listok");
        foreach (GameObject listek in listky)
        {
            listek.gameObject.SetActive(false);
        }
        counter_move_obj2++;
        if (counter_move_obj2 == 15)
        {
            Save_Diskette.transform.position = new Vector3(Save_Diskette.transform.position.x + 1, Save_Diskette.transform.position.y + 8, Save_Diskette.transform.position.z);
        }
        if (counter_move_obj2 == 30)
        {
            Save_Diskette.transform.position = new Vector3(Save_Diskette.transform.position.x - 1, Save_Diskette.transform.position.y - 8, Save_Diskette.transform.position.z);
            counter_move_obj2 = 0;
        }
    }

    int counter_move_obj3 = 0;
    public void posun_listky()//doriesit aby sa to nepustalo dokola
    {
        GameObject[] listky;
        counter_move_obj3++;
        listky = GameObject.FindGameObjectsWithTag("Listok");
        
        
        if (counter_move_obj3 == 25)
        {
            foreach (GameObject listek in listky)
            {
                //listek.gameObject.SetActive(false);
                listek.transform.position = new Vector3(listek.transform.position.x + 1, listek.transform.position.y + 2, listek.transform.position.z);
            }
        }
        if (counter_move_obj3 == 50)
        {
            foreach (GameObject listek in listky)
            {
                //listek.gameObject.SetActive(false);
                listek.transform.position = new Vector3(listek.transform.position.x - 1, listek.transform.position.y - 2, listek.transform.position.z);
            }
            counter_move_obj3 = 0;
        }
    }

    public void Potvrdit_odpoved()
    {
        if(potvrdit_click == 0)
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
                    //bomb++;
                    Xko.gameObject.SetActive(true);
                }

                if(spravna_odpoved == 1)
                {
                    X1_Zeleny.gameObject.SetActive(true);
                    X2_Biely.gameObject.SetActive(false);
                    X3_Biely.gameObject.SetActive(false);
                    X2_Cerveny.gameObject.SetActive(true);
                    X3_Cerveny.gameObject.SetActive(true);
                }
                else if(spravna_odpoved == 2)
                {
                    X2_Zeleny.gameObject.SetActive(true);
                    X1_Biely.gameObject.SetActive(false);
                    X3_Biely.gameObject.SetActive(false);
                    X1_Cerveny.gameObject.SetActive(true);
                    X3_Cerveny.gameObject.SetActive(true);
                }
                else if(spravna_odpoved == 3)
                {
                    X3_Zeleny.gameObject.SetActive(true);
                    X1_Biely.gameObject.SetActive(false);
                    X1_Biely.gameObject.SetActive(false);
                    X1_Cerveny.gameObject.SetActive(true);
                    X2_Cerveny.gameObject.SetActive(true);
                }
            }
        }
        else if(potvrdit_click == 1)
        {
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
            listok_disable();
            //Debug.Log(vybrana_odpoved);
            odpoved.text = string.Format("{0}", ""); // vynulujeme odpoved
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        saving_video.url = System.IO.Path.Combine(Application.streamingAssetsPath, "beh_smer_hrad.mp4");
        touch_kral = false;
        listok = 0; //1-show,2-showed,3-hide atd
        vybrana_odpoved = 4;
        spravna_odpoved = 4; //v zaklade 4, aby nebola ziadna
        priklad_cislo = 0;
        act_score = 0;
        kolocislo = 0;
        pocetlistkov = 0;
        pocet_zobraz_list = 0;
        potvrdit_click = 0; //pri odpovedach je dva krat button odpoved
        touch_save_diskette = false; // ked sa dotkne postavicka cez collider
        prebehlo_vysvetlovanie = false;
        vysvetlujeme = false;
        counter_move_obj = 0;
        counter_move_obj2 = 0;
        vysv_faza = 0;
        saving_video.loopPointReached += EndReached;
        Playername.text = playernamestr; //meno hraca z menu
        update_score();//aby sa nastavilo score na 0
        //loading_video.Play();
        Debug.Log(aktualny_level);

        if(aktualny_level == 2)
        {
            Kral.transform.position = new Vector3(-130f,-270f, Kral.transform.position.z);
        }

        if (aktualny_level == 3)
        {
            Kral.transform.position = new Vector3(-100f, 68f, Kral.transform.position.z);
        }

        if (aktualny_level == 5)
        {
            Kral.transform.position = new Vector3(-110f, 68f, Kral.transform.position.z);
        }

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        CELKOVESKORE = CELKOVESKORE + act_score;
        aktualny_level++;
        CELKOVESKORE_MAX += 10;
        savingcanvas.gameObject.SetActive(false);
        vyhodnoteniecanvas.gameObject.SetActive(true);
        vyhodnotenie_score.text = string.Format("{0}", act_score);
        vyhodnotenie_max_score.text = string.Format("{0}", "10");
        vyhodnotenie_score2.text = string.Format("{0}", CELKOVESKORE);
        vyhodnotenie_max_score2.text = string.Format("{0}", CELKOVESKORE_MAX);
    }

    public void DalsiLevel()
    {
        SceneManager.LoadScene("Hra-loading");
    }

    /*void EndReached2(UnityEngine.Video.VideoPlayer vp)
    {
        loadingcanvas.gameObject.SetActive(false);
        hernycanvas.gameObject.SetActive(true);
        Hojdacka.SetActive(true);
        Player.SetActive(true);
    }*/

    public void QuitGame() //doriesit vyresetovanie hry NEJDE !
    {
        SceneManager.LoadScene("Menu");
    }

    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(aktualny_level);
        if (prebehlo_vysvetlovanie == false)//podskakovanie krala
        {
            counter_move_obj++;
            if (counter_move_obj == 15)
            {
                Kral.transform.position = new Vector3(Kral.transform.position.x+1, Kral.transform.position.y + 14, Kral.transform.position.z);
            }
            if (counter_move_obj == 30)
            {
                Kral.transform.position = new Vector3(Kral.transform.position.x-1, Kral.transform.position.y - 14, Kral.transform.position.z);
                counter_move_obj = 0;
            }
        }
        posun_listky();
        if (touch_kral == true)//ci sa ma zobrazit vysvetlovanie
        {
            vysvetlovanie_enable();
        }

        if (touch_save_diskette == true)//ci sa ma spustit ukladanie
        {
            touch_save_diskette = false;
            saving_enable();
        }

        if (Cas_zostava.cas_uplynul == true)//uplynul cas, schovane listky, zobrazime disketu
        {
            zobraz_save_diskette();
        }

        if (vysvetlujeme == true)
        {
            if(Vysvetlovanie_casovac.cas_uplynul == true)
            {
                vysv_faza++;
                vysvetlovanie_zobraz(vysv_faza);
                //Debug.Log(vysv_faza);
            }
        }

        if (listok == 1 || listok == 4 || listok == 7 || listok == 10 || listok == 13 || listok == 16 || listok == 19 || listok == 22 || listok == 25 || listok == 28)
        {
            listok_enable();
        }   
    }
}
