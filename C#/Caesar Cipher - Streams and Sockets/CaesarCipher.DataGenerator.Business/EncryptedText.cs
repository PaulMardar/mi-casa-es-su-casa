using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iQuest.CaesarCipher.DataGenerator.Business
{
    public class EncryptedText
    {
        public char[] EncryptedChars { get; }

        public EncryptedText(string text)
        {
            EncryptedChars = text == null
                ? new char[0]
                : Encode(text.ToCharArray());
        }

        public EncryptedText(char[] chars)
        {
            EncryptedChars = chars == null
                ? new char[0]
                : Encode(chars);
        }

        private static char[] Encode(IEnumerable<char> chars)
        {
            return chars
                .Select(Encode)
                .ToArray();
        }

        private static char Encode(char c)
        {
            if (char.IsLetter(c))
            {
                if (char.IsLower(c))
                {
                    if (c == 'z')
                        return 'a';

                    int code = c;
                    code++;
                    return (char)code;
                }

                if (char.IsUpper(c))
                {
                    if (c == 'Z')
                        return 'A';

                    int code = c;
                    code++;
                    return (char)code;
                }
            }

            return c;
        }

        public byte[] ToBytes(Encoding encoding)
        {
            return encoding.GetBytes(EncryptedChars);
        }
    }
}