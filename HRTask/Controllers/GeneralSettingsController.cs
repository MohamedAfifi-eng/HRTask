using HRTask.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace HRTask.Controllers
{
    [Authorize]
    public class GeneralSettingsController : Controller
    {
        private  IConfiguration configuration;

        public GeneralSettingsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [AccessFilter("general settingsView")]

        public IActionResult Index()
        {
            int x = 80;
            AddOrUpdateAppSetting<int>("GeneralSettings:Extra", 80);
            configuration["GeneralSettings:Extra"] = x.ToString();
            string s = configuration.GetValue<string>("GeneralSettings:Extra");
            return View();
        }
        [AccessFilter("general settingsView")]

        public IActionResult Get()
        {
            
            string s = configuration.GetValue<string>("GeneralSettings:Extra");
            return Content(s);
        }
        public static void AddOrUpdateAppSetting<T>(string key, T value)
        {
            try
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "appSettings.json");
                StreamReader sr = new StreamReader(filePath);
                
                string json = sr.ReadToEnd();
                sr.Close();
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                var sectionPath = key.Split(":")[0];

                if (!string.IsNullOrEmpty(sectionPath))
                {
                    var keyPath = key.Split(":")[1];
                    jsonObj[sectionPath][keyPath] = value;
                }
                else
                {
                    jsonObj[sectionPath] = value; // if no sectionpath just set the value
                }

                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                StreamWriter writer = new StreamWriter(filePath);
                writer.Write(output);
                writer.Close();
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
