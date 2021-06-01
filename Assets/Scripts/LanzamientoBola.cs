using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanzamientoBola : MonoBehaviour
{
    public static float Vw = 3f;                      // Vw = Wind Velocity
    public static float windGammaAngle= 85f;          // GammaWindDirection = a angle from the wind to impact the ball
    public static float Cd = 1.2f;                    // Cd =  air resistance constant
    public GameObject ballPrefab;
    public GameObject ball; 
    public float Vinit;                               // Vinit =Ball throw "force"
    public Vector3 S;                                 // S = space travelled
    public static float Cw= 1.3f;                     // Cw =  Wind force constant
    public bool autoPass; 
    public float gamma, alpha;                        // gamma y alpha = throw angle, alpha  will not change,  gamma  calculate by a slider
    private Slider fuerzaSlider;                      // Slider  allow modify the force of the thrown
    private Slider rotationSlider;                    //Slider for the angle of the thrown

    /*
     *  VIM (VERY IMPORTANT MESSAGE)
     *  NO TOCAR ABSOLUTAMENTE NADA DE ESTE SCRIPT
     */

    private void Awake()
    {
        fuerzaSlider = GameObject.Find(Constants.GO_FUERZA).GetComponent<Slider>();          
        rotationSlider = GameObject.Find(Constants.GO_ANGLE).GetComponent<Slider>();         
        S = transform.position;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))                                               
        {
            /* 
             *  En el momento de disparo asignamos las variable del ángulo
             */
            try {
                Vinit = fuerzaSlider.value;                                             
                gamma = rotationSlider.value;              
            } catch (Exception e) {                                                        
                Debug.Log(e);
            }
           
            CreateBall();                                                                       
        autoPass = true;                                                                    
        }
    }
    private void FixedUpdate()
    {
        if (autoPass)
        {        
                if (ball != null)                                                                //Cuando el autopass detecta que no hay una pelota en escena
                {
                    Vector vectorBall = BallSimulation(ball.GetComponent<Ball>());               //busca el vector de movimiento de la pelota (que indica en todo momento donde esta la pelota) 
                    ball.transform.position = vectorBall.toVector3();                            //Se le iguala este vector a la transformada de la posición
                }
            
        } 
    }
    #region Methods
    #region (cosThetas)
    /*
     * Cosenos directores calculados mediante las fórmulas de los componentes de la longitud y la proyección del cañon
     */
   float CalculateThetaX(float alpha, float gamma)
   {
       float x = Mathf.Sin(gamma * Mathf.PI / 180.0f) * Mathf.Sin(alpha * Mathf.PI / 180.0f);
       return x;
   }
   float CalculateThetaY(float alpha)
   {
  
       float y = Mathf.Cos(alpha * Mathf.PI / 180.0f);
       return y;
   }
   float CalculateThetaZ(float alpha, float gamma)
   {
       float z = Mathf.Cos(gamma * Mathf.PI / 180.0f) * Mathf.Sin(alpha * Mathf.PI / 180.0f);
       return z;
   }
   #endregion


    
    /*
     * 
     *  
     *  
     */
    Vector ThrowBall()                                                                            //Calcula la posicion inicial de la bala a traves de los cosenos directores y la longitud del objeto Tirador 
    {
        Vector cosD= new Vector(CalculateThetaX(alpha, gamma), CalculateThetaY(alpha), CalculateThetaZ(alpha, gamma));    //Calcula los cosenos Directores con los angulos alpha y gamma
        return new Vector(Vinit*cosD.xPos, Vinit * cosD.yPos, Vinit * cosD.zPos);
    }
    #region ball

    
    /*
     *   Conjunto de fórmulas para el movimiento de la pelota, en los tres ejes [(x,y,z) en Unity], obtenidos mediante los cosenos directores realizados anteriormente, 
     *   los ángulos ahora están introducidos por parametros en el inspector de Unity. 
     *   Por lo tanto obtendremos un resultado vectorial, que utilizaremos para determinar la trayectoria de la bala.
     *     
     */



    Vector BallSimulation(Ball ball)                         
    {
        ball.time+= Time.deltaTime;

        Vector V = ThrowBall();
    
        
        float x = S.x + ((ball.mass / Cd) * Mathf.Exp(-((Cd / ball.mass) * ball.time)) * (CalculateWindForceX() - V.xPos) - (-CalculateWindForceX() * ball.time)) - ((ball.mass / Cd) * (CalculateWindForceX() - V.xPos));  
       
        float y =  S.y + (-(V.yPos + (ball.mass * ball.gravity) / Cd) * (ball.mass / Cd) * Mathf.Exp(-(Cd * ball.time) / ball.mass) - (ball.mass * ball.gravity * ball.time) / Cd) + ((ball.mass / Cd) * (V.yPos + (ball.mass * ball.gravity) / Cd)); 
        
        float z = S.z + ((ball.mass / Cd) * Mathf.Exp(-((Cd / ball.mass) * ball.time)) * (CalculateWindForceZ() - V.zPos) - (-CalculateWindForceZ() * ball.time)) - ((ball.mass / Cd) * (CalculateWindForceZ() - V.zPos)); 
        Debug.Log("mass: "+ball.mass + "time "+ ball.time);
        return new Vector(x, y, z);  

    }
   
     void CreateBall()                                                                                 
     {
         if (ball == null)
         {
              ball = Instantiate(ballPrefab, transform.position, Quaternion.identity) as GameObject;
              ball.GetComponent<Ball>().gravity = 9.8f;
              ball.GetComponent<Ball>().time = 0f;       
    
         }
     }
    #endregion
   


    float CalculateWindForceX()                                                                        
    {
        return (-((Cw * Vw * Mathf.Sin(windGammaAngle * Mathf.PI / 180.0f)) / Cd));
    }
    float CalculateWindForceZ()
    {
        return (-((Cw * Vw * Mathf.Cos(windGammaAngle * Mathf.PI / 180.0f)) / Cd));
    }

    #endregion
}
