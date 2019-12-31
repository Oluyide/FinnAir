using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FinnAir.Api.Options
{
    /// <summary>
    /// Web Server Configurations. 
    /// </summary>
    public class WebServerUrl
    {
        /// <summary>
        /// Defines section name in appsettings
        /// </summary>
        public const string SectionName = "webServerUrl";

        /// <summary>
        /// Path to IIS
        /// </summary>
        public string AppVirtualDir { get; set; }

        /// <summary>
        /// Issuer
        /// </summary>
        public string TokenIssuer { get; set; }

        /// <summary>
        /// Audience
        /// </summary>
        public string TokenAudience { get; set; }

        /// <summary>
        /// Identity server path
        /// </summary>
        public string IdentityServer { get; set; }

        /// <summary>
        /// Returns <see cref="WebServerUrl"/> object from configuration
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>Instance of <see cref="WebServerUrl"/></returns>
        public static WebServerUrl GetFromConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection(SectionName).Get<WebServerUrl>();
        }
    }
}
