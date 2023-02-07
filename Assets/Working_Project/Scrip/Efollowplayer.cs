using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efollowplayer : MonoBehaviour
{
    public float speed = 2;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.player != null)
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
    }
}
