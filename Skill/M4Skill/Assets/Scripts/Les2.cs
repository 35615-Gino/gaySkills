using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Les2 : MonoBehaviour
{
    //PongGame
    public GameObject pongBall;
    public GameObject A;
    public GameObject B;

    public float speed = 5f;

    public Vector2 viewMax;
    public Vector2 viewMin;

    public Vector3 velocity = new Vector3(2,2,0);

    public RaycastHit2D hit;

    public TMP_Text scoreA_text;
    public TMP_Text scoreB_text;

    int scoreA = 0;
    int scoreB = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(pongBall.transform.position);
        scoreA_text.text = scoreA.ToString();
        scoreB_text.text = scoreB.ToString();

        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        viewMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        viewMin = Camera.main.ScreenToWorldPoint(Vector2.zero);

        Debug.Log(viewMin);
        Debug.Log(viewMax);
    }

    // Update is called once per frame
    void Update()
    {

        scoreA_text.text = scoreA.ToString();
        scoreB_text.text = scoreB.ToString();

        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            A.transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            A.transform.position += new Vector3(0, -1, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            B.transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            B.transform.position += new Vector3(0, -1, 0);
        }




        pongBall.transform.position += velocity * Time.deltaTime;
        hit = Physics2D.Raycast(pongBall.transform.position, new Vector3(velocity.x, 0, 0), 0.5f);
        Debug.DrawRay(pongBall.transform.position, new Vector3(velocity.x, 0, 0), Color.white);
        if(hit.collider != null)
        {
            Debug.Log("hallo");
            velocity = new Vector3(-velocity.x, velocity.y, 0);
        }


        if(pongBall.transform.position.y > viewMax.y - pongBall.transform.localScale.x/2)
        {
            velocity = new Vector3(velocity.x, -velocity.y, 0);
        }

        if (pongBall.transform.position.y < viewMin.y + pongBall.transform.localScale.x/2)
        {
            velocity = new Vector3(velocity.x, -velocity.y, 0);
        }
        if (pongBall.transform.position.x > viewMax.x + pongBall.transform.localScale.x / 2)
        {
            pongBall.transform.position = Vector3.zero;
            scoreB++;
        }
        if (pongBall.transform.position.x < viewMin.x - pongBall.transform.localScale.x / 2)
        {
            pongBall.transform.position = Vector3.zero;
            scoreA++;
        }
    }
}
