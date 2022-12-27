using BCrypt.Net;
using static BCrypt.Net.BCrypt;

namespace Message_API.Data
{
    public class Encrypt
    {
        private int _cryptkey;

        public Encrypt()
        {
            _cryptkey = 12;
        }

        public string Encrypt_string(string plainText)
        {
            var chypherText = HashPassword(plainText, _cryptkey);
            return chypherText;
        }

        public int passwords_match(string cypherText, string password)
        {
            Boolean password_match = Verify(password, cypherText);
            if (password_match == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
