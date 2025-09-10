using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        GameObject.Find("timerUI").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //print("Time: " + time);
        int seconds = (int)(time % 60);
        int minutes  = (int)(time  / 60);
        //print(minutes +  ":" + seconds);
        GameObject.Find("timerUI").GetComponent<TextMeshProUGUI>().text = minutes + ":" + seconds;
        if(time > 118 )
        {
            GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = "Time is almost up";
        }
        if (time > 120)
        {
            print("TIME UP");
            SceneManager.LoadScene("scene1");
        }
    }
}
