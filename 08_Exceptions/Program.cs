using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Exceptions
{
    class Program
    {
        static void Main()
        {
            FindWordExample();
        }

        public static void FindWordExample()
        {
            Console.WriteLine("Please enter the word you wish to find:");
            string wordToFind = Console.ReadLine();
            try
            {
                if (File.Exists(@"C:\stam.txt"))
                {
                    int resultIdx = IndexOfWordInFile(wordToFind, @"C:\stam.txt");
                    if (resultIdx > -1)
                    {
                        Console.WriteLine("The word {0} was found in index {1}", wordToFind, resultIdx);
                    }
                    else
                    {
                        Console.WriteLine("The word {0} was not found in the file :(", wordToFind);
                    }
                }
            }
            catch (FileNotFoundException i_FileNotFoundException)
            {
                Console.WriteLine("Catching FileNotFoundException:");
                Console.WriteLine(i_FileNotFoundException.Message);
            }
            catch (OutOfMemoryException i_OutOfMemoryException)
            {
                Console.WriteLine("Catching OutOfMemoryException:");
                Console.WriteLine(i_OutOfMemoryException.Message);
            }
            catch (AccessViolationException i_AccessViolationException)
            {
                Console.WriteLine("Catching AccessViolationException:");
                Console.WriteLine(i_AccessViolationException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catching Exception:");
                Console.WriteLine(ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("ex has an inner exception of type " + ex.InnerException.GetType().Name);
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
            // this will catch unmanaged exceptions:
            catch
            {
            }
        }

        public static int IndexOfWordInFile(string i_WordToFind, string i_FilePath)
        {
            int result = -1;
            try
            {
                openFile(i_FilePath);
                string fileAsString;
                readFromFile(i_FilePath, 0, out fileAsString);
                result = fileAsString.IndexOf(i_WordToFind);
                return result;// the "finally" block will be executed before returning
            }
            catch (Exception ex)
            {
                //encapsulating the specific exception with a top level one:
                FindInFileException findInFileException = new FindInFileException(ex, i_WordToFind, i_FilePath);
                throw findInFileException;
            }
            finally
            {
                CloseFile(i_FilePath);
            }
        }

        private static void openFile(string i_FilePath)
        {
            Console.WriteLine("Opening file " + i_FilePath);
            if (!System.IO.File.Exists(i_FilePath))
            {
                Console.WriteLine("-Before throwing FileNotFoundException-");
                FileNotFoundException fnfe = new FileNotFoundException("Exception: File " + i_FilePath + " was not found");
                throw fnfe;
            }
            else
            {
                Console.WriteLine("-Before throwing OutOfMemoryException-");
                throw new OutOfMemoryException();
            }
        }

        private static void readFromFile(string i_FilePath, int i_StartIdx, out string o_FileAsString)
        {
            o_FileAsString = "";

            Console.WriteLine("-Before throwing AccessViolationException-");
            throw new AccessViolationException();
        }

        private static void closeFile(string i_FilePath)
        {
            Console.WriteLine("Closing file " + i_FilePath);
        }
    }


    public class FindInFileException : Exception
    {
        private string m_FilePath;
        public string FilePath
        {
            get { return m_FilePath; }
        }

        private string m_Word;
        public string Word
        {
            get { return m_Word; }
        }

        public FindInFileException(Exception i_InnerException, string i_Word, string i_FilePath)
            // sending two params to the base CTOR:
            : base(string.Format("An error occured while trying to find the word {0} in file {1}", i_Word, i_FilePath),
            i_InnerException)
        { }
    }
}
