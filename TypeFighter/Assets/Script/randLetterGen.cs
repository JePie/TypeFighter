using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class randLetterGen : MonoBehaviour
{
    //Enemies
    public enemyHealth enemyScript;

    //Player
    public playerHealth playerScript;

    //Letters and Symbols
    string[] letters = new string[154] { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                                        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                        "!","@", "#", "$", "%", "^","&","*","(",")","_","-","+","=","{","}",":",";","<",">",".","?","/","~",
                                        "Accoutrements", "Creative", "Ocular","Gasconading", "Luminescent","Perfect","Inappropriate","Misdemeanor", "Sanctuary", "Festivities", "Misspell","Amalgamation","Peacemaker", "Pacemakers", "Stockings","Fruitcake","Palate", "Patissiers", "Warmheartedness", "Externalizations", 
                                        "hose","dog","success","moo","merry","Christmas","Hanukkah","Kwanzaa","candy","cane", "meow", "cat", "sleigh", "tree", "happy", "birthday",
                                        "UnENcUmbEred","pRofeSSor","CAPitaLizAtioN","eQuALiTy","MoLecULE","diSPOsaBLE","TyPeFiGhTeR","LiGhtBULb", "MiTiGatE","aSsErTiVe","THOugHtFuLL", "CrAnBeRRy","tAnGeRine","CLemEnTINe","tHiNkiNG", "iNtrOdUcTIOn","PrEsEnTs" ,
                                        "Pr0fe$soR","P3rSimM0N","uN3Mp1oYEd","P3Ek@P0o","uNf0rTQn@t3","d3f0rE", "S1tD0W8*n", "W@13rb0H3","uNL^#Ky","0Rn@m3Nt","REEEL@><in&", "Gr@t3fUL!","Ga%ZOokuri","ARc1aiz","a$$oCiatiON","ShortEasyWord","C0mPl3teL$Y","w0rMHo13s","@D0rAbL3","$w3@tER",
                                        "!@WE@ET$", ">W<D?S^$","v3rYH@rDW0RD","R3D3MPTiO^^!!!", "C@rpalTUNN#L","UnNEc3S@ri", "gReE3#",
                                         };
    //0-24 A-Z
    //25-51 a-z
    //52 - 73 @-%
    //74 - 93 big words
    //94 - 109 small words
    //110 -126 words with capitolization/lowecased randomly
    //127 -153 words with ^^ and symbols
    
    public Text text1, text2, text3, text4, text5, text6, text7;
    string t1, t2, t3, t4, t5, t6;//first answer
    public static string answer1;
    public InputField input;

    public ParticleSystem redHit;
    public ParticleSystem blueHit;
    public ParticleSystem greenHit;
    public ParticleSystem yellowHit;
    public ParticleSystem purpleHit;
    public ParticleSystem blackHit;

    public ParticleSystem redHit2;
    public ParticleSystem redHit3;

    public ParticleSystem finalHit1;
    public ParticleSystem finalHit2;
    public ParticleSystem finalHit3;
    public ParticleSystem finalHit4;
    public ParticleSystem finalHit5;
    public ParticleSystem finalHit6;

    public AudioSource snowHit;
    public AudioSource enemyHit;
    public AudioSource playerHit;
    public AudioSource playerHeal;
    public AudioSource wrongA;

    public AudioSource bg1;

    //bool
    public bool gameStart;

    int i, k;

    public int round = 0;

    // Use this for initialization
    public void Start()
    {
        gameStart = true;
        i = 94;
        k = 109;
        randomNum();
        playbg1();
    }
    public void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
    }
    public void randomNum()
    {
        if (round == 1)//lowercase
        {
            i = 0;
            k = 24;
        }
        if (round == 2) //uppercase
        {
            i = 25;
            k = 49;
        }
        //put both upper and lowercase
        //////
        if (round == 3) //all symbols
        {
            i = 50;
            k = 73;
        }
        if (round == 4) //everything
        {
            i = 0;
            k = 73;
        }
        if (round == 0)
        {
            t1 = letters[Random.Range(i, k)];
            Debug.Log(t1);
            text7.text = t1;
            text7.gameObject.SetActive(true);
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(false);
            text4.gameObject.SetActive(false);
            text5.gameObject.SetActive(false);
            text6.gameObject.SetActive(false);
            answer1 = t1;
        }

        else if (round == 6)//big words
        {
            i = 74;
            k = 93;
            t1 = letters[Random.Range(i, k)];
            Debug.Log(t1);
            text1.text = t1;
            answer1 = t1;
            text7.text = t1;
            text7.gameObject.SetActive(true);
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(false);
            text4.gameObject.SetActive(false);
            text5.gameObject.SetActive(false);
            text6.gameObject.SetActive(false);
        }
        else if (round == 7)//capss words
        {
            i = 110;
            k = 126;
            t1 = letters[Random.Range(i, k)];
            Debug.Log(t1);
            text7.text = t1;
            answer1 = t1;
        }
        else if (round == 8 )//words so messed up
        {
            i = 127;
            k = 146;
            t1 = letters[Random.Range(i, k)];
            Debug.Log(t1);
            text7.text = t1;
            answer1 = t1;
        }
        else if ( round == 9)//words so messed up
        {
            i = 127;
            k = 153;
            t1 = letters[Random.Range(i, k)];
            Debug.Log(t1);
            text7.text = t1;
            answer1 = t1;
        }
        else if (round == 10)
        {
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(false);
            text4.gameObject.SetActive(false);
            text5.gameObject.SetActive(false);
            text6.gameObject.SetActive(false);
            text7.gameObject.SetActive(false);
            input.gameObject.SetActive(false);
        }

        else if (round != 0)
        {
            text1.gameObject.SetActive(true);
            text2.gameObject.SetActive(true);
            text3.gameObject.SetActive(true);
            text4.gameObject.SetActive(true);
            text5.gameObject.SetActive(true);
            text6.gameObject.SetActive(true);
            text7.gameObject.SetActive(false);
            t1 = letters[Random.Range(i, k)];
            t2 = letters[Random.Range(i, k)];
            t3 = letters[Random.Range(i, k)];
            t4 = letters[Random.Range(i, k)];
            t5 = letters[Random.Range(i, k)];
            t6 = letters[Random.Range(i, k)];
            Debug.Log(t1);
            Debug.Log(t2);
            Debug.Log(t3);
            Debug.Log(t4);
            Debug.Log(t5);
            Debug.Log(t6);
            text1.text = t1;
            text2.text = t2;
            text3.text = t3;
            text4.text = t4;
            text5.text = t5;
            text6.text = t6;
            answer1 = t1 + t2 + t3 + t4 + t5 + t6;
        }
      
        Debug.Log("Round:"+round);

    }
    public void GetInput(string answer)
    {
        Debug.Log("'Your Answer: " + answer);
        if (answer == answer1)
        {
            Debug.Log("You are right the answer is " + randLetterGen.answer1);
            randomNum();
            input.text = "";
            if (round == 0)
            {
                enemyScript.calculateDamage(25);//25 default
                greenHit.Play();
                snowHit.Play();
            }

            if (round == 1)
            {
                enemyScript.calculateDamage(25);//25 default
                redHit.Play();
                snowHit.Play();
            }

            if (round == 2)
            {
                enemyScript.calculateDamage(20);//20 default
                blueHit.Play();
                snowHit.Play();
            }

            if (round == 3)
            {
                enemyScript.calculateDamage(20);//20 default
                yellowHit.Play();
                enemyHit.Play();
            }
            if (round == 4)//round5
            {
                enemyScript.calculateDamage(20);//20 default
                blueHit.Play();
                enemyHit.Play();
            }

            if (round == 5)//round6
            {
                enemyScript.calculateDamage(20);//20 default
                purpleHit.Play();
                enemyHit.Play();
            }

            if (round == 6)
            {
                enemyScript.calculateDamage(20);//20 default
                greenHit.Play();
                enemyHit.Play();
            }
            if (round == 7)
            {
                enemyScript.calculateDamage(20);//20 default
                redHit2.Play();
                redHit3.Play();
                enemyHit.Play();
            }
            if (round == 8)
            {
                enemyScript.calculateDamage(20);//20 default
                blackHit.Play();
                enemyHit.Play();
            }
            if (round == 9)
            {
                enemyScript.calculateDamage(15);//15 default
                finalHit1.Play();
                finalHit2.Play();
                finalHit3.Play();
                finalHit4.Play();
                finalHit5.Play();
                finalHit6.Play();
                enemyHit.Play();
            }

            if (round == 10)
            {
                text1.gameObject.SetActive(false);
                text2.gameObject.SetActive(false);
                text3.gameObject.SetActive(false);
                text4.gameObject.SetActive(false);
                text5.gameObject.SetActive(false);
                text6.gameObject.SetActive(false);
                text7.gameObject.SetActive(false);
                input.gameObject.SetActive(false);
            }
                if (enemyScript.enemyCurrentHealth <= 0)
            {
                enemyScript.addHealthP(100);
                enemyScript.resetTime(8);
                playerHeal.Play();
                Debug.Log("Health regained. Next Round: " + round);
                round++;
            }
        }
        else if(answer != answer1)
        {
            Debug.Log("Wrong...");
            wrongA.Play();
            enemyScript.calculateDamageP(10);
            input.text = "";
        }
    }
    public void playbg1()
    {
        bg1.loop = true;
        bg1.Play();
    }
    
}
