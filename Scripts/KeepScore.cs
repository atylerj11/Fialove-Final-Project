using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour
{
    public static float score = 0.00f;
    public TMP_Text displyTxt;

    public TMP_Text HighTxt;


    // Start is called before the first frame update
    void Start()
    {
        if (displyTxt == null)
        {
            displyTxt = GameObject.FindWithTag("ScoreDisplay")
                .GetComponent<TMP_Text>();
        }

        //if (HighTxt == null)
        //{
        //    HighTxt = GameObject.FindWithTag("HighScore")
        //        .GetComponent<TMP_Text>();
        //}

        //PlayerPrefs.SetFloat("HighScore", 0);

        //HighTxt.text = "$ " + PlayerPrefs.GetFloat("HighScore");

    }

    // Update is called once per frame
    void Update()
    {
        displyTxt.text = "$" + score.ToString("F2");

        //if (score > PlayerPrefs.GetFloat("HighScore",0))
        //{
        //    PlayerPrefs.SetFloat("HighScore", score);


        //}
    }
}
