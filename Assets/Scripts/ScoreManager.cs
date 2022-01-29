using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    internal void ChangeScore(object c)
    {
        throw new NotImplementedException();
    }

    public void ChangeScore(int memoryfragmentValue)
    {
        score += memoryfragmentValue;
        text.text = "X" + score.ToString();
    }
}
