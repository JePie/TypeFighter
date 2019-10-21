using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy2 : MonoBehaviour {
    public float enemyMaxHealth;
    public float enemyCurrentHealth;
    public Slider enemyHpBar;
    public GameObject enemy;
    public bool isHit;
    public bool enemy2Dead;
    playerHealth player;
    public Animator enemyAnim;

    // Use this for initialization
    void Start () {
        enemyMaxHealth = 100;
        enemyCurrentHealth = enemyMaxHealth;
        enemy = GameObject.Find("Standing Idle");
        enemyAnim = enemy.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        enemyHpBar.value = enemyCurrentHealth;
        if (isHit == true)
        {
            isHit = false;
            Debug.Log("hit2");
        }
    }

    float calculateHP()
    {
        return enemyCurrentHealth / enemyMaxHealth;
    }

    public void calculateDamage(float damage)
    {
        Debug.Log("You damaged the enemy for " + damage + " damage!");
        enemyCurrentHealth -= damage;
        enemyHpBar.value = calculateHP();
        isHit = true;
        if (isHit == true)
        {
            enemyAnim.SetBool("isHit", isHit);
        }

        if (enemyCurrentHealth <= 0)
        {
            enemyDie();
        }
    }

    public void enemyDie()
    {
        //play death anim then wait a delay then delete this.

        Debug.Log("You have defeated the enemy!");
        enemy2Dead = true;
        gameObject.SetActive(false);
        enemy.SetActive(false);
    }



}
