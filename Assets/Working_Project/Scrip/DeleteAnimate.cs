using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAnimate : MonoBehaviour
{
    private float DiedTime;
    // Start is called before the first frame update

    void Start()
    {
        DiedTime = Time.time;
    }
    void Update()
    {
        if (Time.time > DiedTime + 7.0f)
        {
            Destroy(gameObject);
        }
    }
}
