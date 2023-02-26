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
    public float JumpWaittime;
    private float _jumpwait;

    private GameObject player;
    public GameObject JumpEffectEffect;

    Vector3 PlayerPos;
    
    public List<PlatFromControl> PlatformList;

    // Start is called before the first frame update
    void Start()
    {
        rigiB = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        rigiB.AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
        _jumpwait = JumpWaittime;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float input_X = Input.GetAxis("Horizontal");
        float input_Y = Input.GetAxis("Vertical");
        VerticalDirection(input_Y);
        WalkDirection(input_X);
        PlayerPos = transform.position;

        _jumpwait -= Time.deltaTime;
        
        Debug.Log("Time = "+ Time.deltaTime);
    }

    public void Jump()
    {
        rigiB.AddForce(new Vector2(0f, jumpFoce), ForceMode2D.Impulse);
        Instantiate(JumpEffectEffect, transform.position, transform.rotation, null); 
    }

    public void VerticalDirection(float inputY)
    {
        //Debug.Log("" + _jumpwait);
        if (inputY > 0f && _jumpwait < 0f)
        {
            Jump();
            _jumpwait = JumpWaittime;
        }

        if (inputY < 0f)
        {
            foreach (var _platFromControl in PlatformList)
            {
                _platFromControl.PressToDrop();
            }
        }
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

        this.transform.position += new Vector3(move_speed * Time.deltaTime, 0f, 0f);
        //rigiB.AddForce(new Vector2(move_speed * Time.deltaTime, 0f), ForceMode2D.Impulse);

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
