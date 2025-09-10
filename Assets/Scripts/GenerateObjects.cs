using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GenerateObjects : MonoBehaviour
{
    public GameObject obstacle;
    float timer;
    float score;
    float cloudTimer;
    public GameObject cloud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageTimer();
        score += Time.deltaTime;
        DisplayScore();
        CreateClouds();
    }

    void ManageTimer()
    {
        timer += Time.deltaTime;
        if (timer >=2)
        {
            AddObstacle();
            timer = 0;
        }
    }

    void AddObstacle()
    {
        Vector3 positionOfPlayer = GameObject.Find("player").GetComponent<ControlPlayer>().initialPosition;
        float randomNumber = Random.Range(1, 5);
        GameObject t1, t2,t3,t4;
        t1 = (GameObject)(GameObject.Instantiate(obstacle,positionOfPlayer + Vector3.right *20, Quaternion.identity));
        if(randomNumber>1)
        {
            t2=(GameObject)(GameObject.Instantiate(obstacle, positionOfPlayer + Vector3.right * 21, Quaternion.identity));
        }
        if(randomNumber>2)
        {
            t3 = (GameObject)(GameObject.Instantiate(obstacle, positionOfPlayer + Vector3.right * 22, Quaternion.identity));
        }
        if(randomNumber>3)
        {
            t4 = (GameObject)(GameObject.Instantiate(obstacle, positionOfPlayer + Vector3.right * 21 + Vector3.up, Quaternion.identity));
        }
    }

    void DisplayScore()
    {
        GameObject.Find("scoreUI").GetComponent<TextMeshProUGUI>().text = "" + (int)score;
    }
    
    void CreateClouds()
    {
        cloudTimer += Time.deltaTime;
        GameObject cloud1;
        Vector3 topRightCorner = GameObject.Find("topRightCorner").transform.position;
        int altitude = Random.Range(0, 2);
        if(cloudTimer>=10)
        {
            cloud1 = (GameObject)(GameObject.Instantiate(cloud, topRightCorner + -Vector3.up*altitude, Quaternion.identity));
            cloudTimer = 0;
        }
    }
}
