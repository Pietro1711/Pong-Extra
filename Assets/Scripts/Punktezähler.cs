using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Punktezähler : MonoBehaviour {

    public Text Scoreboard;
    public GameObject ball;

    public static bool canAddScore = true; 

    private int Spieler1Punkte = 0;
    private int Spieler2Punkte = 0;

	// Use this for initialization
	void Start () {

        ball = GameObject.Find("Ball");

	}
	
	// Update is called once per frame
	void Update () {

        if (ball.transform.position.x >= 20f && canAddScore)
        {
            canAddScore = false;
            Spieler1Punkte ++;
            
        }
        if (ball.transform.position.x <= -20f && canAddScore)
        {
            canAddScore = false;
             Spieler2Punkte ++;
            
        }

        if(Spieler1Punkte >= 7)
        {
            SceneManager.LoadScene(2);
        }
        if(Spieler2Punkte >= 7)
        {
            SceneManager.LoadScene(3);
        }



        Scoreboard.text = Spieler1Punkte.ToString() + " : " + Spieler2Punkte.ToString();

        
	}
}
