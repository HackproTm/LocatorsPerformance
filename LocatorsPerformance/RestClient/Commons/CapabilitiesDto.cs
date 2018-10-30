using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Hackpro.LocatorsPerformance.RestClient.Commons
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class CapabilitiesDto
    {
        public string browserName { get; set; }
        public string platform { get; set; }
        public string version { get; set; }
        public Dictionary<string, object> options = new Dictionary<string, object>();

        public static CapabilitiesDto GetDefaultCapabilities(Browsers browserName)
        {
            switch(browserName)
            {
                case Browsers.Chrome:
                {
                    return new CapabilitiesDto()
                    {
                        browserName = "chrome",
                        platform = "ANY",
                        version = string.Empty,
                        options = new Dictionary<string, object>()
                        {
                            { "extensions", new string[]{} },
                            { "args", new string[]{} }
                        }
                    };
                }
                case Browsers.Firefox:
                {
                    return new CapabilitiesDto()
                    {
                        browserName = "firefox",
                        platform = "ANY",
                        version = string.Empty,
                        options = new Dictionary<string, object>()
                        {
                            { "extensions", new string[]{} },
                            { "args", new string[]{} }
                        }
                    };
                }
                case Browsers.Opera:
                {
                    return new CapabilitiesDto()
                    {
                        browserName = "opera",
                        platform = "ANY",
                        version = string.Empty,
                        options = new Dictionary<string, object>()
                        {
                            { "binary", SystemFunctions.GetOperaBinaryPath() },
                            { "extensions", new string[]{} },
                            { "args", new string[]{} }
                        }
                    };
                }
                case Browsers.Edge:
                {
                    return new CapabilitiesDto()
                    {
                        browserName = "edge",
                        platform = "ANY",
                        version = string.Empty,
                        options = new Dictionary<string, object>()
                        {
                            { "extensions", new string[]{} },
                            { "args", new string[]{} }
                        }
                    };
                }
                case Browsers.InternetExplorer:
                {
                    return new CapabilitiesDto()
                    {
                        browserName = "internet explorer",
                        platform = "ANY",
                        version = string.Empty,
                        options = new Dictionary<string, object>()
                        {
                            { "extensions", new string[]{} },
                            { "args", new string[]{} }
                        }
                    };
                }
                default:
                {
                    return new CapabilitiesDto()
                    {
                        browserName = "chrome",
                        platform = "ANY",
                        version = string.Empty,
                        options = new Dictionary<string, object>()
                        {
                            { "extensions", new string[]{} },
                            { "args", new string[]{} }
                        }
                    };
                }
            }
        }
    }
}
