using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   //Botón que permite iniciar el juego
    }

    public void QuitGame()
    {
        Application.Quit();                                                    //Botón que permite salir del juego
    }
}
