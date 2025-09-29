using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Localhost.AI.LlmClient.Converters
{
    public static class MarkdownTextHelper
    {
        public static readonly DependencyProperty FormattedTextProperty =
            DependencyProperty.RegisterAttached("FormattedText", typeof(string), typeof(MarkdownTextHelper),
                new PropertyMetadata(string.Empty, OnFormattedTextChanged));

        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.RegisterAttached("TextColor", typeof(Brush), typeof(MarkdownTextHelper),
                new PropertyMetadata(Brushes.Black, OnFormattedTextChanged));

        public static string GetFormattedText(DependencyObject obj)
        {
            return (string)obj.GetValue(FormattedTextProperty);
        }

        public static void SetFormattedText(DependencyObject obj, string value)
        {
            obj.SetValue(FormattedTextProperty, value);
        }

        public static Brush GetTextColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(TextColorProperty);
        }

        public static void SetTextColor(DependencyObject obj, Brush value)
        {
            obj.SetValue(TextColorProperty, value);
        }

        private static void OnFormattedTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBlock textBlock)
            {
                UpdateTextBlockInlines(textBlock);
            }
        }

        private static void UpdateTextBlockInlines(TextBlock textBlock)
        {
            var text = GetFormattedText(textBlock);
            var color = GetTextColor(textBlock);

            if (string.IsNullOrEmpty(text))
            {
                textBlock.Inlines.Clear();
                return;
            }

            textBlock.Inlines.Clear();

            // Process text for both URLs and bold formatting
            ProcessTextWithFormatting(textBlock, text, color);
        }

        private static void ProcessTextWithFormatting(TextBlock textBlock, string text, Brush color)
        {
            // Combined pattern for URLs and bold text
            // URL pattern: http://, https://, www., or domain with common TLDs
            var urlPattern = @"(https?://[^\s]+|www\.[^\s]+|[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(?:/[^\s]*)?)";
            var boldPattern = @"(\*\*([^*]+)\*\*|\*([^*]+)\*)";
            var combinedPattern = $@"({urlPattern}|{boldPattern})";

            var matches = Regex.Matches(text, combinedPattern);

            int lastIndex = 0;
            foreach (Match match in matches)
            {
                // Add text before the match
                if (match.Index > lastIndex)
                {
                    var beforeText = text.Substring(lastIndex, match.Index - lastIndex);
                    ProcessPlainText(textBlock, beforeText, color);
                }

                var matchedText = match.Value;

                // Check if it's a URL
                if (IsUrl(matchedText))
                {
                    AddClickableUrl(textBlock, matchedText, color);
                }
                // Check if it's bold text
                else if (matchedText.StartsWith("*"))
                {
                    var boldText = match.Groups[2].Success ? match.Groups[2].Value : match.Groups[3].Value;
                    var boldRun = new Run(boldText)
                    {
                        FontWeight = FontWeights.Bold,
                        Foreground = color
                    };
                    textBlock.Inlines.Add(boldRun);
                }
                else
                {
                    // Fallback for any unmatched text
                    ProcessPlainText(textBlock, matchedText, color);
                }

                lastIndex = match.Index + match.Length;
            }

            // Add remaining text
            if (lastIndex < text.Length)
            {
                var remainingText = text.Substring(lastIndex);
                ProcessPlainText(textBlock, remainingText, color);
            }

            // If no matches were found, add the original text
            if (textBlock.Inlines.Count == 0)
            {
                ProcessPlainText(textBlock, text, color);
            }
        }

        private static bool IsUrl(string text)
        {
            return text.StartsWith("http://") || 
                   text.StartsWith("https://") || 
                   text.StartsWith("www.") ||
                   (text.Contains(".") && !text.Contains("*"));
        }

        private static void AddClickableUrl(TextBlock textBlock, string url, Brush color)
        {
            // Ensure URL has protocol
            var fullUrl = url;
            if (url.StartsWith("www."))
            {
                fullUrl = "https://" + url;
            }
            else if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                fullUrl = "https://" + url;
            }

            var hyperlink = new Hyperlink(new Run(url) { Foreground = color })
            {
                NavigateUri = new Uri(fullUrl),
                Foreground = color
            };

            // Add underline to make it look like a link
            hyperlink.TextDecorations = TextDecorations.Underline;

            textBlock.Inlines.Add(hyperlink);
        }

        private static void ProcessPlainText(TextBlock textBlock, string text, Brush color)
        {
            if (!string.IsNullOrEmpty(text))
            {
                textBlock.Inlines.Add(new Run(text) { Foreground = color });
            }
        }
    }
}
