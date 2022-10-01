using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace GetBeamMpServersDCBot.data
{
    public class GetBeamMpServers
    {
        private string url;
        private readonly IConfigurationRoot _config;

        public GetBeamMpServers(IConfigurationRoot config)
        {
            url = config["BeamMp:url"];
        }

        public List<ServerInfo> GetServers() 
        {
            var jsonString = new WebClient().DownloadString(url);
            List<ServerInfo> json = JsonSerializer.Deserialize<List<ServerInfo>>(jsonString);
            return json;
        }
    }
}
