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
    public Question(int correctAnswer, string questionString)
    {
        this.correctAnswer = correctAnswer;
        this.questionString = questionString;
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
    public Button backButton;
    public Button forwardButton;
    public Button answer1Button;
    public Button answer2Button;
    public Button answer3Button;
    private Question question = new Question( 1, "What is the question?");
    private string information = "This is the information";
    private ScreenState state;
    public PlayerStats playerStats;
    private void Start()
    {
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
                infoText.text = information;
                answer1Button.interactable = false;
                answer2Button.interactable = false;
                answer3Button.interactable = false;
                backButton.interactable = false;
                forwardButton.interactable = true;
                break;
            case ScreenState.Question:
                infoText.text = question.questionString;
                answer1Button.interactable = true;
                answer2Button.interactable = true;
                answer3Button.interactable = true;
                backButton.interactable = true;
                forwardButton.interactable = false;
                break;
            case ScreenState.Success:
                infoText.text = "Correct!";
                answer1Button.interactable = false;
                answer2Button.interactable = false;
                answer3Button.interactable = false;
                backButton.interactable = false;
                forwardButton.interactable = false;
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
