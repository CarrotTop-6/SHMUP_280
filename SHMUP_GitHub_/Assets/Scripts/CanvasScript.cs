using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Jack Bradford
//Controls the UI
//11/4/23
public class CanvasScript : MonoBehaviour
{
    public TMP_Text livesCounter;
    public TMP_Text timer;
    public int timerCounter = 5;

    //Set the UI to the data needed
    private void Update()
    {
        //displays lives
        livesCounter.text = ("Lives: " + PlayerController.instance.health);
        if(PlayerController.instance.health <= 0)
        {
            timer.text = ("You Died Respawning shortly");
        }
        else
        {
            //tells the player they died
            timer.text = "";
        }
    }
}
