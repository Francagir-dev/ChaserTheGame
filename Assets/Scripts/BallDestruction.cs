using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BallDestruction : MonoBehaviour
{

  
    private void OnCollisionEnter(Collision other)          //Destruye la pelota al colisionar con los collider del aro
    {

        if (other.gameObject.name.Equals(Constants.GO_QUAFFLE))
        {
            GameObject.Find(Constants.GO_TIRADOR).GetComponent<LanzamientoBola>().autoPass = true;
            Destroy(other.gameObject);
            Hit.changeAspectsWhenHit();
        }
    }

}  
