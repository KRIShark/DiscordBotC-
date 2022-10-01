using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetBeamMpServersDCBot.data
{
    public class ServerInfo
    {
        public ServerInfo()
        {

        }

        public ServerInfo(string players, string playerslist, string maxplayers, string ip, string location, string port, string dport, string map, bool @private, string sname, string version, string cversion, bool official, string owner, string sdesc, string pps, string modlist, string modstotal, string modstotalsize)
        {
            Players = players;
            Playerslist = playerslist;
            Maxplayers = maxplayers;
            Ip = ip;
            Location = location;
            Port = port;
            Dport = dport;
            Map = map;
            Private = @private;
            Sname = sname;
            Version = version;
            Cversion = cversion;
            Official = official;
            Owner = owner;
            Sdesc = sdesc;
            Pps = pps;
            Modlist = modlist;
            Modstotal = modstotal;
            Modstotalsize = modstotalsize;
        }

        [JsonPropertyName("players")]
        public string Players { get; set; }

        [JsonPropertyName("playerslist")]
        public string Playerslist { get; set; }

        [JsonPropertyName("maxplayers")]
        public string Maxplayers { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("port")]
        public string Port { get; set; }

        [JsonPropertyName("dport")]
        public string Dport { get; set; }

        [JsonPropertyName("map")]
        public string Map { get; set; }

        [JsonPropertyName("private")]
        public bool Private { get; set; }

        [JsonPropertyName("sname")]
        public string Sname { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("cversion")]
        public string Cversion { get; set; }

        [JsonPropertyName("official")]
        public bool Official { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("sdesc")]
        public string Sdesc { get; set; }

        [JsonPropertyName("pps")]
        public string Pps { get; set; }

        [JsonPropertyName("modlist")]
        public string Modlist { get; set; }

        [JsonPropertyName("modstotal")]
        public string Modstotal { get; set; }

        [JsonPropertyName("modstotalsize")]
        public string Modstotalsize { get; set; }
    }
}
