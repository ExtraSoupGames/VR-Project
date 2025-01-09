using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Question
{
    public int correctAnswer;
    public string questionString;
    public string informationString;
    public Question(int correctAnswer, string questionString, string informationString)
    {
        this.correctAnswer = correctAnswer;
        this.questionString = questionString;
        this.informationString = informationString;
    }
}

public class InformationBoxUIController : MonoBehaviour
{
    enum ScreenState
    {
        Information,
        Question,
        Success
    }
    public bool showingUI;
    public TextMeshProUGUI infoText;
    public GameObject backButton;
    public GameObject forwardButton;
    public GameObject answer1Button;
    public GameObject answer2Button;
    public GameObject answer3Button;
    private Question question;
    private ScreenState state;
    public PlayerStats playerStats;
    private void Start()
    {
        question = QuestionGetter.GetQuestion();
        UpdateShowingUI();
    }
    private void Update()
    {
        if (!showingUI)
        {
            return;
        }
        switch (state)
        {
            case ScreenState.Information:
                infoText.text = question.informationString;
                answer1Button.SetActive(false);
                answer2Button.SetActive(false);
                answer3Button.SetActive(false);
                backButton.SetActive(false);
                forwardButton.SetActive(true);
                break;
            case ScreenState.Question:
                infoText.text = question.questionString;
                answer1Button.SetActive(true);
                answer2Button.SetActive(true);
                answer3Button.SetActive(true);
                backButton.SetActive(true);
                forwardButton.SetActive(false);
                break;
            case ScreenState.Success:
                infoText.text = "Correct!";
                answer1Button.SetActive(false);
                answer2Button.SetActive(false);
                answer3Button.SetActive(false);
                backButton.SetActive(false);
                forwardButton.SetActive(false);
                break;

        }
    }
    public void ToggleUI()
    {
        showingUI = !showingUI;
        UpdateShowingUI();
    }
    private void UpdateShowingUI()
    {
        infoText.gameObject.SetActive(showingUI);
        backButton.gameObject.SetActive(showingUI);
        forwardButton.gameObject.SetActive(showingUI);
        answer1Button.gameObject.SetActive(showingUI);
        answer2Button.gameObject.SetActive(showingUI);
        answer3Button.gameObject.SetActive(showingUI);
    }
    public void AnswerButtonPressed(int buttonNum)
    {
        if(question.correctAnswer == buttonNum)
        {
            CorrectAnswer();
        }
        else
        {
            IncorrectAnswer();
        }
    }
    private void CorrectAnswer()
    {
        playerStats.AddInformationPellets(5);
        state = ScreenState.Success;
        
    }
    private void IncorrectAnswer()
    {
        //visual feedback
    }
    public void ForwardButtonPressed()
    {
        state++;
    }
    public void BackButtonPressed()
    {
        state--;
    }
}
