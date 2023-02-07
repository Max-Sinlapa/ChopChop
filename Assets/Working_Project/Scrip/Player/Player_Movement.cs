using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D rigiB;
    Transform transform;
    public float move_speed;
    public float jumpFoce;
    private float move_Horizontal;
    private float move_Vertical;

    private bool isJumping;
    private bool check_Roatat;

    private GameObject player;
    public GameObject JumpEffectEffect;

    Vector3 PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        rigiB = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        rigiB.AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        WalkDirection(inputX);
        PlayerPos = transform.position;
    }

    public void Jump()
    {
        rigiB.AddForce(new Vector2(0f, jumpFoce), ForceMode2D.Impulse);
        Instantiate(JumpEffectEffect, transform.position, transform.rotation, null);
    }

    public void WalkDirection(float inputX)
    {
        if (inputX > 0f && move_speed < 0)
        {
            SwipeDirection_To_Right();
        }
        if (inputX < 0f && move_speed > 0)
        {
            SwipeDirection_To_Left();
        }

        rigiB.AddForce(new Vector2(move_speed, 0f), ForceMode2D.Impulse);

        if (PlayerPos.x > 2.0 || PlayerPos.x < -2.0)
        {
            if (PlayerPos.x > 2.0)
                SwipeDirection_To_Left();
            if (PlayerPos.x < -2.0)
                SwipeDirection_To_Right();
        }
    }

    void SwipeDirection_To_Right()
    {
        if(move_speed < 0)
        {
            transform.localScale = new Vector3(3, 3, 1);
            move_speed = move_speed * -1;
        }
    }

    void SwipeDirection_To_Left()
    {
        if(move_speed > 0)
        {
            transform.localScale = new Vector3(-3, 3, 1);
            move_speed = move_speed * -1;
        }

    }

}
