
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;


public class player1script : MonoBehaviour
{


    public int scoreplayer1 = 0;

    //need score 9 to win


    //public float targetPosition = 21122.15f;



    public float x = 250f;
    //public question currentq;
    public player2script player2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private manager test;
    void Start()
    {
        test = GameObject.Find("Manager").GetComponent<manager>();

    }

    void Update()
    {
        if (Input.GetKeyDown("s") && test.keypressed == false)   //question wrong
        {    Debug.Log("player1"+scoreplayer1);
              Debug.Log("player2"+player2.scoreplayer2);
              
            StartCoroutine(test.TransitionBetween());
            if (test.currentq.isTrue)
            {


                scoreplayer1 = scoreplayer1 - 1;  //subtract 1 score 

                sizeChange(-x);
                player2.sizeChange(x);
            }
            else
            {


                scoreplayer1 = scoreplayer1 + 1;  //subtract 1 score 

                sizeChange(x);        //question right
                player2.sizeChange(-x);
            }

            if (test.unanswered == null || test.unanswered.Count == 0)
            {
                test.unanswered = test.questions.ToList();
            }
             Debug.Log("player1"+scoreplayer1);
              Debug.Log("player2"+player2.scoreplayer2);
            test.GetRandQ();
        }


        if (test.keypressed == false && Input.GetKeyDown("a"))
        {
             Debug.Log("player1"+scoreplayer1);
              Debug.Log("player2"+player2.scoreplayer2);
            StartCoroutine(test.TransitionBetween());

            if (!test.currentq.isTrue)   //question wrong
            {


                scoreplayer1 = scoreplayer1 - 1;  //subtract 1 score 
                sizeChange(-x);
                player2.sizeChange(x);
            }
            else
            {

                scoreplayer1 = scoreplayer1 + 1;  //subtract 1 score 
                sizeChange(x);           //question right 
                player2.sizeChange(-x);

            }
            if (test.unanswered == null || test.unanswered.Count == 0)
            {
                test.unanswered = test.questions.ToList();
            }
             Debug.Log("player1"+scoreplayer1);
              Debug.Log("player2"+player2.scoreplayer2);
            test.GetRandQ();
            

        }


        //x= 21122.15

        //     if (Mathf.Abs(transform.position.x - targetPosition) < 0.1f)
        //     {


        //         LoadGame();


        //     }




        if (scoreplayer1 == 9)
        {

            StartCoroutine(test.GameOver1());


        }




    }



    // public void LoadGame()
    // {


    //     SceneManager.LoadScene("gameoverscreen");

    // }

    public void sizeChange(float x)
    {
        transform.localScale = new Vector3(transform.localScale.x + x, transform.localScale.y, transform.localScale.z);
    }



}