using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageBt : MonoBehaviour
{
    public GameObject btPause, btExit, btResume, gamePausedTxt;
    public bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("infiniteRunner");
    }

    public void Resume()
    {
        GameObject.Find("player").GetComponent<ControlPlayer>().Resume();
    }

    public void Pause()
    {
        GameObject.Find("player").GetComponent<ControlPlayer>().Pause();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
