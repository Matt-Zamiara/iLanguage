using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace iLanguage
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InterfaceSetter game;
        RadioButton[] answerButtons;
        public MainWindow()
        {
            
            InitializeComponent(); //tutaj skonczylismy nie wczytuje pytan
            answerButtons = new RadioButton[4];
            answerButtons[0] = odp1;
            answerButtons[1] = odp2;
            answerButtons[2] = odp3;
            answerButtons[3] = odp4;
            game = new InterfaceSetter(answerButtons,Pytanie);
            game.StartGame();




        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            
        }

        private void odp3_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            
        }

        private void odp2_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            
        }

        private void odp4_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
        }
    }

    class Question
    {
        int _correctAnswer;

        public string Text { get; }

        public string[] Answers { get; }

        

        public Question(string text, string[] answers, int correctAnswer)
        {
            Text = text;
            Answers = answers;
            _correctAnswer = correctAnswer;
        }

        public bool checkAnswer(string answer)
        {
            if (answer == Answers[_correctAnswer])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class InterfaceSetter
    {
        Label _label;
        RadioButton[] _answerButtons;
        DataBases dataBases;
        Question[] questions;
        int questionNumber;

        public InterfaceSetter(RadioButton[] answerButtons,Label label)
        {
            _answerButtons = answerButtons;
            dataBases = new DataBases();
            questionNumber = 3;
            _label = label;
        }

        void check()
        {
            questions
        }
        public void StartGame()
        {
            questions = dataBases.PullQuestions(questionNumber);
            for(int i = 0; i < questionNumber; i++)
            {
                for(int j = 0; j < _answerButtons.Length; j++)
                {
                    _answerButtons[j].Content = questions[i].Answers[j];
                    _label.Content = questions[i].Text;
                    
                }
            }
           
        }

    }
    class DataBases
    {
        Random random;
        public DataBases()
        {
            random = new Random();
        }

        public Question[] PullQuestions(int number)
        {
            var json = File.ReadAllText("questions.txt");
            var questions = JsonConvert.DeserializeObject<List<Question>>(json);
            Question[] data = new Question[number];
            for(int i = 0; i < number; i++)
            {
                int index = random.Next(questions.Count);
                data[i] = questions[index];
                questions.RemoveAt(index);
            }

            return data;
        }
    }
}
//sprawdzenie pytania
//
