using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float f_Time;
    public float x = 2;
    public float CurrentTime;
    public int timeCount;
    public Slider timeBar;

   public playerHealth player;


    // Use this for initialization
    void Start () {
        f_Time = x;
        timeCount = 0;
	}
	
	// Update is called once per frame
	public void Update () {
        f_Time -= Time.deltaTime;
        timeBar.value = f_Time;
        if (f_Time < 0)
        {
            timeCount++;
            Debug.Log("Time's up. Player takes Damage");
            resetTime(x);
        }
        if (timeCount == 1)
        {
            player.calculateDamage(20);
        }
        if (timeCount == 2)
        {
            player.calculateDamage(50);
        }


    }

    public void resetTime(float x)
    {
        f_Time = x;
    }
}
