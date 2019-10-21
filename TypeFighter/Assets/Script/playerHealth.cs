using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
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
    public GameObject retryBtn;
    public GameObject quitBtn;

    randLetterGen randG;
    enemyHealth enemyScript;
    

    // Use this for initialization
    void Start () {
        MaxHealth = 100f;
        isDead = false;
        f_Time = x;
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	public void Update()
    {
        hpBar.value = CurrentHealth;
        f_Time -= Time.deltaTime;
        timeBar.value = f_Time;
        if (f_Time <= 0)
        {
            Debug.Log("Time's up. Player takes Damage");          
            resetTime(x);
            timeCount++;

            if (timeCount == 1)
            {
                calculateDamage(25);
            }

            if (timeCount == 2)
            {
                calculateDamage(50);
                timeCount = 0;
            }
            if(randG.round == 9)
            {
                hpBar.gameObject.SetActive(false);
                timeBar.gameObject.SetActive(false);
            }
            }
      
    }
    
    public void resetTime(float i)
    {
        f_Time = i;
    }

    float calculateHP()
    {
        return CurrentHealth / MaxHealth;
    }

    public void calculateDamage(float damage)
    {
        CurrentHealth -= damage;
        hpBar.value = calculateHP();
        if(CurrentHealth <= 0)
        {

            isDead = true;
            Die();
        }
    }

    public void addHealth(float hp)
    {
        CurrentHealth = hp;
        hpBar.value = calculateHP();
    }
    
    void Die()
    {
        CurrentHealth = 0;
        Debug.Log("You have died. Retry?");
        f_Time = 0;
        retryBtn.SetActive(true);
        quitBtn.SetActive(true);
        gameOverT.SetActive(true);
        timeBar.gameObject.SetActive(false);
        hpBar.gameObject.SetActive(false);
    }
}
