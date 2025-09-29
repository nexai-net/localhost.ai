# Localhost.AI.LlmClient

A modern WPF chatbot application that connects to Ollama for AI-powered conversations.

## Features

- 🤖 **AI Chat Interface**: Clean, modern chat UI with message bubbles
- ⚙️ **Configurable Settings**: Easy setup for Ollama URL and model selection
- 🔗 **Connection Status**: Real-time connection status indicator
- 💬 **Real-time Messaging**: Send messages and receive AI responses
- 🎨 **Modern UI**: Beautiful, responsive design with Material Design elements
- ⏰ **Timestamps**: Optional message timestamps
- 📜 **Auto-scroll**: Automatic scrolling to new messages
- 🔧 **Settings Persistence**: Settings are saved and restored between sessions

## Prerequisites

1. **Ollama**: Make sure Ollama is installed and running on your system
   - Download from: https://ollama.ai/
   - Install and start the Ollama service
   - Pull a model (e.g., `ollama pull llama2`)

2. **.NET 9.0**: The application requires .NET 9.0 or later

## Installation

1. Clone or download this project
2. Navigate to the project directory
3. Build the application:
   ```bash
   dotnet build
   ```

## Running the Application

1. Start Ollama service (if not already running):
   ```bash
   ollama serve
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

## Configuration

1. Click the **Settings** button (⚙️) in the top-right corner
2. Configure the following settings:
   - **Ollama URL**: Default is `http://localhost:11434`
   - **Default Model**: Select from available models or enter a custom one
   - **Your Name**: Name displayed for your messages
   - **Assistant Name**: Name displayed for AI responses
   - **Auto-scroll**: Automatically scroll to new messages
   - **Show Timestamps**: Display timestamps on messages

3. Click **Test Connection** to verify Ollama connectivity
4. Click **Save** to apply settings

## Usage

1. **Start a Conversation**: Type your message in the input field at the bottom
2. **Send Messages**: Press Enter or click the Send button
3. **View Responses**: AI responses appear as chat bubbles
4. **Connection Status**: Check the top-left for connection status (Connected/Disconnected)

## Troubleshooting

### Connection Issues
- Ensure Ollama is running (`ollama serve`)
- Check the Ollama URL in settings
- Verify the model is available (`ollama list`)

### Model Issues
- Make sure the selected model is pulled (`ollama pull <model-name>`)
- Check that the model name is correct in settings

### Application Issues
- Restart the application if it becomes unresponsive
- Check Windows Event Viewer for detailed error logs

## Project Structure

```
Localhost.AI.LlmClient/
├── Models/
│   ├── AppSettings.cs          # Application settings model
│   └── ChatMessage.cs          # Chat message model
├── Services/
│   ├── OllamaService.cs        # Ollama API communication
│   └── SettingsService.cs      # Settings management
├── Converters/
│   └── MessageStyleConverter.cs # UI data converters
├── MainWindow.xaml             # Main chat interface
├── SettingsWindow.xaml         # Settings dialog
└── README.md                   # This file
```

## Dependencies

- **Newtonsoft.Json**: JSON serialization/deserialization
- **System.Net.Http**: HTTP client for API communication
- **WPF**: Windows Presentation Foundation for UI

## License

This project is open source and available under the MIT License.

## Contributing

Feel free to submit issues, feature requests, or pull requests to improve this application.

