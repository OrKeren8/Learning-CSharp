using BackEnd;
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

        public void MenuLoop()
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

        private Player getPlayerFromUser(ePieceSymbol i_PieceSymbol)
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

            return new Player(playerName, isPc, i_PieceSymbol);
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
            Player player1 = getPlayerFromUser(ePieceSymbol.O);
            int boardSize = getBoardSize();
            Console.WriteLine("Please enter opponent name, or enter PC in order to play against the PC");
            Player player2 = getPlayerFromUser(ePieceSymbol.X);
            Ex02.ConsoleUtils.Screen.Clear();
            m_GameManager = new GameManager(player1, player2, boardSize);
            gameMaimLoop();
        }

        private void gameMaimLoop()
        {
            bool isFinishGame = false;
            bool firstPlayerTurn = true;
            String currentPlayerMove;
            bool doubleBoubleMove;

            while (!isFinishGame)//the main loop of the game
            {
                printBoard(m_GameManager.getBoard);
                if (firstPlayerTurn)
                {
                    currentPlayerMove = movePieceByUserChoice(m_GameManager.Player1, out doubleBoubleMove);
                    firstPlayerTurn = (false || doubleBoubleMove);
                }else
                {
                    currentPlayerMove = movePieceByUserChoice(m_GameManager.Player2, out doubleBoubleMove);
                    firstPlayerTurn = !doubleBoubleMove;//if true-second player turn, false-first
                }
                Ex02.ConsoleUtils.Screen.Clear();
            }
        }

        private string movePieceByUserChoice(Player i_Player, out bool i_DoubleBoubleMove)
        {
            ///this function get a move from the player and send that command 
            ///if valid to the gameManager to move the desired piece
            String currentPlayerMove;
            bool isValidMove = false;
            i_DoubleBoubleMove = false;

            Console.WriteLine($"{i_Player.Name}'s turn:");
            currentPlayerMove = Console.ReadLine();
            while (!isValidMove)
            {
                if (!StringValidator.CheckValidMove(currentPlayerMove))
                {
                    Console.WriteLine("Wrong selection, should be in format of ROWcol>ROWcol, please enter valid choice");
                }
                else if (!m_GameManager.MovePiece(currentPlayerMove, i_Player, out i_DoubleBoubleMove))
                {
                    Console.WriteLine("You are not allowed to go to this place, please try again");
                }
                else
                {
                    isValidMove = true;
                }
                if(!isValidMove)
                {
                    currentPlayerMove = Console.ReadLine();
                }
            }
            
            return currentPlayerMove;
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

        private void printBoard(Board i_Board)
        {
            printLetterRow(i_Board.Size);
            for (int i = 0; i < i_Board.Size; i++)
            {
                printSepperator(i_Board.Size);
                printBoardRow(i_Board.Size, i_Board.GetRowSymbols(i), i);
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
