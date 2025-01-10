using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
public enum Topics
{
    AstronomyBasics,
    physicsPhenomena,
    SpaceExploration,
    UniverseAndBeyond
}
public class QuestionGetter : MonoBehaviour
{
    List<List<Question>> topics;
    public void Start()
    {
        topics = new List<List<Question>>();
        List<Question> astronomyBasics = new List<Question>();
        astronomyBasics.Add(new Question(3,
            "What is the largest planet in our solar system? ",
            "Jupiter is the biggest planet in our solar system. It's so big that over 1,300 Earths could fit inside it!",
            "Earth",
            "Saturn",
            "Jupiter"));
        astronomyBasics.Add(new Question(2,
            "Which planet is known as the \"Red Planet\"? ",
            "Mars is called the \"Red Planet\" because its surface is covered in red, rusty dust.",
            "Venus",
            "Mars",
            "Mercury"));
        astronomyBasics.Add(new Question(1,
            "What is the term for a star system with two stars?",
            "A binary star system has two stars that orbit each other. Imagine seeing two suns in the sky!",
            "Binary star",
            "Pulsar",
            "Nebula"));
        astronomyBasics.Add(new Question(2,
            "How long does it take for light from the Sun to reach Earth?",
            "It takes 8 minutes for light from the Sun to reach Earth. That’s pretty fast for something 93 million miles away!",
            "1 second",
            "8 minutes",
            "1 hour"));
        topics.Add(astronomyBasics);

        List<Question> physicsAndSpacePhenomena = new List<Question>();
        physicsAndSpacePhenomena.Add(new Question(2,
            "What is a supernova?",
            "A supernova happens when a giant star explodes at the end of its life. These explosions can create new stars and planets!",
            "A giant asteroid collision",
            "The explosion of a dying star",
            "A type of black hole"));
        physicsAndSpacePhenomena.Add(new Question(2,
            "Which of these phenomena is caused by the Sun's solar wind interacting with Earth's magnetic field?",
            "The aurora borealis, or northern lights, is a colorful light show in the sky caused by the Sun’s energy interacting with Earth’s magnetic field.",
            "Solar eclipse",
            "Aurora borealis",
            "Black hole formation"));
        physicsAndSpacePhenomena.Add(new Question(2,
            "What is the escape velocity required to leave Earth's gravity?",
            "To leave Earth’s gravity, a rocket needs to travel at 11.2 kilometers per second. That’s about 33 times the speed of sound!",
            "2.4 km/s",
            "11.2 km/s",
            "50 km/s"));
        topics.Add(physicsAndSpacePhenomena);

        List<Question> spaceExploration = new List<Question>();
        spaceExploration.Add(new Question(1,
            "What was the first human-made object to reach space?",
            "Sputnik 1 was the first human-made object in space. It was a tiny satellite launched by the Soviet Union in 1957.",
            "Sputnik 1",
            "Apollo 11",
            "Vostok 1"));
        spaceExploration.Add(new Question(2,
            "Who was the first human to walk on the Moon?",
            "Neil Armstrong was the first person to walk on the Moon in 1969, saying the famous words: \"That’s one small step for man, one giant leap for mankind.\"",
            "Buzz Aldrin",
            "Neil Armstrong",
            "Yuri Gagarin"));
        spaceExploration.Add(new Question(2,
            "What is the purpose of the James Webb Space Telescope?",
            "The James Webb Space Telescope helps scientists see galaxies and stars from billions of years ago. It’s like a time machine for space!",
            "To observe X-rays from space",
            "To study the early universe",
            "To detect gravitational waves"));
        topics.Add(spaceExploration);

        List<Question> universeAndBeyond = new List<Question>();
        universeAndBeyond.Add(new Question(2,
            "What is the approximate age of the universe?",
            "The universe is about 13.8 billion years old—that’s older than the Earth and all the planets combined!",
            "4.6 billion years",
            "13.8 billion years",
            "20 billion years"));
        universeAndBeyond.Add(new Question(3,
            "What is dark matter?",
            "Dark matter is mysterious stuff in space that we can’t see, but we know it’s there because of how it affects gravity.",
            "A form of matter visible to telescopes",
            "A type of black hole",
            "Matter that does not emit light or energy"));
        universeAndBeyond.Add(new Question(1,
            "Which galaxy is the closest to the Milky Way?",
            "The Andromeda Galaxy is our closest galactic neighbor. One day, it might even collide with our galaxy, but don’t worry—that’s billions of years away!",
            "Andromeda Galaxy",
            "Whirlpool Galaxy",
            "Triangulum Galaxy"));
        topics.Add(universeAndBeyond);


    }
    public List<Question> GetQuestions(Topics topic)
    {
        int topicIndex = (int)topic;
        return topics[topicIndex];
    }
    public void RemoveQuestion(string questionString)
    {
        foreach (List<Question> questions in topics)
        {
            foreach(Question question in questions)
            {
                if(question.questionString == questionString)
                {
                    questions.Remove(question);
                    return;
                }
            }
        }
    }
}
