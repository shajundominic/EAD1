// Delegate lab sample soln
// plug and play 2 ciphers

using System;
using System.Text;

delegate string EncryptionDelegate(string plaintext);			

class Cipher
{

    // simple Caeser cipher 
    public static string Cipher1(String plaintext)
    {
        const int key = 1;          // shift by 1 char
        StringBuilder ciphertext = new StringBuilder(plaintext);

        // Unicode max value is (2 ^ 16) - 1
        int wrap = (int)(char.MaxValue);

        // shift each character forwards by key amount
        for (int i = 0; i < ciphertext.Length; i++)
        {
            ciphertext[i] = (char) ((ciphertext[i] + key) % wrap);
        }
        return ciphertext.ToString();

    }

    // simple cipher which reverses a string
    public static string Cipher2(String plaintext)
    {
        char[] text = plaintext.ToCharArray();
        string ciphertext = String.Empty;
        for (int i = text.Length - 1; i >= 0; i--)
        {
            ciphertext += text[i];
        }
        return ciphertext;
        
    }

    public static void Main()
    {       
        EncryptionDelegate ed1 = null;
        ed1 += Cipher1;                                  
        Console.WriteLine(ed1("a secret message"));                            

        EncryptionDelegate ed2 = new EncryptionDelegate(Cipher2);
        Console.WriteLine(ed2("a secret message"));                               

    }
}
