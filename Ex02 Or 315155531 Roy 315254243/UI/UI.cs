using BackEnd;
using System;
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
            //asking if he want another round with the same board and the same users
            while (checkIfOtherRound())
            {
                gameMaimLoop();
            }
        }
        private bool checkIfOtherRound()
        {
            bool toContinue = true;
            string userChoiceIfContinue = getUserChoiceIfContinueForMoreRounds();

            if (userChoiceIfContinue == "no")
            {
                toContinue = false;
            }
            return toContinue;
        }

        private string getUserChoiceIfContinueForMoreRounds()
        {
            string ifContinue;
            bool isValid = false;
            Console.WriteLine("Would you like more rounds? please answer in yes or no");
            ifContinue = Console.ReadLine();

            while (!isValidWantToContinue(ifContinue))
            {
                Console.WriteLine("Wrong selection please try again:");
                ifContinue = Console.ReadLine();
            }
            return ifContinue;
        }
        private bool isValidWantToContinue(string ifContinue)
        {
            if(ifContinue != "yes" || ifContinue != "no")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void gameMaimLoop()
        { 
            bool isFinishGame = false;
            String currentPlayerMove;

            printBoard(m_GameManager.GameBoard);
            Console.WriteLine($"{m_GameManager.CurrPlayer.Name}'s Turn ({m_GameManager.CurrPlayer.PieceSymbol}):");
            currentPlayerMove = movePieceByUserChoice();// first move by the first user //need to add to movePieceByUserChoice option of returning Q string 
            isFinishGame = StringValidator.IsQuitRequest(currentPlayerMove);
            Ex02.ConsoleUtils.Screen.Clear();
            while (!isFinishGame)//the main loop of the game
            {
                printBoard(m_GameManager.GameBoard);
                Console.WriteLine($"{m_GameManager.LastPlayer.Name}'s move ({m_GameManager.LastPlayer.PieceSymbol}) was: {currentPlayerMove}");
                Console.WriteLine($"{m_GameManager.CurrPlayer.Name}'s Turn ({m_GameManager.CurrPlayer.PieceSymbol}):");
                if(StringValidator.IsQuitRequest(currentPlayerMove)){
                    isFinishGame = true;
                }
                else
                {
                    currentPlayerMove = movePieceByUserChoice();
                    Ex02.ConsoleUtils.Screen.Clear();
                }
            }
        }

        private string movePieceByUserChoice()
        {
            ///this function get a move from the player and send that command 
            ///if valid to the gameManager to move the desired piece
            String currentPlayerMove;
            bool isValidInput = false;
            
            currentPlayerMove = Console.ReadLine();
            while (!isValidInput)
            {
                if (!StringValidator.CheckValidMove(currentPlayerMove))
                {
                    Console.WriteLine("Wrong selection, should be in format of ROWcol>ROWcol, please enter valid choice");
                }
                else if (!m_GameManager.MovePiece((Move)currentPlayerMove))
                {
                    Console.WriteLine("You are not allowed to go to this place, please try again");
                }
                else
                {
                    isValidInput = true;
                }
                if(!isValidInput)
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
