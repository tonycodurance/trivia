using System;
using System.Collections.Generic;
using System.Linq;
using static Trivia.Category;
using static Trivia.Location;

namespace Trivia
{
    public class Game
    {
        private readonly Players _players = new Players();

        private readonly int[] _location = new int[6];
        private readonly int[] _purses = new int[6];

        private readonly bool[] _inPenaltyBox = new bool[6];

        private int _currentPlayer = 0;
        private bool _isGettingOutOfPenaltyBox;
        private readonly Dictionary<Category, LinkedList<string>> _questionsForCategory;

        public Game()
        {
            var popQuestions = new LinkedList<string>();
            var scienceQuestions = new LinkedList<string>();
            var sportsQuestions = new LinkedList<string>();
            var rockQuestions = new LinkedList<string>();
            for (var i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast("Rock Question " + i);
            }
            
            _questionsForCategory = new Dictionary<Category, LinkedList<string>>
            {
                {Pop, popQuestions},
                {Science, scienceQuestions},
                {Sports, sportsQuestions},
                {Rock, rockQuestions}
            };   
        }

        public bool add(string playerName)
        {
            _players.Add(playerName);
            _location[HowManyPlayers()] = 0;
            _purses[HowManyPlayers()] = 0;
            _inPenaltyBox[HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public void roll(int roll)
        {
            Console.WriteLine(_players[_currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (CurrentPlayerInPenaltyBox())
            {
                if (RolledOdd(roll))
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players[_currentPlayer] + " is getting out of the penalty box");
                    
                    MovePlayer(roll);
                    
                    Console.WriteLine(_players[_currentPlayer] + "'s new location is " + _location[_currentPlayer]);
                    Console.WriteLine("The category is " + GiveCategoryFor((Location)_location[_currentPlayer]));
                    
                    AskQuestion(GiveCategoryFor((Location)_location[_currentPlayer]), _questionsForCategory);
                }
                
                if (!RolledOdd(roll))
                {
                    Console.WriteLine(_players[_currentPlayer] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }
            
            if (!CurrentPlayerInPenaltyBox())
            {
                MovePlayer(roll);

                Console.WriteLine(_players[_currentPlayer] + "'s new location is " + _location[_currentPlayer]);
                Console.WriteLine("The category is " + GiveCategoryFor((Location)_location[_currentPlayer]));
                AskQuestion(GiveCategoryFor((Location)_location[_currentPlayer]), _questionsForCategory);
            }

        }

        public static Category GiveCategoryFor(Location playerLocation)
        {
            var categoryForLocation = new Dictionary<Location, Category>
            {
                {Zero, Pop},
                {Four, Pop},
                {Eight, Pop},
                {One, Science},
                {Five, Science},
                {Nine, Science},
                {Two, Sports},
                {Six, Sports},
                {Ten, Sports},
                {Three, Rock},
                {Seven, Rock},
                {Eleven, Rock}
            };

            return categoryForLocation[playerLocation];
        }

        public bool AnsweredCorrectly()
        {
            if (CurrentPlayerInPenaltyBox())
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    
                    GiveCoinToCurrentPlayer();
                    
                    Console.WriteLine(_players[_currentPlayer] + " now has " + _purses[_currentPlayer] + " Gold Coins.");

                    var currentPlayerNoWinner = !CurrentPlayerWinner();
                    
                    SetNextPlayer();
                    
                    ResetPlayerIfLast();
                    
                    return currentPlayerNoWinner;
                }

                SetNextPlayer();
                    
                ResetPlayerIfLast();
                return true;
            }

            Console.WriteLine("Answer was corrent!!!!");
            GiveCoinToCurrentPlayer();
            Console.WriteLine(_players[_currentPlayer] + " now has " + _purses[_currentPlayer] + " Gold Coins.");

            var currentPlayerIsNoWinner = !CurrentPlayerWinner();
                
            SetNextPlayer();
                
            ResetPlayerIfLast();

            return currentPlayerIsNoWinner;
        }

        private int HowManyPlayers()
        {
            return _players.Count;
        }

        private void CheckPlayerLocationWithinBoundaries()
        {
            if (_location[_currentPlayer] > 11) _location[_currentPlayer] = _location[_currentPlayer] - 12;
        }

        private void MovePlayer(int roll)
        {
            _location[_currentPlayer] = _location[_currentPlayer] + roll;
            CheckPlayerLocationWithinBoundaries();
        }

        private static bool RolledOdd(int roll)
        {
            return roll % 2 != 0;
        }

        private bool CurrentPlayerInPenaltyBox()
        {
            return _inPenaltyBox[_currentPlayer];
        }

        public void AskQuestion(Category category, Dictionary<Category, LinkedList<string>> questionsForCategory)
        {
            Console.WriteLine(questionsForCategory[category].First());
            questionsForCategory[category].RemoveFirst();
        }

        private void GiveCoinToCurrentPlayer()
        {
            _purses[_currentPlayer]++;
        }

        public bool AnsweredIncorrectly()
        {
            Console.WriteLine("Question was incorrectly answered");
            
            PutCurrentPlayerInPenaltyBox();
            Console.WriteLine(_players[_currentPlayer] + " was sent to the penalty box");

            SetNextPlayer();
            
            ResetPlayerIfLast();
            
            return true;
        }

        private void ResetPlayerIfLast()
        {
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }

        private void PutCurrentPlayerInPenaltyBox()
        {
            _inPenaltyBox[_currentPlayer] = true;
        }

        private void SetNextPlayer()
        {
            _currentPlayer++;
        }

        private bool CurrentPlayerWinner()
        {
            return _purses[_currentPlayer] == 6;
        }
    }

    public enum Location
    {
        Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Eleven
    }
}
