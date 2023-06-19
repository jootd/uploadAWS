using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace UploadToAWS.Upload
{
    public class SecretConsumer
    {
        ConfigurationBuilder _builder = null;
        public string AWSAccessKey
        {
            get {
                string returnString = string.Empty;
                try
                {
                    IConfigurationRoot configuration = _builder.Build();
                    returnString = configuration.GetConnectionString("AWSAccessKey");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return returnString;
            }
        }


        public string AWSSecretKey
        {
            get
            {
                string returnString = string.Empty;
                try
                {
                    IConfigurationRoot configuration = _builder.Build();
                    returnString = configuration.GetConnectionString("AWSSecretKey");

                }
                catch (Exception ex) {

                    Console.WriteLine(ex.Message);

                }
                return returnString;


            }
        }
        public SecretConsumer()

        {
            this._builder = (ConfigurationBuilder) new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSecrets.json", optional: false, reloadOnChange: true);
        }

    }
}
