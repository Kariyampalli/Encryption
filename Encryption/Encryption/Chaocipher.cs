using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Encryption
{
    public class Chaocipher
    {
        private string lAlphabet_ct;
        private string rAlphabet_pt;
        ConsoleWriter writer;

        public Chaocipher(string lAlph, string rAlph)
        {
            this.writer = new ConsoleWriter();
            this.lAlphabet_ct = lAlph;// "HXUCZVAMDSLKPEFJRIGTWOBNYQ";
            this.rAlphabet_pt = rAlph;// "PTLNBQDEOYSFAVZKGJRIHWXUMC";
        }

        public string Encrypt(string plainText)
        {
            string cypherText = string.Empty;
            try
            {
                if (!this.ValidateLRAlphabet() || string.IsNullOrEmpty(plainText) || string.IsNullOrWhiteSpace(plainText) || !Regex.IsMatch(plainText, @"^[a-zA-Z ]+$"))
                {
                    writer.Write("!!!!!!!!!!!ENCRYPTOR RECEIVED INVALID INPUT!!!!!!!!!!!!!", ConsoleColor.Red);
                    return null;
                }

                plainText = plainText.ToUpper();
                string right = this.rAlphabet_pt;
                string left = this.lAlphabet_ct;               

                for (int i = 0; i < plainText.Length; i++)
                {
                    if (plainText[i] == ' ')
                    {
                        cypherText += plainText[i];
                    }
                    else
                    {
                        writer.Write($"{left}   {right}", ConsoleColor.White);
                        for (int r = 0; r < right.Length; r++)
                        {
                            if (right[r] == plainText[i])
                            {
                                //Save encrypted value
                                cypherText += left[r];

                                //Rotate 
                                right = right.Substring(r, 26 - r) + right.Substring(0, r); //Cuts left part from the letter equal to plainText[i] in rAlphabet and put the cut part at the end
                                left = left.Substring(r, 26 - r) + left.Substring(0, r); //Does the same
                                left = left[0] + left.Substring(2, 12) + left[1] + left.Substring(14, 12); // first letter + letter between old 3 - old nadir + second later (now beneath nadir) + rest
                                right = right.Substring(1, 25) + right[0]; // "cirlce permutes to the right by one char --> all + first letter
                                right = right.Substring(0, 2) + right.Substring(3, 11) + right[2] + right.Substring(14, 12);  // first and second letter + letter between old 4 - old nadir + third later (now beneath nadir) + rest
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.writer.Write($"!!!!!!!!!!!{ex.Message}!!!!!!!!!!!", ConsoleColor.Red);
                return null;
            }
            return cypherText;
        }

        public string Decrypt(string cypherText)
        {
            string plainText = string.Empty;
            try
            {
                if (!this.ValidateLRAlphabet() || string.IsNullOrEmpty(cypherText) || string.IsNullOrWhiteSpace(cypherText) || !Regex.IsMatch(cypherText, @"^[a-zA-Z ]+$"))
                {
                    writer.Write("!!!!!!!!!!!DECRYPTOR RECEIVED INVALID INPUT!!!!!!!!!!!!!", ConsoleColor.Red);
                    return null;
                }
                cypherText = cypherText.ToUpper();
                string right = this.rAlphabet_pt;
                string left = this.lAlphabet_ct;

                for (int i = 0; i < cypherText.Length; i++)
                {
                    if (cypherText[i] == ' ')
                    {
                        plainText += cypherText[i];
                    }
                    else
                    {
                        writer.Write($"{left}   {right}", ConsoleColor.White);
                        for (int r = 0; r < right.Length; r++)
                        {
                            if (left[r] == cypherText[i])
                            {
                                //Save decrypted value
                                plainText += right[r];
                                right = right.Substring(r, 26 - r) + right.Substring(0, r);
                                left = left.Substring(r, 26 - r) + left.Substring(0, r);
                                left = left[0] + left.Substring(2, 12) + left[1] + left.Substring(14, 12);
                                right = right.Substring(1, 25) + right[0];
                                right = right.Substring(0, 2) + right.Substring(3, 11) + right[2] + right.Substring(14, 12);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.writer.Write($"!!!!!!!!!!!{ex.Message}!!!!!!!!!!!", ConsoleColor.Red);
                return null;
            }
            return plainText;
        }

        private bool ValidateLRAlphabet()
        {
            if(this.lAlphabet_ct == null || this.rAlphabet_pt == null || lAlphabet_ct.Length != rAlphabet_pt.Length || lAlphabet_ct.Length != 26
                || !Regex.IsMatch(this.lAlphabet_ct, @"^[a-zA-Z]+$") || !Regex.IsMatch(this.rAlphabet_pt, @"^[a-zA-Z]+$"))
            {
                this.writer.Write("!!!!!!!!!!!Left or right alphabet had invalid values!!!!!!!!!!!", ConsoleColor.Red);
                return false;
            }
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < alphabet.Length; i++)
            {
                if(!this.lAlphabet_ct.Contains(alphabet[i]) || !this.rAlphabet_pt.Contains(alphabet[i]))
                {
                    this.writer.Write("!!!!!!!!!!!Left or right alphabet don't conain all letters of the alphabet!!!!!!!!!!!", ConsoleColor.Red);
                    return false;
                }
            }
            return true;
        }
    }
}
