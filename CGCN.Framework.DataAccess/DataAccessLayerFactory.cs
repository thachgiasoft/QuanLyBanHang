using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CGCN.Framework
{
    public sealed class DataAccessLayerFactory
    {
        // Methods
        private DataAccessLayerFactory()
        {
        }
        public static DataAccessLayerBaseClass GetDataAccessLayer()
        {
            if (ConfigurationManager.AppSettings["ConnectionString"] == null)
            {
                throw new ArgumentNullException("Please specify a 'DataProviderType' and 'ConnectionString' configuration keys in the application configuration file.");
            }
            return GetDataAccessLayer(ConfigurationManager.AppSettings["ConnectionString"].ToString());
        }
        public static DataAccessLayerBaseClass GetDataAccessLayer(bool WebConfig)
        {
            if (WebConfig)
            {
                if (ConfigurationManager.AppSettings["ConnectionString"] == null)
                {
                    throw new ArgumentNullException("Please specify a 'DataProviderType' and 'ConnectionString' configuration keys in the application configuration file.");
                }
                return GetDataAccessLayer(CryptorEngine.Decrypt(ConfigurationManager.AppSettings["ConnectionString"].ToString().Trim(), true));
            }
            return GetDataAccessLayer();
        }
        public static DataAccessLayerBaseClass GetDataAccessLayer(string connectionString)
        {
            return new DataAccessLayerBaseClass(connectionString);
        }
        public static DataAccessLayerBaseClass GetDataAccessLayer(bool WebConfig, bool EnCrypt)
        {
            if (WebConfig)
            {
                if (ConfigurationManager.AppSettings["ConnectionString"] == null)
                {
                    throw new ArgumentNullException("Please specify a 'DataProviderType' and 'ConnectionString' configuration keys in the application configuration file.");
                }
                string cipherString = ConfigurationManager.AppSettings["ConnectionString"].ToString().Trim();
                if (EnCrypt)
                {
                    cipherString = CryptorEngine.Decrypt(cipherString, true);
                }
                return GetDataAccessLayer(cipherString);
            }
            return GetDataAccessLayer();
        }
        public static DataAccessLayerBaseClass GetDataAccessLayer(string connectionString, bool EnCrypt)
        {
            string cipherString = connectionString;
            if (EnCrypt)
            {
                cipherString = CryptorEngine.Decrypt(cipherString, true);
            }
            return new DataAccessLayerBaseClass((cipherString));
        }
    }
}
