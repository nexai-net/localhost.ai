using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace Localhost.AI.LlmClient.Converters
{
    public class MarkdownTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length >= 2 && values[0] is string text && values[1] is Brush color)
            {
                return ConvertToInlines(text, color);
            }
            return new List<Inline>();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private List<Inline> ConvertToInlines(string text, Brush color)
        {
            var inlines = new List<Inline>();
            var currentText = text;

            // Handle bold text with **text** or *text*
            var boldPattern = @"(\*\*([^*]+)\*\*|\*([^*]+)\*)";
            var matches = Regex.Matches(currentText, boldPattern);

            int lastIndex = 0;
            foreach (Match match in matches)
            {
                // Add text before the match
                if (match.Index > lastIndex)
                {
                    var beforeText = currentText.Substring(lastIndex, match.Index - lastIndex);
                    inlines.Add(new Run(beforeText) { Foreground = color });
                }

                // Add the bold text
                var boldText = match.Groups[2].Success ? match.Groups[2].Value : match.Groups[3].Value;
                var boldRun = new Run(boldText)
                {
                    FontWeight = FontWeights.Bold,
                    Foreground = color
                };
                inlines.Add(boldRun);

                lastIndex = match.Index + match.Length;
            }

            // Add remaining text
            if (lastIndex < currentText.Length)
            {
                var remainingText = currentText.Substring(lastIndex);
                inlines.Add(new Run(remainingText) { Foreground = color });
            }

            // If no matches were found, return the original text as a single run
            if (inlines.Count == 0)
            {
                inlines.Add(new Run(text) { Foreground = color });
            }

            return inlines;
        }
    }

    public class MarkdownToFlowDocumentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                var flowDoc = new FlowDocument();
                var paragraph = new Paragraph();
                
                // Set default color
                var defaultColor = Brushes.Black;
                if (parameter is SolidColorBrush brush)
                {
                    defaultColor = brush;
                }
                
                // Handle bold text with **text** or *text*
                var boldPattern = @"(\*\*([^*]+)\*\*|\*([^*]+)\*)";
                var matches = Regex.Matches(text, boldPattern);

                int lastIndex = 0;
                foreach (Match match in matches)
                {
                    // Add text before the match
                    if (match.Index > lastIndex)
                    {
                        var beforeText = text.Substring(lastIndex, match.Index - lastIndex);
                        var run = new Run(beforeText) { Foreground = defaultColor };
                        paragraph.Inlines.Add(run);
                    }

                    // Add the bold text
                    var boldText = match.Groups[2].Success ? match.Groups[2].Value : match.Groups[3].Value;
                    var boldRun = new Run(boldText)
                    {
                        FontWeight = FontWeights.Bold,
                        Foreground = defaultColor
                    };
                    paragraph.Inlines.Add(boldRun);

                    lastIndex = match.Index + match.Length;
                }

                // Add remaining text
                if (lastIndex < text.Length)
                {
                    var remainingText = text.Substring(lastIndex);
                    var run = new Run(remainingText) { Foreground = defaultColor };
                    paragraph.Inlines.Add(run);
                }

                // If no matches were found, add the original text
                if (paragraph.Inlines.Count == 0)
                {
                    var run = new Run(text) { Foreground = defaultColor };
                    paragraph.Inlines.Add(run);
                }

                flowDoc.Blocks.Add(paragraph);
                return flowDoc;
            }
            return new FlowDocument();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MarkdownToFlowDocumentMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length >= 2 && values[0] is string text && values[1] is Brush color)
            {
                var flowDoc = new FlowDocument();
                var paragraph = new Paragraph();
                
                // Handle bold text with **text** or *text*
                var boldPattern = @"(\*\*([^*]+)\*\*|\*([^*]+)\*)";
                var matches = Regex.Matches(text, boldPattern);

                int lastIndex = 0;
                foreach (Match match in matches)
                {
                    // Add text before the match
                    if (match.Index > lastIndex)
                    {
                        var beforeText = text.Substring(lastIndex, match.Index - lastIndex);
                        var run = new Run(beforeText) { Foreground = color };
                        paragraph.Inlines.Add(run);
                    }

                    // Add the bold text
                    var boldText = match.Groups[2].Success ? match.Groups[2].Value : match.Groups[3].Value;
                    var boldRun = new Run(boldText)
                    {
                        FontWeight = FontWeights.Bold,
                        Foreground = color
                    };
                    paragraph.Inlines.Add(boldRun);

                    lastIndex = match.Index + match.Length;
                }

                // Add remaining text
                if (lastIndex < text.Length)
                {
                    var remainingText = text.Substring(lastIndex);
                    var run = new Run(remainingText) { Foreground = color };
                    paragraph.Inlines.Add(run);
                }

                // If no matches were found, add the original text
                if (paragraph.Inlines.Count == 0)
                {
                    var run = new Run(text) { Foreground = color };
                    paragraph.Inlines.Add(run);
                }

                flowDoc.Blocks.Add(paragraph);
                return flowDoc;
            }
            return new FlowDocument();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
