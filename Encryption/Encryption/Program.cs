using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleWriter writer = new ConsoleWriter();

            writer.Write("-_-_-_-_-_-_-_-_-_-_-_CHAOCIPHER_-_-_-_-_-_-_-__-_-_-_-_-", ConsoleColor.Cyan);
            Chaocipher chaocipher = new Chaocipher("HXUCZVAMDSLKPEFJRIGTWOBNYQ", "PTLNBQDEOYSFAVZKGJRIHWXUMC");
            string cypherText = chaocipher.Encrypt("Jo MAN");
            writer.Write($"\n\nCypherText: {cypherText}\n\n", ConsoleColor.White);
            string plainText = chaocipher.Decrypt(cypherText);
            writer.Write($"\n\nPlayinText: {plainText}", ConsoleColor.White);
            writer.Write("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-\n\n\n", ConsoleColor.Cyan);


            writer.Write("-_-_-_-_-_-_AUTOKEY-CIPHER_-_-_-_-_-_-_-", ConsoleColor.Magenta);
            Autokey_Cipher autokey_Cipher = new Autokey_Cipher();
            cypherText = autokey_Cipher.Encrypt("ACCEPT THE GREATER CHALLENGE", "UNICORN");
            writer.Write($"CypherText: {cypherText}", ConsoleColor.White);
            plainText =  autokey_Cipher.Decrypt(cypherText, "UNICORN");
            writer.Write($"PlainText: {plainText}", ConsoleColor.White);
            writer.Write("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-", ConsoleColor.Magenta);

            Console.ReadLine();
        }
    }
}

