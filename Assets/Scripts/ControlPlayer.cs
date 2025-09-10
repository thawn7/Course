using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPlayer : MonoBehaviour
{
    bool isOnGround;
    public Vector3 initialPosition;
    public GameObject btPause, btExit, btResume, gamePausedTxt;
    public bool paused;


    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        initialPosition = transform.position;
        gamePausedTxt = GameObject.Find("gamePaused");
        btResume = GameObject.Find("resumeBt");
        btExit = GameObject.Find("exitBt");
        btPause = GameObject.Find("pauseBt");
        DisplayPauseButtons(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "ground")
        {
            isOnGround = true;
        }
        else
        {
            isOnGround= false;
        }
        if(coll.collider.tag == "obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0,400.0f)) ;
        isOnGround = false;
    }

    public void Pause()
    {
        paused=true;
        DisplayPauseButtons(true);
        Time.timeScale = 0.0f;
    }

    void DisplayPauseButtons(bool state)
    {
        gamePausedTxt.SetActive(state);
        btResume.SetActive(state);
        btExit.SetActive(state);    
        btPause.SetActive(!state); // the opposite of the others
    }

    public void Resume()
    {
        Time.timeScale=1.0f;
        DisplayPauseButtons(false);

    }

}
