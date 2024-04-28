using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lb2
{
    internal class Texter
    {
        public string text { get; private set; }

        public Texter(RichTextBox tb)
        {Data = tb.Text;}

        public void Fill(RichTextBox tb)
        {
            if (tb.Text != "")
                text = tb.Text;
            else
                tb.Text = text;
        }

        public string NumNumbers(RichTextBox box1)
        {
            this.Fill(box1);
            string[] res = Data.Split(' ').Where(x => int.TryParse(x, out int n)).ToArray();
            return Convert.ToString(res.Length);
        }

        public string MinMax(RichTextBox textBox)
        {
            this.Fill(textBox);
            int[] res = Data.Split(' ').
                Where(x => int.TryParse(x, out int n)).ToArray().
                Select(int.Parse).ToArray();
            return ("Maximum - " + Convert.ToInt32(res.Max()) + "\n" +
                "Minimum - " + Convert.ToInt32(res.Min()));
        }

        public void Word(RichTextBox textBox)
        {
            string[] words = (Regex.Replace(Data, "[0-9]", "")).
                Split(' ').Where(x => !String.IsNullOrWhiteSpace(x)).ToList().Distinct().ToArray();
            string res = String.Join('\t', words);
            textBox.Text = res;
        }
    }
}
