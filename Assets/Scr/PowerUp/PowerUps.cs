using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    Vector3 ReduceChange = new Vector3(-0.3f,0,0);
    Vector3 IncreaseChange = new Vector3(0.3f,0,0);
    ArkanoidController arkanoidController;
    void Start()
    {
        arkanoidController = GameObject.Find("Arkanoid").GetComponent<ArkanoidController>();
    }

    void SlowPowerUp()
   {
       Ball.currentMultiplier = Ball.currentMultiplier - 0.25f;
       if(Ball.currentMultiplier<0.15f)
       {
           Ball.currentMultiplier = 0.15f;
       }

   }

   void FastPowerUp()
   {
       Ball.currentMultiplier = Ball.currentMultiplier + 0.25f;
       if(Ball.currentMultiplier>1.8f)
       {
           Ball.currentMultiplier = 1.8f;
       }

   }

   void ReducePowerUp()
   {
       gameObject.transform.localScale += ReduceChange;
       if(gameObject.transform.localScale.x<0.4f)
       {
           gameObject.transform.localScale = new Vector3(0.4f,gameObject.transform.localScale.y,gameObject.transform.localScale.z);
       }
   }

   void IncreasePowerUp()
   {
       gameObject.transform.localScale += IncreaseChange;
       if(gameObject.transform.localScale.x>1.6f)
       {
           gameObject.transform.localScale = new Vector3(1.6f,gameObject.transform.localScale.y,gameObject.transform.localScale.z);
       }
   }

   void OnTriggerEnter2D(Collider2D other)
   {
        if(other.gameObject.name == "PowerUp_S(Clone)")
        {
            SlowPowerUp();  
        }
        else if(other.gameObject.name == "PowerUp_F(Clone)")
        {
            FastPowerUp();
        }
        else if(other.gameObject.name == "PowerUp_A(Clone)")
        {
            ReducePowerUp();
        }
        else if(other.gameObject.name == "PowerUp_E(Clone)")
        {
            IncreasePowerUp();
        }
        else if(other.gameObject.name == "PowerUp_50(Clone)")
        {
            arkanoidController.Points50PowerUp();
        }
        else if(other.gameObject.name == "PowerUp_10(Clone)")
        {
            arkanoidController.Points100PowerUp();
        }
        else if(other.gameObject.name == "PPowerUp_250(Clone)")
        {
            arkanoidController.Points250PowerUp();
        }
        else if(other.gameObject.name == "PowerUp_500(Clone)")
        {
            arkanoidController.Points500PowerUp();
        }
        Destroy(other.gameObject);
   }
}