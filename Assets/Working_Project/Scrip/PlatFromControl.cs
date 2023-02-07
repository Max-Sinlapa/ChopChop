using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFromControl : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            PressToDrop();
        }

        if (waitTime <= 0)
        {
            effector.rotationalOffset = 0.0f;
        }
        waitTime -= Time.deltaTime;


        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector.rotationalOffset = 0.0f;
        }

    }

    public void PressToDrop()
    {
        waitTime = 0.2f;
        effector.rotationalOffset = 180f;

    }

    public void PressToUp()
    {

        effector.rotationalOffset = 0f;

    }
}
