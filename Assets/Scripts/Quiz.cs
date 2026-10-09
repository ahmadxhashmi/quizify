using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    [SerializeField] QuestionSO currentQuestion;


    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly;


    [Header("Button Colors ")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;


    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer; 

    [Header("Score Keeper")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadingNextQuestion)
        {
            hasAnsweredEarly = false;
            timer.loadingNextQuestion = false;
            GoNextQuestion();
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

   public void OnAnswerSelected(int index)
   {
    hasAnsweredEarly = true;
    DisplayAnswer(index);
    SetButtonState(false);
    timer.CancelTimer();
    scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";

    if(progressBar.value == progressBar.maxValue)
    {
        isComplete = true;
    }
   }

   void DisplayAnswer(int index)
    {
        if(index == currentQuestion.GetCorrectAnswerIndex())
    {
        questionText.text = "Correct!";
        Image buttonImage = answerButtons[index].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
        scoreKeeper.IncrementCorrectAnswers();
    }
    else
    {
        correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
        string correctAnswer = currentQuestion.GetAnswer(currentQuestion.GetCorrectAnswerIndex());
        questionText.text = "Incorrect! correct answer is: " + correctAnswer;
        Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
    }
    }

    void GoNextQuestion()
    {
        if(questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            progressBar.value++;
            DisplayQuestion();
            scoreKeeper.IncrementQuestionsSeen();
        }
        

    }

    void GetRandomQuestion()
    {
        int index = UnityEngine.Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

   void DisplayQuestion()
   {
    questionText.text = currentQuestion.GetQuestion();


        for(int i=0;i<answerButtons.Length;i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
   }

   void SetButtonState(bool state)
   {
    for(int i=0;i<answerButtons.Length;i++)
    {
        Button button = answerButtons[i].GetComponent<Button>();
        button.interactable = state;
    }
   }

   void SetDefaultButtonSprites()
   {
    for(int i=0;i<answerButtons.Length;i++)
    {
        Image buttonImage = answerButtons[i].GetComponent<Image>();
        buttonImage.sprite = defaultAnswerSprite;
    }
   }
}
