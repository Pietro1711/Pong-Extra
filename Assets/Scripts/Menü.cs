using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menü : MonoBehaviour {

    public Button Spielen_Button;
    public Button Verlassen_Button;


    public void Spiel_Spielen ()
    {
        SceneManager.LoadScene(1);
    }

    public void Spiel_Verlassen ()
    {
        Application.Quit();
    }

}
