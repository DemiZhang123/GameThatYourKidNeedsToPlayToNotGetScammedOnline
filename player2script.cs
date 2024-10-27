
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class player2script : MonoBehaviour
{


    public int scoreplayer2 = 0;

    public float x = 250f;
    //public question currentq;
    public player1script player1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private manager test;
    void Start()
    {
        test = GameObject.Find("Manager").GetComponent<manager>();
    }

    void Update()
    {
        if (Input.GetKeyDown("l") && test.keypressed == false)

        {
            Debug.Log("player2" + scoreplayer2);
            StartCoroutine(test.TransitionBetween());
            if (test.currentq.isTrue)
            {

                player1.scoreplayer1 += 1;
                sizeChange(-x);
                player1.sizeChange(x);
            }
            else
            {

                player1.scoreplayer1 -= 1;
                sizeChange(x);
                player1.sizeChange(-x);
            }

            if (test.unanswered == null || test.unanswered.Count == 0)
            {
                test.unanswered = test.questions.ToList();
            }
            test.GetRandQ();

        }


        if (Input.GetKeyDown("k") && test.keypressed == false)
        {
            Debug.Log("player1" + player1.scoreplayer1);
            Debug.Log("player2" + scoreplayer2);

            StartCoroutine(test.TransitionBetween());

            if (!test.currentq.isTrue)
            {

                player1.scoreplayer1 += 1;
                sizeChange(-x);
                player1.sizeChange(x);
            }
            else
            {

                player1.scoreplayer1 -= 1;
                sizeChange(x);
                player1.sizeChange(-x);

            }

            if (test.unanswered == null || test.unanswered.Count == 0)
            {
                test.unanswered = test.questions.ToList();
            }
            test.GetRandQ();

        }


        if (player1.scoreplayer1 == -9)
        {

            StartCoroutine(test.GameOver2());

        }
    }


    public void sizeChange(float x)
    {
        transform.localScale = new Vector3(transform.localScale.x + x, transform.localScale.y, transform.localScale.z);
    }



}