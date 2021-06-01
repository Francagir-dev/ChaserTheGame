using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
 

    private void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(Constants.TAG_Score1)) //Comparamos con las 3 tags
        {
            PointsSystem.score++;   //Añade 1 punto al marcador
            Destroy(gameObject);    //Destruye la pelota para poder volver a disparar otra
            changeAspectsWhenHit(); //Ejecuta la función de cambio de viento


        }
        if (collision.gameObject.tag.Equals(Constants.TAG_Score2))
        {

            PointsSystem.score += 3; //Añade 3 puntos al marcador
            Destroy(gameObject);     //Destruyela pelota para poder volver a disparar otra
            changeAspectsWhenHit();  //Ejecuta la función de cambio de viento


        }
        if (collision.gameObject.tag.Equals(Constants.TAG_Score3))
        {

            PointsSystem.score += 5;   //Añade 5 puntos al marcador
            Destroy(gameObject);       //Destruyela pelota para poder volver a disparar otra
            changeAspectsWhenHit();    //Ejecuta la función de cambio de viento

        }
    }
    public static void changeAspectsWhenHit() {                  //Función que cambia distintos valores del juego cuando la pelota colisiona y que influirán en el siguiente lanzamiento
        LanzamientoBola.Vw = Random.Range(1f,25f);               //Genera un valor aleatorio entre 1 y 25 para  la velocidad del viento cuando se vuelve a lanzar
        LanzamientoBola.windGammaAngle = Random.Range(35f,100f); //Genera un valor aleatorio para el ángulo gamma entre 35 y 100
        LanzamientoBola.Cd = Random.Range(1f,2f);                //Genera un valor aleatorio entre 1 y 2 (contando decimales) para Cd
        LanzamientoBola.Cw = Random.Range(1f,2f);                //Genera un valor aleatorio entre 1 y 2 (contando decimales) para Cw

    }

  
}