using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
   [TextArea(2,6)]
   [SerializeField] string Question = "Enter your question here";
   [SerializeField] string[] answers = new string[4];
   [SerializeField] int correctAnswerIndex;

   public string GetQuestion()
    {
        return Question;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }
}
 