using NUnit.Framework; // Додати директиву для використання фреймворку тестування NUnit

namespace Lb2.Tests
{
    [TestFixture] // Позначка класу як набору тестів для NUnit
    public class TextProcessorTests
    {
        [Test] // Позначка методу як тесту
        public void CleanUpWords_Test()
        {
            // Arrange
            string inputText = "Test 123 text";
            TextProcessor textProcessor = new TextProcessor(inputText);

            // Act
            string cleanedText = textProcessor.CleanUpWords();

            // Assert
            Assert.AreEqual("Test text", cleanedText); // Перевірка очищеного тексту
        }
    }

    [TestFixture]
    public class NumberInTextProcessorTests
    {
        [Test]
        public void CountNumbers_Test()
        {
            // Arrange
            string inputText = "Test 123 text with 5 numbers";
            NumberInTextProcessor numberInTextProcessor = new NumberInTextProcessor(inputText);

            // Act
            int count = numberInTextProcessor.CountNumbers();

            // Assert
            Assert.AreEqual(2, count); // Перевірка кількості чисел у тексті
        }

        [Test]
        public void FindMin_Test()
        {
            // Arrange
            string inputText = "Test 123 text with -5 and 10";
            NumberInTextProcessor numberInTextProcessor = new NumberInTextProcessor(inputText);

            // Act
            int min = numberInTextProcessor.FindMin();

            // Assert
            Assert.AreEqual(-5, min); // Перевірка знаходження мінімального числа
        }

        [Test]
        public void FindMax_Test()
        {
            // Arrange
            string inputText = "Test 123 text with -5 and 10";
            NumberInTextProcessor numberInTextProcessor = new NumberInTextProcessor(inputText);

            // Act
            int max = numberInTextProcessor.FindMax();

            // Assert
            Assert.AreEqual(123, max); // Перевірка знаходження максимального числа
        }
    }
}
