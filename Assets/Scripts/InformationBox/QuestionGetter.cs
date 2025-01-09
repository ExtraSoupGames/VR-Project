using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGetter : MonoBehaviour
{
    public static Question GetQuestion()
    {
        List<Question> list = new List<Question>();
        list.Add(new Question(1, "Question1", "The answer is going to be 1"));
        return list[Random.Range(0, list.Count)];
    }
}
