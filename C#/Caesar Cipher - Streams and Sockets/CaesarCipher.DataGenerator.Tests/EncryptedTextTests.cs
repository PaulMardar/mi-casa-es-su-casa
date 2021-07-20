using iQuest.CaesarCipher.DataGenerator.Business;
using Xunit;

namespace iQuest.CaesarCipher.DataGenerator.Tests
{
    public class EncryptedTextTests
    {
        [Fact]
        public void HavingLowerCaseA_WhenEncrypted_ThenReturnsLowerCaseB()
        {
            char[] originalChars = { 'a' };
            char[] expectedChars = { 'b' };

            PerformTest(originalChars, expectedChars);
        }

        [Fact]
        public void HavingLowerCaseZ_WhenEncrypted_ThenReturnsLowerCaseA()
        {
            char[] originalChars = { 'z' };
            char[] expectedChars = { 'a' };

            PerformTest(originalChars, expectedChars);
        }
        [Fact]
        public void HavingUpperCaseA_WhenEncrypted_ThenReturnsUpperCaseB()
        {
            char[] originalChars = { 'A' };
            char[] expectedChars = { 'B' };

            PerformTest(originalChars, expectedChars);
        }

        [Fact]
        public void HavingUpperCaseZ_WhenEncrypted_ThenReturnsUpperCaseA()
        {
            char[] originalChars = { 'Z' };
            char[] expectedChars = { 'A' };

            PerformTest(originalChars, expectedChars);
        }

        [Fact]
        public void HavingMultipleLetters_WhenEncrypted_ThenReturnsCorrectlyEncrypted()
        {
            char[] originalChars = { 'A', 'l', 'e', 'z' };
            char[] expectedChars = { 'B', 'm', 'f', 'a' };

            PerformTest(originalChars, expectedChars);
        }

        private static void PerformTest(char[] originalChars, char[] expectedChars)
        {
            EncryptedText encryptedText = new EncryptedText(originalChars);

            char[] actualChars = encryptedText.EncryptedChars;

            Assert.Equal(expectedChars, actualChars);
        }
    }
}