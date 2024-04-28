using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lb2
{
    internal class Text
    {
        public string Data { get; private set; }

        public Text(string data = "")
        {
            this.Data = data;
        }

        public Text(RichTextBox textBox)
        {
            // Перевірка чи textBox не є пустим перед використанням
            if (textBox == null)
                throw new ArgumentNullException(nameof(textBox));
            this.Data = textBox.Text;
        }

        // Метод вставки тексту у RichTextBox
        public void InsertTo(RichTextBox textBox)
        {
            if (textBox == null)
                throw new ArgumentNullException(nameof(textBox));
            textBox.Text = this.Data;
        }
    }

    internal abstract class Processor
    {
        public Text Text { get; private set; }

        public Processor(Text text = null) // Текст за замовчуванням тепер може бути null
        {
            this.Text = text ?? new Text(); // Якщо text null, створюємо новий об'єкт Text з порожнім рядком
        }

        public Processor(string text) : this(new Text(text)) // Виклик конструктора з параметром Text
        {
        }
    }

    internal class TextProcessor : Processor
    {
        public TextProcessor(string text) : base(text) {}

        // Метод для очищення тексту від цифр
        public string CleanUpWords()
        {
            try
            {
                string[] words = Regex.Replace(Text.Data, "[0-9]", "", RegexOptions.IgnoreCase)
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Distinct()
                    .ToArray();
                return string.Join(" ", words);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while cleaning up words: {ex.Message}");
                return string.Empty;
            }
        }
    }

    internal class NumberInTextProcessor : Processor
    {
        public NumberInTextProcessor(string text) : base(text) {}

        // Метод для підрахунку кількості чисел у тексті
        public int CountNumbers()
        {
            try
            {
                string[] numbers = this.Text.Data.Split(' ').Where(x => int.TryParse(x, out _)).ToArray();
                return numbers.Length;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while counting numbers: {ex.Message}");
                return 0;
            }
        }

        // Метод для вилучення чисел з тексту
        public int[] ExtractNumbers()
        {
            try
            {
                int[] numbers = this.Text.Data.Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToArray();
                return numbers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while extracting numbers: {ex.Message}");
                return new int[0];
            }

        }

        // Методи для знаходження мінімального та максимального числа у тексті
        public int FindMin()
        {
            return ExtractNumbers().Min();
        }

        public int FindMax()
        {
            return ExtractNumbers().Max();
        }
    }
}
