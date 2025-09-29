using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Localhost.AI.LlmClient.Models;
using Localhost.AI.LlmClient.Services;

namespace Localhost.AI.LlmClient;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly SettingsService _settingsService;
    private readonly OllamaService _ollamaService;
    private ObservableCollection<ChatMessage> _messages;
    private bool _isUserScrolling = false;

    public MainWindow()
    {
        InitializeComponent();
        
        _settingsService = new SettingsService();
        _ollamaService = new OllamaService();
        _messages = new ObservableCollection<ChatMessage>();
        
        ChatItemsControl.ItemsSource = _messages;
        
        // Set up Ollama service with settings
        _ollamaService.SetBaseUrl(_settingsService.Settings.OllamaUrl);
        
        // Test connection on startup
        _ = TestConnectionAsync();
        
        // Add welcome message
        AddMessage("Hello! I'm your AI assistant. How can I help you today?", _settingsService.Settings.BotName, false);
    }

    private async Task TestConnectionAsync()
    {
        try
        {
            var isConnected = await _ollamaService.TestConnectionAsync();
            UpdateConnectionStatus(isConnected);
        }
        catch
        {
            UpdateConnectionStatus(false);
        }
    }

    private void UpdateConnectionStatus(bool isConnected)
    {
        Dispatcher.Invoke(() =>
        {
            if (isConnected)
            {
                ConnectionStatus.Text = "Connected";
                ConnectionStatus.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                ConnectionStatus.Text = "Disconnected";
                ConnectionStatus.Foreground = new SolidColorBrush(Colors.Red);
            }
        });
    }

    private void AddMessage(string content, string sender, bool isUser, bool isError = false)
    {
        var message = new ChatMessage(content, sender, isUser, isError);
        _messages.Add(message);
        
        // Only auto-scroll if user hasn't manually scrolled up
        if (!_isUserScrolling)
        {
            ScrollToBottom();
        }
    }

    private void ScrollToBottom()
    {
        // Use Dispatcher to ensure UI updates are complete before scrolling
        Dispatcher.BeginInvoke(new Action(() =>
        {
            try
            {
                // Scroll to the very bottom to ensure all content is visible
                ChatScrollViewer.ScrollToEnd();
                
                // Additional scroll to ensure content is fully visible above input area
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    ChatScrollViewer.ScrollToVerticalOffset(ChatScrollViewer.ExtentHeight);
                }), DispatcherPriority.Background);
            }
            catch
            {
                // Fallback if ScrollToEnd fails
                ChatScrollViewer.ScrollToVerticalOffset(ChatScrollViewer.ExtentHeight);
            }
        }), DispatcherPriority.Background);
    }

    private async void Send_Click(object sender, RoutedEventArgs e)
    {
        await SendMessage();
    }

    private async void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && !Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
        {
            e.Handled = true;
            await SendMessage();
        }
    }

    private void MessageTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        SendButton.IsEnabled = !string.IsNullOrWhiteSpace(MessageTextBox.Text);
    }

    private async Task SendMessage()
    {
        var message = MessageTextBox.Text.Trim();
        if (string.IsNullOrWhiteSpace(message))
            return;

        // Clear input
        MessageTextBox.Text = string.Empty;
        SendButton.IsEnabled = false;

        // Add user message
        AddMessage(message, _settingsService.Settings.UserName, true);

        try
        {
            // Show typing indicator
            var typingMessage = new ChatMessage("Typing...", _settingsService.Settings.BotName, false);
            _messages.Add(typingMessage);
            ScrollToBottom(); // Scroll when typing indicator appears

            // Send to Ollama
            var response = await _ollamaService.SendMessageAsync(message, _settingsService.Settings.DefaultModel);

            // Remove typing indicator
            _messages.Remove(typingMessage);

            // Add bot response
            if (response.StartsWith("Error:"))
            {
                AddMessage(response, _settingsService.Settings.BotName, false, true);
            }
            else
            {
                AddMessage(response, _settingsService.Settings.BotName, false);
            }
        }
        catch (Exception ex)
        {
            // Remove typing indicator if it exists
            var typingMsg = _messages.FirstOrDefault(m => m.Content == "Typing...");
            if (typingMsg != null)
                _messages.Remove(typingMsg);

            AddMessage($"Error: {ex.Message}", _settingsService.Settings.BotName, false, true);
        }
        finally
        {
            SendButton.IsEnabled = true;
        }
    }

    private async void Settings_Click(object sender, RoutedEventArgs e)
    {
        var settingsWindow = new SettingsWindow(_settingsService, _ollamaService);
        var result = settingsWindow.ShowDialog();

        if (result == true)
        {
            // Settings were saved, update the Ollama service URL
            _ollamaService.SetBaseUrl(_settingsService.Settings.OllamaUrl);
            
            // Test the new connection
            await TestConnectionAsync();
        }
    }

    private void ChatScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        // Check if user has scrolled up from the bottom
        var scrollViewer = sender as ScrollViewer;
        if (scrollViewer != null)
        {
            // If user is near the bottom (within 50 pixels), enable auto-scroll
            var isNearBottom = scrollViewer.VerticalOffset >= (scrollViewer.ExtentHeight - scrollViewer.ViewportHeight - 50);
            _isUserScrolling = !isNearBottom;
        }
    }
}