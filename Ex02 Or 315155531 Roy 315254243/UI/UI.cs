﻿using BackEnd;
using System;
using System.Runtime.Serialization.Formatters;
using System.Security.Policy;
using Utils;

namespace UI
{
    public class UI
    {
        private Menu m_Menu = new Menu();
        private GameManager m_GameManager;

        public void GameMainLoop()
        {
            bool isContinueGame = true;
            while (isContinueGame == true)
            {
                printMenu();
                Menu.eMenuSelect userSelection = getUserSelection();
                Ex02.ConsoleUtils.Screen.Clear();
                switch (userSelection)
                {
                    case Menu.eMenuSelect.StartGame:
                        startGame();
                        break;
                    case Menu.eMenuSelect.Quit:
                        quit();
                        break;

                }
                   
            }

        }

        private void printMenu()
        {
            Console.WriteLine(m_Menu.MenuStr);
        }

        private Player getPlayerFromUser()
        {
            string playerName = " ";
            bool isPc = false;

            while (!StringValidator.IsValidName(playerName))
            {
                Console.WriteLine("Please enter name");
                playerName = Console.ReadLine();
            }
            if(playerName.ToLower() == "pc")
            {
                isPc = true;
            }

            return new Player(playerName, isPc);
        }
        
        private Menu.eMenuSelect getUserSelection()
        {
            Menu.eMenuSelect userSelection;
            int userIntChoice;
            string userChoice;
            
            Console.WriteLine("Enter Choice");
            userChoice = Console.ReadLine();
            while(!StringValidator.ToIntRange(Enums.GetMinValue<Menu.eMenuSelect>(),
                                        Enums.GetMaxValue<Menu.eMenuSelect>(),
                                        userChoice,
                                        out userIntChoice))
            {
                Console.WriteLine("Enter Choice");
                userChoice = Console.ReadLine();
            }

            userSelection = (Menu.eMenuSelect)userIntChoice;
            return userSelection;
        }
        private void startGame()
        {
            Player player1 = getPlayerFromUser();
            int boardSize = getBoardSize();
            Console.WriteLine("Please enter opponent name, or enter PC in order to play against the PC");
            Player player2 = getPlayerFromUser();
            Ex02.ConsoleUtils.Screen.Clear();
            printBoard(boardSize);
            m_GameManager = new GameManager(player1, player2);
        }

        private void quit()
        {
            if (m_GameManager != null)
            {
                m_GameManager.QuitGame();
            }
            Environment.Exit(0);
        }

        private int getBoardSize()
        {
            string boardSize = "0";

            while (!StringValidator.IsValidBoardSize(boardSize))
            {
                Console.WriteLine("Please enter the board size, avaliable options are: 6,8,10");
                boardSize = Console.ReadLine();
            }

            return int.Parse(boardSize);
        }

        private void printBoard(int i_Size)
        {
            printLetterRow(i_Size);
            for (int i = 0; i < i_Size; i++)
            {
                printSepperator(i_Size);
                printBoardRow(i_Size, " O O O O", i);
            }
        }

        private void printLetterRow(int i_Size)
        {
            char ch = 'A';
            Console.Write(" ");
            for (int i = 0; i < i_Size; i++)
            {
                Console.Write($"   {(char)(ch+i)}");
            }
            Console.WriteLine();
        }
        
        private void printSepperator(int i_Size)
        {
            char ch = '=';

            Console.Write("  ");
            for (int i = 0; i < i_Size; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(ch);
                }
            }
            Console.Write(ch.ToString()+ "\n");
        }

        private void printBoardRow(int i_Size, String i_Raw, int rowIndex)
        {
            char seperator = '|', rowLeter = (char)('a' + rowIndex);

            Console.Write(" ");
            Console.Write($"{(char)(rowLeter)}");
            for (int i = 0; i < i_Size; i++)
            {
                Console.Write($"{seperator} {i_Raw[i]} ");
            }
            Console.WriteLine(seperator);
        }

    }
}
