namespace Localhost.AI.Dialog
{
    using Democrite.Framework.Builders;
    using Democrite.Framework.Core.Abstractions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Localhost.AI.Core.Framework;
    using Localhost.AI.Core.Helpers;
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Models.LLM;
    

    /// <summary>
    /// Main entry point for the DialogServer application.
    /// Configures and starts the web API server with dialog processing capabilities.
    /// </summary>
    internal class Program
    {
        static private SessionManager _session;
        static private Config _config;

        /// <summary>
        /// Main entry point for the DialogServer application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            
            Config config = ConfigurationManager.GetFromFile<Config>("config.json");
            Console.WriteLine($"Starting {config.AppName} - {config.AppDescription}");
            Console.WriteLine($"Documentation: {config.AppDocumentationUrl}");
            Console.WriteLine("");
            string AppName = config.AppName ?? "APPx";


            _config = config;
            _session = new SessionManager(_config);
            _session.LogSave("Application started", AppName, "Info");

            var builder = WebApplication.CreateBuilder(args); 

            builder.Services.AddSwaggerGen(s => s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Tuto Demo", Version = "v1" })).AddEndpointsApiExplorer();

            var jsonProcessSeq = Sequence.Build("JFO", fixUid: new Guid("D1F7C7EB-77F7-488A-91D7-77E4D5D16448"), metadataBuilder: m =>
                                         {
                                             m.Description("Dialog Sequence")
                                              .AddTags("chatbot", "nexai");
                                         })
                                         .RequiredInput<string>()
                                         .Use<IDialogInboundVGrain>().Configure("JFO-TABLE").Call((g, i, ctx) => g.DoProcess(i, ctx)).Return
                                         .Use<IContextProcessorVGrain>().Configure("JFO-TABLE").Call((g, i, ctx) => g.DoProcess(i, ctx)).Return
                                         .Use<IEmotionnalInboundProcessorVGrain>().Configure("JFO-TABLE").Call((g, i, ctx) => g.DoProcess(i, ctx)).Return
                                         .Use<IDialogCacheProcessorVGrain>().Configure("JFO-TABLE").Call((g, i, ctx) => g.DoProcess(i, ctx)).Return
                                         .Use<IDialogPreProcessorVGrain>().Configure("JFO-TABLE").Call((g, i, ctx) => g.DoPreProcess(i, ctx)).Return
                                         .Use<IDialogProcessorVGrain>().Configure("JFO-TABLE").Call((g, i, ctx) => g.DoProcess(i, ctx)).Return
                                         .Use<IDialogPostProcessorVGrain>().Configure("JFO-TABLE").Call((g, i, ctx) => g.DoPostProcess(i, ctx)).Return
                                         .Use<IEmotionnalOutboundVGrain>().Configure("JFO-TABLE").Call((g, i, ctx) => g.DoProcess(i, ctx)).Return
                                         .Use<IDialogOutboundVGrain>().Configure("JFO-TABLE").Call((g, i, ctx) => g.DoProcess(i, ctx)).Return
                                         .Build();

            builder.Host.UseDemocriteNode(b =>
            {
                b.WizardConfig()
                .NoCluster()
                .ConfigureLogging(c => c.AddConsole())
                .AddInMemoryDefinitionProvider(d => d.SetupSequences(jsonProcessSeq));
                b.ManualyAdvancedConfig().UseDashboard(options =>
                {
                    options.HostSelf = true;  // host it inside the silo
                    options.Port = 9090;      // <-- change the default 8080 here
                });
            }
                                                );
            var app = builder.Build();
            app.UseSwagger();

            app.MapPost("v1/chat/completions", async (Request d, [FromServices] IDemocriteExecutionHandler handler) =>
            {
                
                d.model = "mistral-small3.1";
                bool hassystem = d.messages.Exists(m => m.role == "system");
                Console.WriteLine($"System prompt present: {hassystem}");

                if(!hassystem)
                {
                    Message systemMessage = new Message
                    {
                        role = "system",
                        content = "be short"
                    };
                    d.messages.Insert(0, systemMessage);
                }



                Completion c = LanguageModelManager.InitializeCompletion();
                c.request = d;

                var id = _session.CompletionSave(c);
                
                /*_session.LogSave($"Request to /aiassistant: {d.messages[d.messages.Count - 1].content}", "DIALOGSERVER_AGENT_PROCESSOR", "Info");*/

                var result = await handler.Sequence<string>(jsonProcessSeq.Uid)
                                       .SetInput(id)
                                       .RunAsync<string>();
                var content = result.SafeGetResult();
                Response rep = new Response();

                try
                {
                    rep = _session.CompletionLoad(content).response;
                    
                }
                catch(Exception ex)
                {
                    _session.LogSave($"Error in /aiassistant: {ex.Message}", AppName, "ERROR");
                }
                return rep;
            });



            app.MapGet("/", (request) =>
            {
                request.Response.Redirect("swagger");
                return Task.CompletedTask;
            });
            app.UseSwaggerUI();

            app.Run();

        }
    }
}
