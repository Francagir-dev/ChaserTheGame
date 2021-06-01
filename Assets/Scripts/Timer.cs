using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 60.0f;                 //Variable de tiempo pública (para modificación a gusto) que indica lo que durará una partida
    public Text timerText;                      //Variable de tipo tiempo que permite asociar la variable timer como texto al canvas
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()                              
    {
        timer -= Time.deltaTime;               //desde la cantidad total del timer va restando 1 mediante el Time.deltaTime 
        timerText.text = "" + timer;           //Asocia el timer a un texto del canvas
        if (timer <= 0.0f)                     //Condición que permite terminar la partida una vez el timer sea mayor o igual a 0
        {
            PlayerPrefs.SetInt(Constants.nameScore, PointsSystem.score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            timerText.text = "00";
        }

    }
}
