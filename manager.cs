using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;


public class manager : MonoBehaviour
{


    public question[] questions;
    public bool keypressed = true;
    public List<question> unanswered;

    public question currentq;

    [SerializeField]
    public TextMeshProUGUI questionText;
    public float timeBetween = 10.0f;

    void Start()
    {

        if (unanswered == null || unanswered.Count == 0)
        {
            unanswered = questions.ToList();
        }
        GetRandQ();

    }
    public void GetRandQ()
    {
        int randomQuestionInt = Random.Range(0, unanswered.Count);
        currentq = unanswered[randomQuestionInt];
        unanswered.RemoveAt(randomQuestionInt);
        questionText.text = currentq.statement;
    }

    // public void UserSelectTrue()
    // {
    //     if (currentq.isTrue)
    //     {
    //         Debug.Log("right");
    //     }
    //     else
    //     {
    //         Debug.Log("False");

    //     }
    //     StartCoroutine(TransitionBetween());
    // }
    public IEnumerator TransitionBetween()
    {
        keypressed = true;
        PlaySFX(select);
        Debug.Log("WEEE");
        yield return new WaitForSeconds(timeBetween);
        Debug.Log("Done!");
        keypressed = false;
    }


    public IEnumerator GameOver1()
    {
        PlaySFX(death);

        yield return new WaitForSeconds(timeBetween);


        SceneManager.LoadScene("gameoverscreen");

    }
    public IEnumerator GameOver2()
    {
        PlaySFX(death);

        yield return new WaitForSeconds(timeBetween);


        SceneManager.LoadScene("gameoverscreenp2");

    }
    // 
    // public void UserSelectFalse()
    // {
    //     if (!currentq.isTrue)
    //     {
    //         Debug.Log("right");
    //     }
    //     else
    //     {
    //         Debug.Log("false");

    //     }
    //     StartCoroutine(TransitionBetween());
    // }
    public void pause()
    {
        StartCoroutine(TransitionBetween());
    }
    [SerializeField] AudioSource SFXSource;
    public AudioClip death;
       public AudioClip select;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
