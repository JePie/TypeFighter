using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerCheck : MonoBehaviour {
    public enemyHealth enemyScript;
    public enemy2 enemy2;
    public playerHealth player;
    
    //pseudo code that didnt work when I tried to call it in another script. Vice versa.

    public void GetInput(string answer)
    {
        if (answer == randLetterGen.answer1 )
        {
            enemyScript.calculateDamage(21);
            Debug.Log("You are right the answer is " + randLetterGen.answer1);
            //deal enemy damage

        }
        else
        {
            Debug.Log("Wrong...");
            //deal player damage
            player.calculateDamage(20);
        }
    }
}
