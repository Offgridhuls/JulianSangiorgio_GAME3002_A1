using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public int countdownTime;
    public GameController timerShot;
    [SerializeField] Text countdownText;
    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(CountdownToStart());  //(start coroutine) another weird function i found online
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString(); // converting int, into string and printing onto my UI text

            yield return new WaitForSeconds(1f); //weird function return I found online

            countdownTime--; //while cdt is not 0, decrement the timer

        }
        countdownText.text = "0";
        timerShot.Launch(); // On timer 0 launch the ball
    }

}   
