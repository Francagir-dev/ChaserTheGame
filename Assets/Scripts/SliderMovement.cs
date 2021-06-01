using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMovement : MonoBehaviour
{
    public Slider sliderFuerza;      //Slider que permitirá modificar la fuerza con la que se lanza la pelota
    public bool movingUp;            //Variable booleana que indica a que dirección va el slider

    // Start is called before the first frame update
    void Start()
    {
        sliderFuerza = GameObject.Find(Constants.GO_FUERZA).GetComponent<Slider>();    //Busca el slider en el start
    }

    void moveUp()
    {              
        sliderFuerza.value += 0.3f;                                                 //aumenta la fuerza en 0.3 del valor del slider 
        if (sliderFuerza.value == sliderFuerza.maxValue)                            //Si el slider llega a su punto máximo de fuerza cambia de dirección
            movingUp = false;                                                       //El booleano de dirección hacia arriba pasa a falso
    }

    void moveDown()
    {
        sliderFuerza.value -= 0.3f;                                                 //Permite decrecer el valor de la fuerza en el slider en 0.3
        if (sliderFuerza.value == sliderFuerza.minValue)                            //Si el slider llega a su punto mínimo de fuerza cambia de dirección
            movingUp = true;                                                        //El booleano de dirección hacia arriba pasa a verdadero
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)                                                        //Condición que registra en el update si se mueve hacia arriba, si lo hace ejecuta la función moveUp
        {
            moveUp();
        }
        else                                                                 //Condición que registra en el update si se mueve hacia arriba, si lo hace ejecuta la función moveDown
        {
            moveDown();
        }
    }
}
