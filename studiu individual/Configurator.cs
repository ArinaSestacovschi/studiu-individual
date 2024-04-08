using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studiu_individual
{
    internal class Configurator
    {
        private readonly string _FileName;
        private string _connectionString = "";
        public string ConnectionString { get { return _connectionString; } }
        public Configurator(string appSettingsFileName)
        {
            _FileName = appSettingsFileName;
            Bind();
        }

        private void Bind()
        {
            string jsonString = File.ReadAllText(_FileName);
            try
            {
                dynamic data = JsonConvert.DeserializeObject<Object>(jsonString);
                _connectionString = data.ConnectionStrings.SqliteDbName;
            }
            catch (Exception)
            {
                throw new Exception($"Error on parsing the {_FileName}");
            }
        }
    }
}
