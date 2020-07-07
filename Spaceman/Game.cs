using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceman
{
    class Game
    {
        //fields
        private string codeword;
        private string currentWord;
        public int maxGuess = 5;
        public int wrongGuessCount = 0;
        private string[] codewordsList = new string[] {
            "aliens",
            "abduction",
            "spaceship",
            "probe",
            "human",
            "cattle",
            "galaxy"
        };

        private readonly Ufo ship = new Ufo();
        public int guessLeft = 5;

        //Constructors
        public Game()
        {
            Greet();
            RandomAnswer();
            EncrpytAnswer();            
        }

        
        //Properties
        private string Codeword
        { get; set; }

        private string CurrentWord
        { get; set; }

        public int MaxGuess
        { get; set; }

        public int WrongGuessCount
        { get; set; }
        

        //Methods
        private void Greet()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("HELLO AND WELCOME TO THE SPACEMAN CONSOLE GAME!");
            Console.WriteLine("===============================================");
            Console.WriteLine("Instructions: YOUR FRIEND IS BEING ABDUCTED! HURRY!\n");
            Console.WriteLine("You have to guess the codeword before its too late!\n");
            Console.WriteLine("For every correct letter you'll be one step closer\n");
            Console.WriteLine("to saving your friend. You get Five guesses total.");
        }

        private string RandomAnswer()
        {
            Random rand = new Random();
            int listIndex = rand.Next(codewordsList.Length);
            codeword = codewordsList[listIndex];
            return codeword;
        }

        private string EncrpytAnswer()
        {
            char[] currentCode = codeword.ToCharArray();
            char[] blankAnswer = new char[currentCode.Length];

            for (int i = 0; i < currentCode.Length; i++)
            {
                char currentLetter = currentCode[i];
                char letter = '_';
                blankAnswer[i] = letter;
            }

            currentWord = String.Join("", blankAnswer);
            return currentWord;
        }

        public void Display()
        {
            Console.WriteLine(ship.Stringify());
            Console.WriteLine($"\nCurrent Word: {currentWord}\n");
            Console.WriteLine($"Guesses Remaining: {guessLeft}\n");
            
        }

        public void Ask()
        {
            Console.Write("Guess a Letter: ");
            string userGuess = Console.ReadLine();
            string guess = userGuess.ToLower();
            char[] correctLetter = codeword.ToCharArray();


            if (guess.Length > 1)
            {
                Console.WriteLine("Please enter only one letter at a time.");
                return;
            }
            if (codeword.Contains(guess))
            {
                char userChar = char.Parse(guess);
                Console.WriteLine($"Good Guess! You got the letter {guess}!");
                for (int i = 0; i < correctLetter.Length; i++)
                {
                    if (correctLetter[i] == userChar)
                    {
                        currentWord = currentWord.Remove(i, 1).Insert(i, guess);
                    }
                }
            }
            else if(!codeword.Contains(guess))
            {
                Console.WriteLine("OH NO! _/(O - O)\\_ Bad Guess");
                wrongGuessCount++;
                ship.AddPart();
                guessLeft--;
            }
        }

        public bool DidWin()
        {
            bool youWon = false;
            if (codeword.Equals(currentWord))
            {
                youWon = true;
                Console.WriteLine("========");
                Console.WriteLine("YOU WON!");
                Console.WriteLine("========");
                Console.WriteLine("██████████▀▀▀▀▀▀▀▀▀▀▀▀▀██████████");
                Console.WriteLine("█████▀▀░░░░░░░░░░░░░░░░░░░▀▀█████");
                Console.WriteLine("███▀░░░░░░░░░░░░░░░░░░░░░░░░░▀███");
                Console.WriteLine("██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██");
                Console.WriteLine("█░░░░░░▄▄▄▄▄▄░░░░░░░░▄▄▄▄▄▄░░░░░█");
                Console.WriteLine("█░░░▄██▀░░░▀██░░░░░░██▀░░░▀██▄░░█");
                Console.WriteLine("█░░░██▄░░▀░░▄█░░░░░░█▄░░▀░░▄██░░█");
                Console.WriteLine("██░░░▀▀█▄▄▄██░░░██░░░██▄▄▄█▀▀░░██");
                Console.WriteLine("███░░░░░░▄▄▀░░░████░░░▀▄▄░░░░░███");
                Console.WriteLine("██░░░░░█▄░░░░░░▀▀▀▀░░░░░░░█▄░░░██");
                Console.WriteLine("██░░░▀▀█░█▀▄▄▄▄▄▄▄▄▄▄▄▄▄▀██▀▀░░██");
                Console.WriteLine("███░░░░░▀█▄░░█░░█░░░█░░█▄▀░░░░███");
                Console.WriteLine("████▄░░░░░░▀▀█▄▄█▄▄▄█▄▀▀░░░░▄████");
                Console.WriteLine("███████▄▄▄▄░░░░░░░░░░░░▄▄▄███████");
                Console.WriteLine("==================================");
                Console.WriteLine("    Codeword is: " + codeword);
                Console.WriteLine("Hooray! You rescued your friend!!!");
                Console.WriteLine("==================================");
            }
            return youWon;
        }

        public bool DidLose()
        {
            bool youLose = false;
            if (wrongGuessCount == maxGuess)
            {
                youLose = true;
                Console.WriteLine("===========");
                Console.WriteLine("you lose...");
                Console.WriteLine("===========");
                Console.WriteLine(".....................................______________.......................");
                Console.WriteLine("...............................,.-‘”................``~.,.................");
                Console.WriteLine("..........................,.-”............................“-.,............");
                Console.WriteLine(".......................,/......................................”:,........");
                Console.WriteLine(".....................,?...........................................\\,.....");
                Console.WriteLine(".................../................................................,}....");
                Console.WriteLine("................./............................................,:`^`..}....");
                Console.WriteLine(".............../........................................,:”........../....");
                Console.WriteLine("..............?.....__.................................:`.........../.....");
                Console.WriteLine("............./__.(.....“~-,_........................,:`............/......");
                Console.WriteLine(".........../(_....”~,_........“~,_................,:`............_/.......");
                Console.WriteLine("..........{.._$;_......”=,_.......“-,_.......,.-~-,},......~”;/....}......");
                Console.WriteLine("...........((.....* ~_.......”=-._......“;,,./`..../”............../......");
                Console.WriteLine("...,,,___.\\`~,......“~.,....................`.....}............../.......");
                Console.WriteLine("............(....`=-,,.......`.....................(.........;_,,-”.......");
                Console.WriteLine("............/.`~,......`-...........................\\......../\\.........");
                Console.WriteLine(".............\\`~.*-,...............................|,......./..\\,__.....");
                Console.WriteLine(",,_..........}.>-._\\...............................|................`=~-,");
                Console.WriteLine(".......`=~-,_\\_....`\\,.............................\\...................");
                Console.WriteLine("................`=~-,,.\\,............................\\..................");
                Console.WriteLine(".........................`:,,..........................`\\............__..");
                Console.WriteLine(".............................`=-,.......................,%`>--==``........");
                Console.WriteLine("................................_\\.................._,-%.`\\.............");
                Console.WriteLine("...................................,<`......._|_,-&``......`\\............");
                Console.WriteLine("=====================================");
                Console.WriteLine("      Codeword is: " + codeword);
                Console.WriteLine("  Oh no! Your friend been abducted!");
                Console.WriteLine("=====================================");
            }
            return youLose;
        }
    }
}
