using UnityEngine;

public class floatingBroom : MonoBehaviour
{
    // Start is called before the first frame update
  
 
// Makes objects float up & down while gently spinning.

    // User Inputs

    public float amplitude = 0.5f;              //variable pública que representa la amplitud a la que flota la escoba
    public float frequency = 1f;                // variable pública que determina la velocidad de la flotabilidad, su frecuéncia de flote

    Vector3 posOffset = new Vector3();          //Vector que determina límites en x,y,z en los que va a flotar
    Vector3 tempPos = new Vector3();            //Vector que determina los tiempos necesarios y timing de flotación


    void Start()
    {

        posOffset = transform.position;         //Establece la posición base del objeto según su posición en la transformada
    }

    void Update()
    {

        tempPos = posOffset;                   //iguala la posición establecida junto al timing establecido en el vector
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;    //multiplica su posición en y con el tiempo, la frecuencia y amplitud para conseguir el efecto de flote

        transform.position = tempPos;     //lo iguala a su transformada real para agregar el cambio realizado
    }
}
