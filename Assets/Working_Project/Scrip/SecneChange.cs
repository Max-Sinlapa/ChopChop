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
        Debug.Log("OnStartGame");
        SceneManager.LoadScene("start", LoadSceneMode.Single);
        //StartCoroutine(Delay_To_Menu(delayTime));
    }


    public void OnPlayGame(float delayTime)
    {
        Debug.Log("OnPlayGame");
        //StartCoroutine(Delay_To_Play(delayTime));
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }

    public void OnGameover(float delayTime)
    {
        Debug.Log("OnGameover");
        //StartCoroutine(Delay_To_Over(delayTime));
        SceneManager.LoadScene("gameover", LoadSceneMode.Single);
    }

    public void OnExitEvent(float delayTime)
    {
        Application.Quit();
    }

    IEnumerator Delay_To_Menu(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("start");
    }

    IEnumerator Delay_To_Play(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("Gameplay");
    }

    IEnumerator Delay_To_Over(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("gameover");
    }

    public void TestClick()
    {
        Debug.Log("Tets Click");
    }
}
