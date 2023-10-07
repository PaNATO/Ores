using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        //foreach (GameObject DropedOre in GameObject.FindGameObjectsWithTag("Ore"))
        //{
        //Debug.Log(collision.gameObject.name);
        //if (collision.gameObject.name == "ParticleDeleter")
        //{
            //Destroy(DropedOre);
            //Destroy(GameObject.FindGameObjectWithTag("Ore"), 1f);
        Destroy(collision.gameObject,0.5f);
            Debug.Log("touch!");
        //}
        //} 
    }
}
