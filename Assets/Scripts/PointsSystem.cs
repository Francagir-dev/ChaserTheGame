using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsSystem : MonoBehaviour
{
    public Text scoreText;         //Variable tipo Text que permite asociar la puntuación a la interfaz creada en el canvas como tipo texto
    public static int score = 0;   //Contador de la puntuación público y estático para poder acceder desde cualquier script sin instanciarlo

    // Start is called before the first frame update
    void Start()
    {
        score = 0;                //La puntuación se establece como 0 cada vez que se inicie esta escena

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();      //Permite modificar la puntuación en el canvas cada vez que varía desde Update.
 
    }
}
