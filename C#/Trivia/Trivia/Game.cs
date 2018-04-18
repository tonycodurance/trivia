﻿using System;
using System.Collections.Generic;
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
        private readonly GameQuestions _gameQuestions = new GameQuestions();
        private readonly GameCoinsWinningCondition _gameWinningCondition = new GameCoinsWinningCondition();

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
                {Three, Geography},
                {Seven, Rock},
                {Eleven, Rock}
            };

            return categoryForLocation[playerLocation];
        }

        public bool add(string playerName)
        {
            var player = new Player(playerName);
            _players.Add(player);
            
            _location[HowManyPlayers()] = 0;
            _purses[HowManyPlayers()] = 0;
            _inPenaltyBox[HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public void roll(int roll)
        {
            Console.WriteLine(_players[_currentPlayer].Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (CurrentPlayerInPenaltyBox())
            {
                if (RolledOdd(roll))
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players[_currentPlayer].Name + " is getting out of the penalty box");

                    MovePlayer(roll);

                    Console.WriteLine(_players[_currentPlayer].Name + "'s new location is " + _location[_currentPlayer]);
                    Console.WriteLine("The category is " + GiveCategoryFor((Location) _location[_currentPlayer]));

                    _gameQuestions.AskQuestion(GiveCategoryFor((Location) _location[_currentPlayer]));
                }

                if (!RolledOdd(roll))
                {
                    Console.WriteLine(_players[_currentPlayer].Name + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
            }

            if (!CurrentPlayerInPenaltyBox())
            {
                MovePlayer(roll);

                Console.WriteLine(_players[_currentPlayer].Name + "'s new location is " + _location[_currentPlayer]);
                Console.WriteLine("The category is " + GiveCategoryFor((Location) _location[_currentPlayer]));
                _gameQuestions.AskQuestion(GiveCategoryFor((Location) _location[_currentPlayer]));
            }
        }

        public bool AnsweredCorrectly()
        {
            if (CurrentPlayerInPenaltyBox())
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");

                    GiveCoinToCurrentPlayer();

                    Console.WriteLine(_players[_currentPlayer].Name + " now has " + _purses[_currentPlayer] +
                                      " Gold Coins.");

                    var currentPlayerNoWinner = !_gameWinningCondition.CurrentPlayerWinner(_purses[_currentPlayer]);

                    _currentPlayer = _players.GetNextPlayer();

                    return currentPlayerNoWinner;
                }

                _currentPlayer = _players.GetNextPlayer();

                return true;
            }

            Console.WriteLine("Answer was corrent!!!!");
            GiveCoinToCurrentPlayer();
            Console.WriteLine(_players[_currentPlayer].Name + " now has " + _purses[_currentPlayer] + " Gold Coins.");

            var currentPlayerIsNoWinner = !_gameWinningCondition.CurrentPlayerWinner(_purses[_currentPlayer]);

            _currentPlayer = _players.GetNextPlayer();

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

        private void GiveCoinToCurrentPlayer()
        {
            _purses[_currentPlayer]++;
        }

        public bool AnsweredIncorrectly()
        {
            Console.WriteLine("Question was incorrectly answered");

            PutCurrentPlayerInPenaltyBox();
            Console.WriteLine(_players[_currentPlayer].Name + " was sent to the penalty box");

            _currentPlayer = _players.GetNextPlayer();

            return true;
        }

        private void PutCurrentPlayerInPenaltyBox()
        {
            _inPenaltyBox[_currentPlayer] = true;
        }
    }

    public enum Location
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Eleven
    }
}