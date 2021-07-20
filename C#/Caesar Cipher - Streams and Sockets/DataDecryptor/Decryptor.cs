namespace DataDecryptor
{
    public class Decryptor
    {
        string alphabetLower = "abcdefghijklmnopqrstuvwxyz";
        string alphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string decrypt(string message, int key)
        {
            var encrypted_message = message.Trim();
            var decrypted_message = "";

            foreach (var c in encrypted_message)
            {
                if (alphabetLower.Contains(c))
                {
                    var position = alphabetLower.IndexOf(c);
                    var new_position = (position - key) % 26;
                    var new_character = alphabetLower[new_position];
                    decrypted_message += new_character;
                    continue;
                }

                if (alphabetUpper.Contains(c))
                {
                    var position = alphabetUpper.IndexOf(c);
                    var new_position = (position - key) % 26;
                    var new_character = alphabetUpper[new_position];
                    decrypted_message += new_character;
                }
                else
                {
                    decrypted_message += c;
                }
            }
            return decrypted_message;
        }

        public string decryptCesarCodeBasic(string message)
        {
            return decrypt(message, 1);
        }
    }
}
