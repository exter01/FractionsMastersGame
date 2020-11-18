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
    public GameObject listok1, listok2, listok3, listok4, Save_Diskette; // vyberame objekty
    public Sprite P1_o0, P1_o1, P1_o2, P1_o3, P2_o0, P2_o1, P2_o2, P2_o3, P3_o0, P3_o1, P3_o2, P3_o3, P4_o0, P4_o1, P4_o2, P4_o3, P5_o0, P5_o1, P5_o2, P5_o3;
    public Sprite P6_o0, P6_o1, P6_o2, P6_o3, P7_o0, P7_o1, P7_o2, P7_o3, P8_o0, P8_o1, P8_o2, P8_o3, P9_o0, P9_o1, P9_o2, P9_o3, P10_o0, P10_o1, P10_o2, P10_o3;
    public Image B_Zadanie, B_Odp1, B_Odp2, B_Odp3;
    public VideoPlayer saving_video, loading_video;
    public GameObject Vysv_button_next, Vysv1_1, Vysv1_2, Vysv2_1, Vysv2_2, Vysv3_1, Vysv3_2;
   
    public void spravne_odpovede()
    {
        if(priklad_cislo == 1)
        {
            B_Zadanie.sprite = P1_o0;
            B_Odp1.sprite = P1_o1;
            B_Odp2.sprite = P1_o2;
            B_Odp3.sprite = P1_o3;
            spravna_odpoved = 1;
        }
        if (priklad_cislo == 2)
        {
            B_Zadanie.sprite = P2_o0;
            B_Odp1.sprite = P2_o1;
            B_Odp2.sprite = P2_o2;
            B_Odp3.sprite = P2_o3;
            spravna_odpoved = 2;
        }
        if (priklad_cislo == 3)
        {
            B_Zadanie.sprite = P3_o0;
            B_Odp1.sprite = P3_o1;
            B_Odp2.sprite = P3_o2;
            B_Odp3.sprite = P3_o3;
            spravna_odpoved = 3;
        }
        if (priklad_cislo == 4)
        {
            B_Zadanie.sprite = P4_o0;
            B_Odp1.sprite = P4_o1;
            B_Odp2.sprite = P4_o2;
            B_Odp3.sprite = P4_o3;
            spravna_odpoved = 2;
        }
        /*if (priklad_cislo == 5) //TOTO UPRAV MATUS
        {
            B_Zadanie.sprite = P4_o0;
            B_Odp1.sprite = P4_o1;
            B_Odp2.sprite = P4_o2;
            B_Odp3.sprite = P4_o3;
            spravna_odpoved = 2;
        }
        if (priklad_cislo == 6)
        {
            B_Zadanie.sprite = P4_o0;
            B_Odp1.sprite = P4_o1;
            B_Odp2.sprite = P4_o2;
            B_Odp3.sprite = P4_o3;
            spravna_odpoved = 2;
        }
        if (priklad_cislo == 7)
        {
            B_Zadanie.sprite = P4_o0;
            B_Odp1.sprite = P4_o1;
            B_Odp2.sprite = P4_o2;
            B_Odp3.sprite = P4_o3;
            spravna_odpoved = 2;
        }
        if (priklad_cislo == 8)
        {
            B_Zadanie.sprite = P4_o0;
            B_Odp1.sprite = P4_o1;
            B_Odp2.sprite = P4_o2;
            B_Odp3.sprite = P4_o3;
            spravna_odpoved = 2;
        }
        if (priklad_cislo == 9)
        {
            B_Zadanie.sprite = P4_o0;
            B_Odp1.sprite = P4_o1;
            B_Odp2.sprite = P4_o2;
            B_Odp3.sprite = P4_o3;
            spravna_odpoved = 2;
        }
        if (priklad_cislo == 10)
        {
            B_Zadanie.sprite = P10_o0;
            B_Odp1.sprite = P10_o1;
            B_Odp2.sprite = P10_o2;
            B_Odp3.sprite = P10_o3;
            spravna_odpoved = 1;
            Cas_zostava.cas_uplynul = true; // po poslednom priklade zobrazime disketu
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
        listok4.SetActive(true);
        Cas_zostava.timerIsRunning = true;
        Cas_zostava.timeLeft = 21f;//ukazuje time - 1
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
        priklad_cislo++;
        hernycanvas.gameObject.SetActive(false);
        Hojdacka.SetActive(false);
        Player.SetActive(false);
        otazkovycanvas.gameObject.SetActive(true);
        listok++;
        spravne_odpovede();
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
    }

    public void vyber_odpoved2()
    {
        vybrana_odpoved = 2;
        odpoved.text = string.Format("{0}", "B");
    }

    public void vyber_odpoved3()
    {
        vybrana_odpoved = 3;
        odpoved.text = string.Format("{0}", "C");
    }

    public void update_score()
    {
        score.text = string.Format("{0}", act_score);
    }

    public void zobraz_save_diskette()//doriesit aby sa to nepustalo dokola
    {
        GameObject[] listky;
        Save_Diskette.SetActive(true);
        listky = GameObject.FindGameObjectsWithTag("Listok");
        foreach (GameObject listek in listky)
        {
            Destroy(listek);//listky prec !
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
        if (vybrana_odpoved != 4)
        {
            if (vybrana_odpoved == 1 && spravna_odpoved == 1 || vybrana_odpoved == 2 && spravna_odpoved == 2 || vybrana_odpoved == 3 && spravna_odpoved == 3)
            {
                act_score++;
            }
            else
            {
                //bomb++;
            }
            update_score();
            listok_disable();
            //Debug.Log(vybrana_odpoved);
            vybrana_odpoved = 4; //aby sa vynulovala odpoved po potvrdeni
            odpoved.text = string.Format("{0}", ""); // vynulujeme odpoved
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        saving_video.loopPointReached += EndReached;
        loading_video.loopPointReached += EndReached2;
        Playername.text = playernamestr; //meno hraca z menu
        listok1.SetActive(false);
        listok2.SetActive(false);
        listok3.SetActive(false);
        listok4.SetActive(false);
        update_score();//aby sa nastavilo score na 0
        Save_Diskette.SetActive(false);
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

        if (listok == 1 || listok == 4 || listok == 7 || listok == 10)
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
