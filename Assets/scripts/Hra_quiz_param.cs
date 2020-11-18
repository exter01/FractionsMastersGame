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
    public static int vybrana_odpoved = 4;
    public static int spravna_odpoved = 4;
    public static int priklad_cislo = 0;
    public static int act_score = 0;
    public static float cas_dlzka = 2f; //cas na vyber moznosti
    public Sprite P1_o0, P1_o1, P1_o2, P1_o3, P2_o0, P2_o1, P2_o2, P2_o3, P3_o0, P3_o1, P3_o2, P3_o3, P4_o0, P4_o1, P4_o2, P4_o3, P5_o0, P5_o1, P5_o2, P5_o3;
    public Sprite P6_o0, P6_o1, P6_o2, P6_o3, P7_o0, P7_o1, P7_o2, P7_o3, P8_o0, P8_o1, P8_o2, P8_o3, P9_o0, P9_o1, P9_o2, P9_o3, P10_o0, P10_o1, P10_o2, P10_o3;
    public Image B_Zadanie, B_Odp1, B_Odp2, B_Odp3;

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
            spravna_odpoved = 3;
        }
        if (priklad_cislo == 3)
        {
            B_Zadanie.sprite = P3_o0;
            B_Odp1.sprite = P3_o1;
            B_Odp2.sprite = P3_o2;
            B_Odp3.sprite = P3_o3;
            spravna_odpoved = 1;
        }
        if (priklad_cislo == 4)
        {
            B_Zadanie.sprite = P4_o0;
            B_Odp1.sprite = P4_o1;
            B_Odp2.sprite = P4_o2;
            B_Odp3.sprite = P4_o3;
            spravna_odpoved = 3;
        }
        if (priklad_cislo == 5)
        {
            B_Zadanie.sprite = P5_o0;
            B_Odp1.sprite = P5_o1;
            B_Odp2.sprite = P5_o2;
            B_Odp3.sprite = P5_o3;
            spravna_odpoved = 3;
        }
        if (priklad_cislo == 6)
        {
            B_Zadanie.sprite = P6_o0;
            B_Odp1.sprite = P6_o1;
            B_Odp2.sprite = P6_o2;
            B_Odp3.sprite = P6_o3;
            spravna_odpoved = 2;
        }
        if (priklad_cislo == 7)
        {
            B_Zadanie.sprite = P7_o0;
            B_Odp1.sprite = P7_o1;
            B_Odp2.sprite = P7_o2;
            B_Odp3.sprite = P7_o3;
            spravna_odpoved = 1;
        }
        if (priklad_cislo == 8)
        {
            B_Zadanie.sprite = P8_o0;
            B_Odp1.sprite = P8_o1;
            B_Odp2.sprite = P8_o2;
            B_Odp3.sprite = P8_o3;
            spravna_odpoved = 2;
        }
        if (priklad_cislo == 9)
        {
            B_Zadanie.sprite = P9_o0;
            B_Odp1.sprite = P9_o1;
            B_Odp2.sprite = P9_o2;
            B_Odp3.sprite = P9_o3;
            spravna_odpoved = 3;
        }
        if (priklad_cislo == 10)
        {
            B_Zadanie.sprite = P10_o0;
            B_Odp1.sprite = P10_o1;
            B_Odp2.sprite = P10_o2;
            B_Odp3.sprite = P10_o3;
            spravna_odpoved = 2;
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
            listok_enable();
            //Debug.Log(vybrana_odpoved);
            vybrana_odpoved = 4; //aby sa vynulovala odpoved po potvrdeni
            odpoved.text = string.Format("{0}", ""); // vynulujeme odpoved
        }
    }

    public void score_vyhodnotenie()
    {
        hernycanvas.gameObject.SetActive(false);
        //hernycanvas.alpha = 1 - hernycanvas.alpha;
        //hernycanvas.interactable = false;
        scorecanvas.gameObject.SetActive(true);
        //scorecanvas.alpha = 1 + scorecanvas.alpha;
        //scorecanvas.interactable = true;
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
