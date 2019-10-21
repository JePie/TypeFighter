using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {
    public float MaxHealth;
    public float CurrentHealth;

    public float f_Time;
    public float x = 8;
    public float CurrentTime;
    public int timeCount = 0;
    public bool isDead;

    public Slider timeBar;
    public Slider hpBar;

    public GameObject gameOverT;

    randLetterGen randG;
    enemyHealth enemyScript;


    public float enemyMaxHealth;
    public float enemyCurrentHealth;
    public Slider enemyHpBar;
    public bool isHit;
    public bool enemy1Dead;
    public bool isWin = false;
    playerHealth player;
    public GameObject GameCompleted;
    public GameObject playAgainBtn;
    public GameObject quitBtn;
    public GameObject gameCover;
    public GameObject winCover;

    public GameObject[] enemies;
    public int arrayPos;
    public Text roundT;
    playerHealth playerScript;

    // Use this for initialization
    void Start () {
        arrayPos = 0;
        isDead = false;
        f_Time = x;
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;
        enemyMaxHealth = 100;
        enemyCurrentHealth = enemyMaxHealth;
        enemies[0].SetActive(true);
        enemies[1].SetActive(false);
        enemies[2].SetActive(false);
        enemies[3].SetActive(false);
        enemies[4].SetActive(false);
        enemies[5].SetActive(false);
        enemies[6].SetActive(false);
        enemies[7].SetActive(false);
        enemies[8].SetActive(false);
        enemies[9].SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        hpBar.value = CurrentHealth;
        f_Time -= Time.deltaTime;
        timeBar.value = f_Time;
        roundT.text = "Round: "+(arrayPos + 1);
        enemyHpBar.value = enemyCurrentHealth;
        if (isHit == true)
        {
            isHit = false;
            Debug.Log("hit");
        }

        if(enemyCurrentHealth <= 0)
        {
            Debug.Log("You have defeated the enemy!");
            enemies[arrayPos].SetActive(false);
            enemies[arrayPos+1].SetActive(true);
            addHealth(100);
            arrayPos++;
        }
        if(arrayPos == 10)
        {
            isWin = true;
            Debug.Log("You win the game!");
            gameObject.SetActive(false);
            GameCompleted.SetActive(true);
            playAgainBtn.SetActive(true);
            quitBtn.SetActive(true);
            roundT.gameObject.SetActive(false);
            enemyHpBar.gameObject.SetActive(false);
            winCover.gameObject.SetActive(true);
            timeBar.gameObject.SetActive(false);
            hpBar.gameObject.SetActive(false);

        }
        if(isDead)
        {
            enemyHpBar.gameObject.SetActive(false);
        }

        if (f_Time <= 0)
        {
            Debug.Log("Time's up. Player takes Damage");
            resetTime(x);
            timeCount++;

            if (timeCount == 1)
            {
                calculateDamageP(10);
            }
            if (timeCount == 2)
            {
                calculateDamageP(10);
                timeCount = 0;
            }
            if (randG.round == 9)
            {
                hpBar.gameObject.SetActive(false);
                timeBar.gameObject.SetActive(false);
            }
        }
    }

    float calculateHP() {
        return enemyCurrentHealth / enemyMaxHealth;
    }

   public void calculateDamage(float damage)
    {
        Debug.Log("You damaged the enemy for " + damage + " damage!");
        enemyCurrentHealth -= damage;
        enemyHpBar.value = calculateHP();
        isHit = true;
    }

    public void addHealth(float hp)
    {
        enemyCurrentHealth = hp;
        enemyHpBar.value = calculateHP();
    }


    public void resetTime(float i)
    {
        f_Time = i;
    }

    float calculateHPP()
    {
        return CurrentHealth / MaxHealth;
    }

    public void calculateDamageP(float damage)
    {
        CurrentHealth -= damage;
        hpBar.value = calculateHP();
        if (CurrentHealth <= 0)
        {

            isDead = true;
            Die();
        }
    }

    public void addHealthP(float hp)
    {
        CurrentHealth = hp;
        hpBar.value = calculateHP();
    }

    void Die()
    {
        CurrentHealth = 0;
        Debug.Log("You have died. Retry?");
        f_Time = 0;
        playAgainBtn.SetActive(true);
        quitBtn.SetActive(true);
        gameOverT.SetActive(true);
        timeBar.gameObject.SetActive(false);
        hpBar.gameObject.SetActive(false);
        gameCover.gameObject.SetActive(true);
    }

}
