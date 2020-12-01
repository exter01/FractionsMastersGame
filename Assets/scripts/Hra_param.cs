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

    //meno hraca z menu
    public static string playernamestr;
    public TMP_Text Playername;
    //koniec

    public TMP_Text odpoved; // vybrana odpoved
    public TMP_Text score; // zobrazene skore
    public static int kolocislo = 0;
    public static int pocetlistkov = 0;
    public static bool vysvetlovanie_show = false;
    public static int listok = 0; //1-show,2-showed,3-hide atd
    public static int vybrana_odpoved = 4, spravna_odpoved = 4; //v zaklade 4, aby nebola ziadna
    public static int priklad_cislo = 0;
    public static int act_score = 0;
    public static bool touch_save_diskette = false; // ked sa dotkne postavicka cez collider
    public static bool prebehlo_vysvetlovanie = false;
    public static bool vysvetlujeme = false;
    public CanvasGroup hernycanvas, otazkovycanvas, vysvetlovaniecanvas, savingcanvas, loadingcanvas;
    public GameObject listok1, listok2, listok3, listok4, listok5, listok6, listok7, listok8, listok9, listok10, Save_Diskette;
    public VideoPlayer saving_video, loading_video;
    public GameObject Vysv_button_next, Vysv1_1, Vysv1_2, Vysv2_1, Vysv2_2, Vysv3_1, Vysv3_2;
    public GameObject Xko, Fajka, Xko_1, Xko_2, Xko_3;
    public TMP_Text Zadanie_1, Zadanie_2, Zadanie_3, Zadanie_4, Zadanie_5;
    public TMP_Text A_1, A_2, B_1, B_2, C_1, C_2;
    public GameObject X_1A, X_2A, X_3A, X_1X, X_2X, X_3X, X_1Y, X_2Y, X_3Y;

    public static int potvrdit_click = 0; //pri odpovedach je dva krat button odpoved
    public static int pocet_zobraz_list = 0;

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
        if(priklad_cislo == 1)
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
        /*if (priklad_cislo == 11)
        {
            nastav_priklad("4", "8", "+", "7", "9", "93", "72", "23", "18", "11", "17");
            spravna_odpoved = 2;
        }*/
    }

    void vysvetlovanie_enable()
    {
        prebehlo_vysvetlovanie = true;
        vysvetlovanie_show = false;
        vysvetlujeme = true;
        hernycanvas.gameObject.SetActive(false);
        Hojdacka.SetActive(false);
        Player.SetActive(false);
        vysvetlovaniecanvas.gameObject.SetActive(true);
        Vysvetlovanie_casovac.timerIsRunning = true;
        Vysvetlovanie_casovac.cas_uplynul = false;
        Vysvetlovanie_casovac.timeLeft = 2f;
    }

    void vysvetlovanie_zobraz(int vysv_faza)
    {
        if(vysv_faza == 1)
        {
            Vysvetlovanie_casovac.cas_uplynul = false;
            Vysv1_1.gameObject.SetActive(false);
            Vysv1_2.gameObject.SetActive(true);
            Vysv_button_next.gameObject.SetActive(true);
        }
        if(vysv_faza == 2)
        {
            Vysv1_2.gameObject.SetActive(false);
            Vysv2_1.gameObject.SetActive(true);
            Vysvetlovanie_casovac.timerIsRunning = true;
            Vysvetlovanie_casovac.cas_uplynul = false;
            Vysvetlovanie_casovac.timeLeft = 2f;
        }
        if (vysv_faza == 3)
        {
            Vysvetlovanie_casovac.cas_uplynul = false;
            Vysv2_1.gameObject.SetActive(false);
            Vysv2_2.gameObject.SetActive(true);
            Vysv_button_next.gameObject.SetActive(true);
        }
        if (vysv_faza == 4)
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
    }

    public void vysvetlovanie_next_but()
    {
        vysv_faza++;
        vysvetlovanie_zobraz(vysv_faza);
        Vysv_button_next.gameObject.SetActive(false);
        if(vysv_faza == 6)
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
        listok1.SetActive(true);
        listok2.SetActive(true);
        listok3.SetActive(true);
        Cas_zostava.timerIsRunning = true;
        Cas_zostava.timeLeft = 151f;//ukazuje time - 1
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
            listok4.gameObject.SetActive(true);
            listok5.gameObject.SetActive(true);
            listok6.gameObject.SetActive(true);
            listok7.gameObject.SetActive(true);
        }
        if (pocet_zobraz_list == 7)
        {
            listok8.gameObject.SetActive(true);
            listok9.gameObject.SetActive(true);
            listok10.gameObject.SetActive(true);
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

    public void zobraz_save_diskette()//doriesit aby sa to nepustalo dokola
    {
        GameObject[] listky;
        Save_Diskette.gameObject.SetActive(true);
        listky = GameObject.FindGameObjectsWithTag("Listok");
        foreach (GameObject listek in listky)
        {
            listek.gameObject.SetActive(false);
        }
        tmp_pocet3++;
        if (tmp_pocet3 == 20)
        {
            Save_Diskette.transform.position = new Vector3(Save_Diskette.transform.position.x + 1, Save_Diskette.transform.position.y + 8, Save_Diskette.transform.position.z);
        }
        if (tmp_pocet3 == 40)
        {
            Save_Diskette.transform.position = new Vector3(Save_Diskette.transform.position.x - 1, Save_Diskette.transform.position.y - 8, Save_Diskette.transform.position.z);
            tmp_pocet3 = 0;
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

                if(spravna_odpoved == 1)
                {
                    //X_1Y.gameObject.SetActive(true);
                    X_2X.gameObject.SetActive(true);
                    X_3X.gameObject.SetActive(true);
                }else if(spravna_odpoved == 2)
                {
                    X_1X.gameObject.SetActive(true);
                   // X_2Y.gameObject.SetActive(true);
                    X_3X.gameObject.SetActive(true);
                }
                else if(spravna_odpoved == 3)
                {
                    X_1X.gameObject.SetActive(true);
                    X_2X.gameObject.SetActive(true);
                   // X_3Y.gameObject.SetActive(true);
                }
            }
        }
        else if(potvrdit_click == 1)
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
            listok_disable();
            //Debug.Log(vybrana_odpoved);
            odpoved.text = string.Format("{0}", ""); // vynulujeme odpoved
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        saving_video.loopPointReached += EndReached;
        loading_video.loopPointReached += EndReached2;
        Playername.text = playernamestr; //meno hraca z menu
        update_score();//aby sa nastavilo score na 0
        //loading_video.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Menu");
    }

    void EndReached2(UnityEngine.Video.VideoPlayer vp)
    {
        loadingcanvas.gameObject.SetActive(false);
        hernycanvas.gameObject.SetActive(true);
        Hojdacka.SetActive(true);
        Player.SetActive(true);
    }

    public void QuitGame() //doriesit vyresetovanie hry NEJDE !
    {
        SceneManager.LoadScene("Menu");
    }

    private int tmp_pocet = 0, tmp_pocet3 = 0;
    private int vysv_faza = 0;
    // Update is called once per frame
    void Update()
    {
        if(prebehlo_vysvetlovanie == false)//podskakovanie krala
        {
            tmp_pocet++;
            if (tmp_pocet == 20)
            {
                Kral.transform.position = new Vector3(Kral.transform.position.x+1, Kral.transform.position.y + 14, Kral.transform.position.z);
            }
            if (tmp_pocet == 40)
            {
                Kral.transform.position = new Vector3(Kral.transform.position.x-1, Kral.transform.position.y - 14, Kral.transform.position.z);
                tmp_pocet = 0;
            }
        }
        
        if (vysvetlovanie_show == true)//ci sa ma zobrazit vysvetlovanie
        {
            vysvetlovanie_enable();
        }

        if(vysvetlujeme == true)
        {
            if(Vysvetlovanie_casovac.cas_uplynul == true)
            {
                vysv_faza++;
                vysvetlovanie_zobraz(vysv_faza);
                Debug.Log(vysv_faza);
            }
        }

        if (listok == 1 || listok == 4 || listok == 7 || listok == 10 || listok == 13 || listok == 16 || listok == 19 || listok == 22 || listok == 25 || listok == 28)
        {
            listok_enable();
        }

        if(touch_save_diskette == true)
        {
            touch_save_diskette = false;
            saving_enable();
        }

        if (Cas_zostava.cas_uplynul == true)
        {
            zobraz_save_diskette();
        }
    }
}
