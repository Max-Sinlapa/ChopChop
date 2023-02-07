﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the dealing of damage to health components.
/// </summary>
public class Damage : MonoBehaviour
{
    [Header("Team Settings")]
    [Tooltip("The team associated with this damage")]
    public int teamId = 1;

    [Header("Damage Settings")]
    [Tooltip("How much damage to deal")]
    public int damageAmount = 1;
    [Tooltip("Whether or not to destroy the attached game object after dealing damage")]
    public bool destroyAfterDamage = true;
    [Tooltip("Whether or not to apply damage when triggers collide")]
    public bool dealDamageOnTriggerEnter = false;
    [Tooltip("Whether or not to apply damage when triggers stay, for damage over time")]
    public bool dealDamageOnTriggerStay = false;
    [Tooltip("Whether or not to apply damage on non-trigger collider collisions")]
    public bool dealDamageOnCollision = false;


    
    /// <summary>
    /// Description:
    /// Standard unity function called whenever a Collider2D enters any attached 2D trigger collider
    /// Input:
    /// Collider2D collision
    /// Return:
    /// void (no return)
    /// </summary>
    /// <param name="collision">The collider that entered the trigger<</param>
    

    /// <summary>
    /// Description:
    /// Standard Unity function called every frame a Collider2D stays in any attached 2D trigger collider
    /// Input:
    /// Collider2D collision
    /// Return:
    /// void (no return)
    /// </summary>

    /// <param name="collision">The collider that is still in the trigger</param>
    
    /// <summary>
    /// Description:
    /// Standard Unity function called when a Collider2D hits another Collider2D (non-triggers)
    /// Input:
    /// Collision2D collision
    /// Return:
    /// void (no return)
    /// </summary>
    /// <param name="collision">The Collider2D that has hit this Collider2D</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dealDamageOnCollision)
        {
            DealDamage(collision.gameObject);
        }
    }

    /// <summary>
    /// Description:
    /// This function deals damage to a health component 
    /// if the collided with gameobject has a health component attached AND it is on a different team.
    /// Input:
    /// GameObject collisionGameObject
    /// Return:
    /// void (no return)
    /// </summary>
    /// <param name="collisionGameObject">The game object that has been collided with</param>
    private void DealDamage(GameObject collisionGameObject)
    {
        Health collidedHealth = collisionGameObject.GetComponent<Health>();
        if (collidedHealth != null)
        {
            if (collidedHealth.teamId != this.teamId)
            {
                //Debug.Log("Take from: " + this.name);
                //Debug.Log("Resive to : " + collidedHealth.name);
                // CheckEnemy
                if(collidedHealth.name.Contains("R"))
                {

                }else if (collidedHealth.name.Contains("Player"))

                    {

                    if(collidedHealth.transform.localScale.x > 0)
                    {
                        //Look to R
                        float direction = collidedHealth.transform.position.x - this.transform.position.x;
                                          //Vector3.Distance(collidedHealth.transform.position, this.transform.position);
                       // Debug.Log("Directionr R : " + direction)
                        if(direction > 0)
                            collidedHealth.TakeDamage(damageAmount);
                    }
                    else
                    {
                        //Look to L
                        float direction =  this.transform.position.x - collidedHealth.transform.position.x;
                       // Debug.Log("Directionl L : " + direction);
                        if (direction > 0)
                            collidedHealth.TakeDamage(damageAmount);
                    }
                }else collidedHealth.TakeDamage(damageAmount);

                

                if (destroyAfterDamage)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
