using System;
using System.Collections;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            var theList = new List<string>();
            Console.Clear();
            while (true)
            {
                string input = "";
                Console.WriteLine($"Count: {theList.Count}");
                Console.WriteLine($"Capacity: {theList.Capacity}");
                Console.WriteLine();
                Console.WriteLine("Please enter: +<word> to Add word, +<word> to Remove word or 0 to Exit to main");
                try
                {
                    input = Console.ReadLine();
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some valid input!");
                }
                char nav = input[0];
                string word = input.Substring(1).Trim();
                Console.Clear();

                switch (nav)
                {
                    case '+':
                        if (word.Length > 0) theList.Add(word);
                        break;

                    case '-':
                        if (word.Length > 0) theList.Remove(word);
                        break;

                    case '0':
                        Console.Clear();
                        return;
                    //break;

                    default:
                        Console.WriteLine("Please enter some valid input (use only + or -)");
                        break;
                }
            }

        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            var theQueue = new Queue<string>();
            Console.Clear();
            while (true)
            {
                string input = "";
                Console.WriteLine($"Count: {theQueue.Count}");
                Console.WriteLine($"Queue: {string.Join(" ,", theQueue.ToArray())}");
                Console.WriteLine();
                Console.WriteLine("Please enter: +<element> to Add element, + to Remove element or 0 to Exit to main");
                try
                {
                    input = Console.ReadLine();
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some valid input!");
                }
                char nav = input[0];
                string word = input.Substring(1).Trim();
                Console.Clear();

                switch (nav)
                {
                    case '+':
                        if (word.Length > 0) theQueue.Enqueue(word);
                        break;

                    case '-':
                        if (theQueue.Count > 0) theQueue.Dequeue();
                        break;

                    case '0':
                        Console.Clear();
                        return;
                    //break;

                    default:
                        Console.WriteLine("Please enter some valid input (use only + or -)");
                        break;
                }
            }

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */


            Console.Clear();
            string input = "";
            while (true)
            {
                Console.WriteLine($"Input: {input}, Reverse: {ReverseText(input)}");

                Console.WriteLine();
                Console.WriteLine("Please enter a string or 0 to Exit to main:");
                try
                {
                    input = Console.ReadLine();
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some valid input!");
                }

                string word = input.Trim();
                Console.Clear();

                if (word == "0")
                {
                    Console.Clear();
                    return;
                }
            }

            static string ReverseText(string str)
            {
                string strRev = "";
                var theStack = new Stack<char>();
                foreach (var c in str) theStack.Push(c);
                while (theStack.Count > 0)
                {
                    strRev += theStack.Pop().ToString();
                }
                return strRev;
            }

        }


        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.Clear();
            string input = "";
            while (true)
            {
                var testStr = (IsWellFormated(input)) ? "OK" : "Wrong";
                Console.WriteLine($"Input: {input}, Well-formed: {testStr}");

                Console.WriteLine();
                Console.WriteLine("Please enter a [string] to check paranthesis or [0] to Exit to main:");
                try
                {
                    input = Console.ReadLine();
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some valid input!");
                }

                string word = input.Trim();
                Console.Clear();

                if (word == "0")
                {
                    Console.Clear();
                    return;
                }
            }

            static bool IsWellFormated(string str)
            {
                var charOpener = new Dictionary<char, char>()
                {
                    { ')','(' },
                    { '}','{' },
                    { ']','[' }
                };
                var theStack = new Stack<char>();
                foreach (var c in str)
                {
                    if (charOpener.ContainsKey(c))
                    {
                        if (theStack.Count < 1 || theStack.Pop() != charOpener[c]) return false;
                    }
                    else
                    {
                        if (charOpener.ContainsValue(c)) theStack.Push(c);
                    }
                    //switch (c)
                    //{
                    //    case '(':
                    //    case '{':
                    //    case '[':


                    //    case ')':
                    //        balaceParanthesis--;
                    //        if (theStack.Count<1 || theStack.Pop() != '(') return false;
                    //        break;

                    //    case '}':
                    //        balaceParanthesis--;
                    //        if (theStack.Count < 1 || theStack.Pop() != '{') return false;
                    //        break;


                    //    case ']':
                    //        balaceParanthesis--;
                    //        if (theStack.Count < 1 || theStack.Pop() != '[') return false;
                    //        break;
                    //}

                }
                return (theStack.Count == 0);
            }

        }

    }
}

/*

0.1) 
stack - enkel direkt lagring i minnet sist in först ut, med snabb access, närmaste block nästa att användas/tas bort genom att flytta pekaren

heap - trädliknande struktur där varje element hanteras/lagras oberoende av varandra mha egna pekare.kräver en speciell garbage collenction

0.2)
Value Type variables lagras i stacken och har direkt minnesallokering.

Reference Type lagras i heap och har indirekt minnesallokering (via pekare).

0.3)
i.är av value-type och x påverkas inte efter initial tilldelning
ii.är av reference type och x pekar på samma värde som y, dvs 4


1.2) antalet element överstiger kapacitet

1.3) kapacitet dubblas

1.4) vore ineffektivt?

1.5) nej

1.6) om max-antalet element är stabilt och prestanda viktigt


2.1) 
a) Kö={} 
b) Kö={-> Kalle}  
c) Kö={-> Greta,Kalle}  
d) Kö={Greta}-> Kalle
e) Kö={-> Stina,Greta}  
f) Kö={Stina}-> Greta
g) Kö={-> Olle,Stina}  


3.1) 
a) Kö=				{} 
b) Kö=		{-> Kalle}  
c) Kö={-> Greta,Kalle}  
d) Kö=Greta<- {Kalle}  
e) Kö={-> Stina,Kalle}  
f) Kö=Stina<- {Kalle}
g) Kö= {-> Olle,Kalle}  

kalle som kom först riskerar att bli fast i kön länge(tills han är ensam kvar)

4.1) Stack

ok
([{}]({}))

wrong
({)}

ok
List<int> lista = new List<int>() { 2, 3, 4 };

wrong
)

wrong
(

wrong
()[


 */



