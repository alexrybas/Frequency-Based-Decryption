using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Solution
{
    static void Main(string[] args)
    {
        string message = Console.ReadLine();


        string alphabetNew = "";
        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        string result = string.Empty;

        int lenAlphabet = alphabet.Length;
        Console.Error.WriteLine($"message = {message}");

        List<(char, int)> listOfLetters = new List<(char, int)>();

        for (int i = 0; i < lenAlphabet; i++)
        {
            char ch = alphabet[i];
            int countCh = message.ToCharArray().Count(c => c == char.ToLower(ch) || c == char.ToUpper(ch));
            listOfLetters.Add((ch, countCh));
        }

        listOfLetters = listOfLetters.OrderByDescending(t => t.Item2).ToList();

        for (int i = 0; i < lenAlphabet; i++)
        {
            char ch = listOfLetters[i].Item1;
            int countCh = listOfLetters[i].Item2;
            Console.Error.WriteLine($"{ch}: {countCh} times");
        }

        int indexE = alphabet.IndexOf('e');

        char ch0 = listOfLetters[0].Item1;

        int indexCh = alphabet.IndexOf(ch0);

        int shift = indexCh - indexE;

        if (shift < 0)
        {
            shift = (shift % lenAlphabet) + lenAlphabet;
        }
        Console.Error.WriteLine($"indexE : {indexE}, indexCh : {indexCh}, shift : {shift}");

        for (int i = 0; i < lenAlphabet; i++)
        {
            alphabetNew += alphabet[(i + shift) % lenAlphabet];
        }

        for (int i = 0; i < message.Length; i++)
        {
            char ch = message[i];
            int index = alphabetNew.IndexOf(char.ToLower(ch));
            if (index == -1)
            {
                result += ch;
            }
            else
            {
                if (ch == char.ToLower(ch))
                {
                    result += alphabet[index];
                }
                else
                {
                    result += char.ToUpper(alphabet[index]);
                }
            }
        }

        Console.Error.WriteLine($"alphabet :    {alphabet}");
        Console.Error.WriteLine($"alphabet new: {alphabetNew}");

        Console.WriteLine(result);
    }
}