using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Controll : MonoBehaviour
{
    public GameObject Object;
    public Transform SpawnPoint;
    public Health playerhealth;

    void Start()
    {
       // PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerhealth.currentHealth == 0)
        {
            EndGame();
        }

        /*
        if (Input.GetKey("space") && Time.timeScale == 0)
        {
            if(Object != null)
            {
                Debug.Log("Form_UpdateResumeGame");
                ResumeGame();
            }
            else
            {
                //Load End Game
                EndGame();
            }
           
        }*/
    }

    public void PauseGame()
    {
        Debug.Log("Pause");
        //gameObject.GetComponent<SpriteRenderer>().enabled = true;
       // gameObject.GetComponent<AudioSource>().enabled = false;

        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Debug.Log("ResumeGame");
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
       // gameObject.GetComponent<AudioSource>().enabled = true;
       // Instantiate(Object, SpawnPoint.transform.position, Quaternion.identity);

        Time.timeScale = 1;
    }

    void EndGame()
    {
        SceneManager.LoadScene("gameover");
    }
}