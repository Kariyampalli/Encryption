using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Encryption
{
    public class Autokey_Cipher
    {
        private string[] tabulaRecta;
        ConsoleWriter writer;

        public Autokey_Cipher()
        {
            this.writer = new ConsoleWriter();
            this.tabulaRecta = new string[] {
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "BCDEFGHIJKLMNOPQRSTUVWXYZA",
            "CDEFGHIJKLMNOPQRSTUVWXYZAB",
            "DEFGHIJKLMNOPQRSTUVWXYZABC",
            "EFGHIJKLMNOPQRSTUVWXYZABCD",
            "FGHIJKLMNOPQRSTUVWXYZABCDE",
            "GHIJKLMNOPQRSTUVWXYZABCDEF",
            "HIJKLMNOPQRSTUVWXYZABCDEFG",
            "IJKLMNOPQRSTUVWXYZABCDEFGH",
            "JKLMNOPQRSTUVWXYZABCDEFGHI",
            "KLMNOPQRSTUVWXYZABCDEFGHIJ",
            "LMNOPQRSTUVWXYZABCDEFGHIJK",
            "MNOPQRSTUVWXYZABCDEFGHIJKL",
            "NOPQRSTUVWXYZABCDEFGHIJKLM",
            "OPQRSTUVWXYZABCDEFGHIJKLMN",
            "PQRSTUVWXYZABCDEFGHIJKLMNO",
            "QRSTUVWXYZABCDEFGHIJKLMNOP",
            "RSTUVWXYZABCDEFGHIJKLMNOPQ",
            "STUVWXYZABCDEFGHIJKLMNOPQR",
            "TUVWXYZABCDEFGHIJKLMNOPQRS",
            "UVWXYZABCDEFGHIJKLMNOPQRST",
            "VWXYZABCDEFGHIJKLMNOPQRSTU",
            "WXYZABCDEFGHIJKLMNOPQRSTUV",
            "XYZABCDEFGHIJKLMNOPQRSTUVW",
            "YZABCDEFGHIJKLMNOPQRSTUVWX",
            "ZABCDEFGHIJKLMNOPQRSTUVWXY"
           };
        }

        public string Encrypt(string plainText, string primer)
        {
            string cipherText = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(plainText) || string.IsNullOrWhiteSpace(plainText) || !Regex.IsMatch(plainText, @"^[a-zA-Z ]+$") ||
                    string.IsNullOrEmpty(primer) || string.IsNullOrWhiteSpace(primer) || !Regex.IsMatch(primer, @"^[a-zA-Z ]+$"))
                {
                    writer.Write("!!!!!!!!!!!ENCRYPTOR RECEIVED INVALID INPUT!!!!!!!!!!!!!", ConsoleColor.Red);
                    return null;
                }

                plainText = Regex.Replace(plainText.ToUpper(), @"\s+", "");
                primer = Regex.Replace(primer.ToUpper(), @"\s+", "");
                string rk = primer + plainText;

                string runningKey = string.Empty; //runningKey ex. --> Unicornplaintextuni...
                int rki = 0;
                for (int i = 0; i < plainText.Length; i++)
                {
                    runningKey += rk[rki];
                    rki++;

                    if (rki > rk.Length)
                    {
                        rki = 0;
                    }
                }

                writer.Write($"Primer: {primer}", ConsoleColor.White);
                writer.Write($"RunningKey: {runningKey}", ConsoleColor.White);
                writer.Write($"PlainText: {plainText}", ConsoleColor.White);

                //invalid integers to know when to stop
                int x = -1;
                int y = -1;
                for (int i = 0; i < plainText.Length; i++) //Goes through plaintext
                {

                    for (int l = 0; l < tabulaRecta[0].Length; l++) //looks in the first line of the tabula recta (sorted alphabet) what position the current letter of the plainText and runningKey is.
                    {
                        if (tabulaRecta[0][l] == plainText[i])
                        {
                            x = l;
                        }
                        if (tabulaRecta[0][l] == runningKey[i])
                        {
                            y = l;
                        }
                        if (x > -1 && y > -1)
                        {
                            break;
                        }
                    }
                    cipherText += tabulaRecta[y][x]; //Get the encrypted letter 
                    x = -1;  //Set back to invalid values for the next letter to be encrypted 
                    y = -1;
                }
            }
            catch (Exception ex)
            {
                this.writer.Write($"!!!!!!!!!!!{ex.Message}!!!!!!!!!!!", ConsoleColor.Red);
                return null;
            }
            return cipherText;
        }

        public string Decrypt(string cipherText, string primer)
        {
            string plainText = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(cipherText) || string.IsNullOrWhiteSpace(cipherText) || !Regex.IsMatch(cipherText, @"^[a-zA-Z ]+$") ||
                    string.IsNullOrEmpty(primer) || string.IsNullOrWhiteSpace(primer) || !Regex.IsMatch(primer, @"^[a-zA-Z ]+$"))
                {
                    writer.Write("!!!!!!!!!!!DECRYPTOR RECEIVED INVALID INPUT!!!!!!!!!!!!!", ConsoleColor.Red);
                    return null;
                }
                cipherText = Regex.Replace(cipherText.ToUpper(), @"\s+", "");
                primer = Regex.Replace(primer.ToUpper(), @"\s+", "");
                plainText = primer;

                bool done = false;
                for (int i = 0; i < plainText.Length; i++) //Goes through the letters of the plain text with only contains the primer in the beginning
                {
                    foreach (var tr in tabulaRecta) //Goes through the tabula recta and takes the string with the beginning letter of plainText[i]
                    {
                        if (tr[0] == plainText[i])
                        {
                            for (int a = 0; a < tr.Length; a++) //if found go through the string "row" and find where the same letter as cipherText[i]
                            {
                                if (tr[a] == cipherText[i])
                                {
                                    plainText += tabulaRecta[0][a]; //if found take the top value and save it at the end of the plaintext
                                    if (plainText.Length == cipherText.Length + primer.Length) //Do until plaintext is as long as the ciphertext + primer length
                                    {
                                        done = true;
                                    }
                                }
                            }
                        }
                    }
                    if (done)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                this.writer.Write($"!!!!!!!!!!!{ex.Message}!!!!!!!!!!!", ConsoleColor.Red);
                return null;
            }
            return plainText.Substring(primer.Length, plainText.Length - primer.Length);
        }
    }
}

