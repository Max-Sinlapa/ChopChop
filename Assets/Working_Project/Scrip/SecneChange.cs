using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecneChange : MonoBehaviour
{
    private GameObject star_game;
    private GameObject play_game;
    private GameObject gameover_game;

    public Health playerhealth;
    /// //////////////////



    public void Update()
    {
        /*if(_PlayButton._currentState == VirtualButtonState.State.Down)
        {
            OnPlayGame();
        }

        if(_MenuButton._currentState == VirtualButtonState.State.Down)
        {

            OnGameover();
        }*/
    }

    public void OnStartGame(float delayTime)
    {
        StartCoroutine(Delay_To_Menu(delayTime));
    }


    public void OnPlayGame(float delayTime)
    {
        StartCoroutine(Delay_To_Play(delayTime));

    }

    public void OnGameover(float delayTime)
    {
        StartCoroutine(Delay_To_Over(delayTime));
    }

    public void OnExitEvent(float delayTime)
    {
        Application.Quit();
    }

    IEnumerator Delay_To_Menu(float delayTime)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("start");
    }

    IEnumerator Delay_To_Play(float delayTime)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator Delay_To_Over(float delayTime)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("gameover");
    }

    public void TestClick()
    {
        Debug.Log("Tets Click");
    }
}
