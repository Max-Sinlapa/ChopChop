using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class which destroys it's gameobject after a certain amount of time
/// </summary>
public class DEstory : MonoBehaviour
{
    public GameObject EnemyDestory;


     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Square")
        {
            Destroy(gameObject);
        }
    }
}
