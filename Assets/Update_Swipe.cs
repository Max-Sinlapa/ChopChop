using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update_Swipe : MonoBehaviour
{
    private Swipe_Controll controll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controll = FindObjectOfType<Swipe_Controll>();
        controll.waitTime_jump -= Time.deltaTime;
        controll.waitTime_Down -= Time.deltaTime;
    }
}
