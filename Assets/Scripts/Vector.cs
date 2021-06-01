
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector
{
    #region variables
    public float xPos;
    public float yPos;
    public float zPos;  
    #endregion

    #region Constructors
    public Vector()
    {
        xPos = 0f;
        yPos = 0f;
        zPos = 0f;
    }

    public Vector(float posX, float posY, float posZ)
    {
        xPos = posX;
        yPos = posY;
        zPos = posZ;
    }

    public Vector(float angleX, float angleY, float angleZ, float length) {
        float checkDirectionCosines = Mathf.Pow(Mathf.Cos(angleX),2) + Mathf.Pow(Mathf.Cos(angleY), 2) + Mathf.Pow(Mathf.Cos(angleZ), 2);
        if (checkDirectionCosines > 0.999f && checkDirectionCosines < 1.0001f)
        {
            xPos = length * Mathf.Cos(angleX);
            yPos = length * Mathf.Cos(angleY);
            zPos = length * Mathf.Cos(angleZ);
        }
        else
        {
            throw new System.FormatException("Wrong direction angles ");
        }
       
    }
    #endregion

    #region methods
    public float magnitudeVector()
    {
        return Mathf.Sqrt((Mathf.Pow(xPos, 2) + Mathf.Pow(yPos, 2) + Mathf.Pow(zPos, 2)));
    }
    public void normalizeVector()
    {
        if (magnitudeVector() != 0)
        {
            xPos /= magnitudeVector();
            yPos /= magnitudeVector();
            zPos /= magnitudeVector();
        }
          
       
        
    }
    
    public void reverseVector()
    {
        xPos *= -1; 
        yPos *= -1; 
        zPos *= -1;
     

    }
    #region operators
    public static Vector operator + (Vector v1, Vector v2) {
        return new Vector(v1.xPos+v2.xPos, v1.yPos+v2.yPos, v1.zPos+v2.zPos);
    }
    public static Vector operator - (Vector v1, Vector v2)
    {
        return new Vector(v1.xPos - v2.xPos, v1.yPos - v2.yPos, v1.zPos - v2.zPos);
    }    
    public static Vector operator * (Vector v1, float value)
    {
        return new Vector(v1.xPos * value, v1.yPos * value, v1.zPos *value);
    }
    public static Vector operator / (Vector v1, float value)
    {
        return new Vector(v1.xPos /value, v1.yPos / value, v1.zPos / value);
    }
    public static float operator * (Vector v1, Vector v2) {
       return (v1.xPos*v2.xPos) + (v1.yPos * v2.yPos) + (v1.zPos * v2.zPos);
    }
    public static Vector operator ^(Vector v1, Vector v2) {
        return new Vector(((v1.yPos*v2.zPos)-(v1.zPos*v2.yPos)),//X
            ((v1.xPos * v2.zPos) + (v1.zPos * v2.xPos)),//Y
            ((v1.xPos * v2.yPos) - (v1.yPos * v2.xPos)));//Z
            }

  public Vector3 toVector3()
    {
        return new Vector3(xPos, yPos, zPos);
    }
    #endregion   
      
    #region toString
    public override string ToString()
    {
        return "X: " + xPos + " Y: " + yPos + " Z: " + zPos;
    }
    #endregion
    
    #endregion
}
