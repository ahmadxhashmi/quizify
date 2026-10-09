using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    public bool loadingNextQuestion;
    public bool isAnsweringQuestion = false;
    float timerValue;
    public float fillFraction;
    void Update()
    {
        UpdateTime();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTime()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue > 0 )
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadingNextQuestion = true;
            }
        }

        if(timerValue <= 0)
        {
            timerValue = timeToCompleteQuestion;
        }

        Debug.Log(isAnsweringQuestion + " : " + timerValue + " = " + fillFraction);
    }
}
