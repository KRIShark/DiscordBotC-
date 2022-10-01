using Discord;
using Discord.Commands;
using GetBeamMpServersDCBot.data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Example.Modules
{
    [Name("BeamMp Server Info")]
    public class BeamMpServer : ModuleBase<SocketCommandContext>
    {
        private readonly IConfigurationRoot _config;
        private GetBeamMpServers _getBeamMpServers;

        public BeamMpServer(IConfigurationRoot config, GetBeamMpServers getBeamMpServers)
        {
            _config = config;
            _getBeamMpServers = getBeamMpServers;
        }

        [Command("get server info"), Alias("gsf")]
        [Summary("Gets the server info by Server Name")]
        public async Task GetServerInfoByName(string command) 
        {
            List<ServerInfo> servers = _getBeamMpServers.GetServers();
            var myserver = servers.FirstOrDefault(x => x.Sname == command);
            var builder = new EmbedBuilder()
            {
                Color = new Color(114, 137, 218),
                Description = $"Server: "
            };
            builder.AddField(x =>
            {
                x.Name = $"Players:";
                x.Value = $"From {myserver.Maxplayers}/{myserver.Players}";
                x.IsInline = false;
            });
            builder.AddField(x =>
            {
                x.Name = $"Map:";
                x.Value = $"{myserver.Map}";
                x.IsInline = false;
            });
            builder.AddField(x =>
            {
                x.Name = $"Is Official";
                x.Value = myserver.Official?"YES":"NO";
                x.IsInline = false;
            });
            await ReplyAsync("", false, builder.Build());
        }

        
    }
}
