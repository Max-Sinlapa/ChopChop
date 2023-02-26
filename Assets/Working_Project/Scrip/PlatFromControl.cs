using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFromControl : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;
    private float _effectorRestor;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        _effectorRestor = waitTime;
    }

    void Update()
    {

        if (_effectorRestor <= 0)
        {
            effector.rotationalOffset = 0.0f;
            
            if (Input.GetKey(KeyCode.DownArrow))
            {
                PressToDrop();
            }
        }
        _effectorRestor -= Time.deltaTime;


        if (Input.GetKey(KeyCode.UpArrow))
        {
            PressToUp();
        }

    }

    public void PressToDrop()
    {
        if (_effectorRestor <= 0)
        {
            _effectorRestor = waitTime;
            effector.rotationalOffset = 180f;
        }
    }

    public void PressToUp()
    {
        effector.rotationalOffset = 0f;
    }
}
