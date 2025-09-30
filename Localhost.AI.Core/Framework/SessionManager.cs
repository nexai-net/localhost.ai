namespace Localhost.AI.Core.Framework
{
    using Data;
    using Localhost.AI.Core.Helpers;
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Models.LLM;
    using Models.Corpus;
    using Nest;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Manages application sessions and provides centralized access to data repositories and business logic.
    /// Handles entity management, logging, caching, and document processing operations.
    /// </summary>
    public class SessionManager
    {
        
        private Config _config;
        protected ESSServerSettings ElasticSearchServerParameters;
        protected ElasticRepository ElasticSearchServer;
        protected ElasticRepository ElasticSearchDialog;
        protected ElasticRepository ElasticSearchAdmin;
        private static SessionManager instance;
        private static object locker = new object();

        /// <summary>
        /// Initializes a new instance of the SessionManager with the specified configuration.
        /// </summary>
        /// <param name="config">The configuration object containing application settings and repository connections.</param>
        /// <exception cref="Exception">Thrown when repository initialization fails.</exception>
        public string DocumentParagraphSave(string text, string documentName, string documentid, int position)
        {
            string ret = "";
            bool addParagraph = false;

            /// get the SHA256 
            string hash = Helpers.CryptographyManager.SHA256HashString(text);



            /// If the paragrah is already available in ES
            try
            {
                Paragraph paragraph = new Paragraph();

                var r = ElasticSearchServer.Load<Paragraph>(hash);

                if (r == null)
                {

                    paragraph.text = text;
                    paragraph.UserName = Environment.UserName;
                    paragraph.Id = hash;
                    paragraph.MachineName = Environment.MachineName;
                    paragraph.Comment = "paragraph id " + hash + " from document" + documentName + ".";
                    paragraph.MetaDatas = new List<MetaData>();
                    paragraph.Date = DateTime.Now;
                    paragraph.includedIns = new List<IncludedIn>();
                    paragraph.lenght = text.Length;
                }
                else
                {
                    paragraph = (Paragraph)r;
                }

                IncludedIn includedIns = new IncludedIn();
                includedIns.documentId = documentid;
                includedIns.documentLocation = documentName;
                includedIns.position = position;

                List<IncludedIn> ne = paragraph.includedIns;

                ne.Add(includedIns);
                List<IncludedIn> newi = ne.Distinct<IncludedIn>().ToList();

                var new3 = ne.DistinctBy(x => (x.documentId.ToUpperInvariant(),
                                x.documentLocation.ToUpperInvariant(),
                                x.position)).ToList();

                paragraph.includedIns = new3;
                string retid = ElasticSearchServer.Save(paragraph);
                ret = retid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }

            return ret;
        }


        public SessionManager(Config config)
        {
            // Store the configuration object
            _config = config;
            try
            {
                // Initialize the main data repository if configured
                if (_config.DataRepository != null)
                {
                    ElasticSearchServerParameters = _config.DataRepository;
                    ElasticSearchServer = new ElasticRepository(ElasticSearchServerParameters);
                }
                
                // Initialize the dialog repository if configured, otherwise use the main server
                if(_config.DialogRepository != null)
                {
                    ElasticSearchServerParameters = _config.DialogRepository;
                    ElasticSearchDialog = new ElasticRepository(ElasticSearchServerParameters);
                }
                else
                {
                    // Use the main server for dialog operations if no separate dialog repository is configured
                    ElasticSearchDialog = ElasticSearchServer;
                }
                
                // Initialize the admin repository if configured, otherwise use the main server
                if(_config.AdminRepository != null)
                {
                    ElasticSearchServerParameters = _config.AdminRepository;
                    ElasticSearchAdmin = new ElasticRepository(ElasticSearchServerParameters);
                }
                else
                {
                    // Use the main server for admin operations if no separate admin repository is configured
                    ElasticSearchAdmin = ElasticSearchServer;
                }
            }
            catch (Exception ex)
            {
                // Re-throw any exceptions that occur during repository initialization
                throw ex;
            }
        }

        /// <summary>
        /// Gets a singleton instance of the SessionManager. Creates a new instance if none exists.
        /// </summary>
        /// <param name="config">The configuration object for initializing the session manager.</param>
        /// <returns>The singleton SessionManager instance.</returns>
        /// <exception cref="Exception">Thrown when session manager creation fails.</exception>
        public static SessionManager Get(Config config)
        {
            try
            {
                // Check if instance already exists (double-checked locking pattern)
                if (instance == null)
                {
                    // Acquire lock to ensure thread-safe singleton creation
                    lock (locker)
                    {
                        // Double-check inside lock to prevent multiple instances
                        if (instance == null)
                        {
                            // Create new singleton instance
                            instance = new SessionManager(config);
                        }
                    }
                }
                // Return the singleton instance
                return instance;
            }
            catch (Exception)
            {
                // Re-throw any exceptions that occur during singleton creation
                throw;
            }
        }

        /// <summary>
        /// Deletes an entity from the data repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete.</param>
        /// <returns>True if the entity was successfully deleted, false otherwise.</returns>
        public bool EntityDelete(string id)
        {
            try
            {
                // Delete the entity from the ElasticSearch server using its ID
                ElasticSearchServer.DeleteImpl<Entity>(id);
                
                // Return true to indicate successful deletion
                return true;
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Return false to indicate deletion failed
                return false;
            }
        }

        public bool CacheDelete(string id)
        {
            try
            {
                // Delete the cache entry from the ElasticSearch server using its ID
                ElasticSearchServer.DeleteImpl<Cache>(id);
                
                // Return true to indicate successful deletion
                return true;
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Return false to indicate deletion failed
                return false;
            }
        }

        /// <summary>
        /// Loads an entity from the data repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to load.</param>
        /// <returns>The loaded Entity object, or null if not found or an error occurs.</returns>
        public Entity EntityLoad(string id)
        {
            // Create a new Entity object as default
            Entity e = new Entity();
            try
            {
                // Load the entity from ElasticSearch using the provided ID
                var ret = ElasticSearchServer.Load<Entity>(id);
                
                // Cast the result to Entity type
                e = (Entity)ret;
                
                // Return the loaded entity
                return e;
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Return null if loading failed
                return null;
            }
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public string CacheSave(Cache c)
        {
            // Initialize return string
            string ret = "";
            try
            {
                // Save the cache object to ElasticSearch and get the returned ID
                ret = ElasticSearchServer.Save<Cache>(c);
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Set return value to empty string on error
                ret = "";
            }
            // Return the ID or empty string
            return ret;
        }


        /// <summary>
        /// Saves a log entry to the admin repository.
        /// </summary>
        /// <param name="comment">The log message or comment.</param>
        /// <param name="appName">The name of the application generating the log.</param>
        /// <param name="type">The type of log entry (INFO, ERROR, WARNING, etc.).</param>
        /// <returns>The unique identifier of the saved log entry.</returns>
        public string LogSave(string comment, string appName, string type            )
        {
            // Create a new Log object with provided parameters
            Log log = new Log()
            {
                Comment = comment,
                AppName = appName,
                Date = DateTime.Now,
                UserName = Environment.UserName,
                MachineName = Environment.MachineName,
                Type = type,
            };
            
            // Save the log to the admin repository and return the ID
            return ElasticSearchAdmin.Save<Log>(log);
        }

        public string SymbolicProcessorSave(SymbolicProcessor sp)
        {
            // Initialize return string
            string ret = "";
            try
            {
                // Save the symbolic processor to ElasticSearch and get the returned ID
                ret = ElasticSearchServer.Save(sp);
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Set return value to empty string on error
                ret = "";
            }
            // Return the ID or empty string
            return ret;
        }

        public string CompletionSave(Completion c)
        {
            // Initialize return string
            string ret = "";
            try
            {
                // Save the completion to the dialog repository and get the returned ID
                ret = ElasticSearchDialog.Save<Completion>(c);
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Set return value to empty string on error
                ret = "";
            }
            // Return the ID or empty string
            return ret;
        }

        public string CompletionUpdate(Completion c)
        {
            // Initialize return string
            string ret = "";
            try
            {
                // Update the completion in the dialog repository and get the returned ID
                ret = ElasticSearchDialog.Save<Completion>(c);
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Set return value to empty string on error
                ret = "";
            }
            // Return the ID or empty string
            return ret;
        }

        public Completion CompletionLoad(string id)
        {
            // Create a new Completion object as default
            Completion c = new Completion();
            try
            {
                // Load the completion from the dialog repository using the provided ID
                var ret = ElasticSearchDialog.Load<Completion>(id);
                
                // Cast the result to Completion type
                c = (Completion)ret;
                
                // Return the loaded completion
                return c;
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Return null if loading failed
                return null;
            }
        }

        public bool DocumentExist(string documentFullName)
        {
            try
            {
                // Generate a hash of the document full name to use as unique identifier
                string hash = CryptographyManager.SHA256HashString(documentFullName);
                
                // Try to load the document from ElasticSearch using the hash
                var r = ElasticSearchServer.Load<Document>(hash);
                
                // Return true if document exists, false otherwise
                if (r != null) return true;
                else return false;
            }
            catch (Exception ex) 
            { 
                // Log the error to console
                Console.WriteLine(ex.ToString()); 
                
                // Return false if any error occurs
                return false; 
            }
        }


        public string ParagrapheSave(Paragraph p)
        {
            // Initialize return string
            string ret = "";
            try
            {
                // Save the paragraph to ElasticSearch and get the returned ID
                ret = ElasticSearchServer.Save(p);
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Set return value to empty string on error
                ret = "";
            }
            // Return the ID or empty string
            return ret;
        }
        public List<Cache> CacheEntriesSearch(string searccriteria)
        {
            // Initialize the result list
            List<Cache> ret = new List<Cache>();
            try
            {
                // Search for cache entries in ElasticSearch using the criteria
                List<Cache> res = ElasticSearchServer.SearchInCache(searccriteria).ToList<Cache>();
                
                // Filter results by checking if the prompt contains the search criteria (case-insensitive)
                foreach (Cache c in res)
                {
                   // Convert both prompt and criteria to lowercase for case-insensitive comparison
                   string loweredPrompt = c.prompt.ToLower();
                   string loweredCriteria = searccriteria.ToLower();
                   
                   // Add to results if the prompt contains the search criteria
                   if (loweredPrompt.Contains(loweredCriteria))
                   {
                            ret.Add(c);
                   }
                }
            }
            catch (Exception ex)
            { 
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Re-throw the exception to propagate the error
                throw ex;
            }
            // Return the filtered list of cache entries
            return ret;
        }


        public List<Cache> CacheSearchByValue(string value)
        {
            // Initialize the result list
            List<Cache> ret = new List<Cache>();
            try
            {
                // Search for entities in ElasticSearch by name and convert to list
                ret = ElasticSearchServer.SearchAllInCache(value);
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());

                // Re-throw the exception to propagate the error
                throw ex;
            }
            // Return the list of found entities
            return ret;
        }


        public List<Entity> EntitySearchByName(string name)
        {
            // Initialize the result list
            List<Entity> ret = new List<Entity>();
            try
            {
                // Search for entities in ElasticSearch by name and convert to list
                ret =  ElasticSearchServer.SearchInEntities(name).ToList<Entity>();
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Re-throw the exception to propagate the error
                throw ex;
            }
            // Return the list of found entities
            return ret;
        }

        public List<SymbolicProcessor> SymbolicProcessorsSearch(string name)
        {
            // Initialize the result list
            List<SymbolicProcessor> ret = new List<SymbolicProcessor>();
            try
            {
                // Search for symbolic processors in ElasticSearch by name and convert to list
                ret = ElasticSearchServer.SearchTextInDocuments<SymbolicProcessor>(name).ToList<SymbolicProcessor>();
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Re-throw the exception to propagate the error
                throw ex;
            }
            // Return the list of found symbolic processors
            return ret;
        }

        public ServiceReturn EntitySave(Entity entity)
        {
            // Initialize the service return object
            ServiceReturn ret = new ServiceReturn();
            
            // If alternative names exist, add the main name and remove duplicates
            if(entity.AlternativeNames != null)
            {
                // Add the entity name to alternative names
                entity.AlternativeNames.Add(entity.Name);
                
                // Remove duplicates from the alternative names list
                entity.AlternativeNames = DedupCollection<string>(entity.AlternativeNames).ToList<string>();
            }
            
            // Initialize the returned ID string
            string returnedId = "";
            try
            {
                // Save the entity to ElasticSearch and get the returned ID
                returnedId = ElasticSearchServer.Save(entity);
                
                // Set success response
                ret.ReturnedId = returnedId;
                ret.Message = "Entity Saved";
            }
            catch (Exception ex)
            {
                // Set error response
                ret.ReturnedId = "-1";
                ret.Message = ex.Message;
                return ret;
            }
            // Return the service result
            return ret;
        }
        public string DocumentParagraphSave(Paragraph p)
        {
            // Initialize return string
            string ret = "";
            try
            {
                // Save the document paragraph to ElasticSearch and get the returned ID
                ret = ElasticSearchServer.Save(p);
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Set return value to empty string on error
                ret = "";
            }
            // Return the ID or empty string
            return ret;
        }
        public string DocumentSave(Document doc)
        {
            // Initialize return string
            string ret = "";
            try
            {
                // Save the document to ElasticSearch and get the returned ID
                ret = ElasticSearchServer.Save(doc);
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine(ex.ToString());
                
                // Log the document save operation to the admin repository
                LogSave(_config.AppName, Environment.MachineName, Environment.UserName, "Document " + doc.Location + " is saved !", "#doc", "INFO");
                
                // Set return value to empty string on error
                ret = "";
            }
            // Return the ID or empty string
            return ret;
        }

        public ServiceReturn LogSave(string AppName, string MachineName, string UserName, string Message, string tags, string Type)
        {
            // Initialize the service return object
            ServiceReturn ret = new ServiceReturn();
            
            // Validate that configuration and admin repository are available
            if (_config == null || ElasticSearchAdmin == null)
            {
                throw new Exception("Config not done");
            }
            
            // Create a new Log object with provided parameters
            Log log = new Log();
            log.Type = Type;
            log.MachineName = MachineName;
            log.UserName = UserName;
            log.AppName = AppName;
            log.Date = DateTime.Now;
            log.Comment = Message;
            
            // Save the log using the LogSave method and get the result
            ret = LogSave(log);
            
            // Return the service result
            return ret;
        }
        
        
        
        public ServiceReturn PerformanceSave(string AppName, string MachineName, string UserName, string Message, string tags, string Type, int durationMS, string componentpart, string componentname)
        {
            // Initialize the service return object
            ServiceReturn ret = new ServiceReturn();
            
            // Validate that configuration and server repository are available
            if (_config == null || ElasticSearchServer == null)
            {
                throw new Exception("Config not done");
            }
            
            // Create a new Performance object with provided parameters
            Performance perf = new Performance();
            perf.ComponentName = componentname;
            perf.ComponentType = componentpart;
            perf.durationMS = durationMS;
            perf.Type = Type;
            perf.MachineName = MachineName;
            perf.UserName = UserName;
            perf.AppName = AppName;
            perf.Date = DateTime.Now;
            perf.Comment = Message;
            
            // Save the performance data using the PerformanceSave method and get the result
            ret = PerformanceSave(perf);
            
            // Return the service result
            return ret;
        }
        public ServiceReturn CompletionSave(string prompt, string completion, string modelName)
        {
            // Initialize the service return object
            ServiceReturn ret = new ServiceReturn();
            
            // Validate that configuration and server repository are available
            if (_config == null || ElasticSearchServer == null)
            {
                throw new Exception("Config not done");
            }
            try
            {
                // Initialize the returned ID string
                string retid = "";
                
                // Create a new Completion object (currently not fully implemented)
                Completion com = new Completion();
               
                // TODO: Complete the implementation of completion saving
                /*com.Date = DateTime.Now;
                com.MachineName = Environment.MachineName;
                retid = ESSServer.Save(com);*/
                
                // Set success response (currently with empty ID)
                ret.Message = retid + " id created. Completion well saved";
                ret.ReturnedId = retid;
            }
            catch (Exception ex)
            {
                // Set error response
                ret.Message = "Error : " + ex.Message;
                Console.WriteLine(ex.ToString());
                ret.ReturnedId = "-1";
            }
            // Return the service result
            return ret;
        }

        public ServiceReturn PerformanceSave(Performance performance)
        {
            // Initialize the service return object
            ServiceReturn ret = new ServiceReturn();

            // Validate that configuration and server repository are available
            if (_config == null || ElasticSearchServer == null)
            {
                throw new Exception("Config not done");
            }

            try
            {
                // Initialize the returned ID string
                string retid = "";
                
                // Save the performance object to ElasticSearch and get the returned ID
                retid = ElasticSearchServer.Save(performance);
                
                // Set success response
                ret.Message = retid + " id created. Log well saved";
                ret.ReturnedId = retid;
            }
            catch (Exception ex)
            {
                // Set error response
                ret.Message = "Error : " + ex.Message;
                Console.WriteLine(ex.ToString());
                ret.ReturnedId = "-1";
            }
            // Return the service result
            return ret;
        }




        public ServiceReturn LogSave(Log log)
        {
            // Initialize the service return object
            ServiceReturn ret = new ServiceReturn();
            
            // Validate that configuration and admin repository are available
            if (_config == null || ElasticSearchAdmin == null)
            {
                throw new Exception("Config not done");
            }

            try
            {
                // Initialize the returned ID string
                string retid = "";
                
                // Save the log object to the admin repository and get the returned ID
                retid = ElasticSearchAdmin.Save(log);
                
                // Set success response
                ret.Message = retid + " id created. Log well saved";
                ret.ReturnedId = retid;
            }
            catch (Exception ex)
            {
                // Set error response
                ret.Message = "Error : " + ex.Message;
                Console.WriteLine(ex.ToString());
                ret.ReturnedId = "-1";
            }
            // Return the service result
            return ret;
        }

        public IEnumerable<T> DedupCollection<T>(IEnumerable<T> input)
        {
            // Create a HashSet to track values we've already seen
            var passedValues = new HashSet<T>();

            // Iterate through each item in the input collection
            foreach (T item in input)
                // Add item to HashSet - returns true if item is new (not duplicate)
                if (passedValues.Add(item)) 
                    // Yield the item only if it's new (not a duplicate)
                    yield return item;
        }

    }
}
