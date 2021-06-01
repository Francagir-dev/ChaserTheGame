using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text Score;                                                            //Texto que aparecerá asociado a la puntuación en el canvas

    void Start()
    {
        Score = GameObject.Find(Constants.GO_TXT_SCORE).GetComponent<Text>();     //Recupera la información de la escena "Quidditch" para mostrar la puntuación obtenida en el tiempo final
        float finalScore = PlayerPrefs.GetInt(Constants.nameScore);
        Score.text = finalScore.ToString();

    }

    //Funcionalidad del boton del Try Again

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);     //Función que permite volver a jugar una vez se pulsa en su botón asociado
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);     //Función que permite aparecer el menú inicial una vez se pulsa en su botón asociado
    }
}
