using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
internal class Question
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
    public bool showingUI;
    public Image background;
    public TextMeshProUGUI infoText;
    public Button backButton;
    public Button forwardButton;
    public Button answer1Button;
    public Button answer2Button;
    public Button answer3Button;
    private Question question = new Question( 1, "What is the question?");
    private string information = "This is the information";
    private int screenNum = 1;
    public PlayerStats playerStats;
    private void Update()
    {

        if(screenNum == 1)
        {
            infoText.text = information;
            answer1Button.interactable = false;
            answer2Button.interactable = false;
            answer3Button.interactable = false;
            backButton.interactable = false;
            forwardButton.interactable = true;
        }
        else if (screenNum == 2)
        {
            infoText.text = question.questionString;
            answer1Button.interactable = true;
            answer2Button.interactable = true;
            answer3Button.interactable = true;
            backButton.interactable = true;
            forwardButton.interactable = false;
        }
        else
        {
            infoText.text = "Correct!";
            answer1Button.interactable = false;
            answer2Button.interactable = false;
            answer3Button.interactable = false;
            backButton.interactable = false;
            forwardButton.interactable = false;
        }
    }
    public void ToggleUI()
    {
        showingUI = !showingUI;
        UpdateShowingUI();
    }
    private void UpdateShowingUI()
    {
        background.gameObject.SetActive(showingUI);
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
        screenNum = 3;
        
    }
    private void IncorrectAnswer()
    {
        //visual feedback
    }
    public void ForwardButtonPressed()
    {
        screenNum++;
    }
    public void BackButtonPressed()
    {
        screenNum--;
    }
}
