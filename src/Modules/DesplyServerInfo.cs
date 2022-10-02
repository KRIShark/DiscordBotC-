using Discord;
using Discord.Commands;
using Discord.WebSocket;
using GetBeamMpServersDCBot.data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly DiscordSocketClient _discord;

        //private Discord.Rest.RestUserMessage msg;
        private IUserMessage msg;

        public BeamMpServer(IConfigurationRoot config, GetBeamMpServers getBeamMpServers, DiscordSocketClient discord)
        {
            _config = config;
            _getBeamMpServers = getBeamMpServers;
            _discord = discord;
        }

        [Command("get server info"), Alias("gsf")]
        [Summary("Gets the server info by Server Name")]
        public async Task GetServerInfoByName(string command) 
        {
            List<ServerInfo> servers = _getBeamMpServers.GetServers();
            var myserver = servers.FirstOrDefault(x => x.Sname == command);

            await ReplyAsync("", false, GetServerEmbed(myserver));
        }

        [Command("getDefServerInfo"), Alias("gdsf")]
        [Summary("Gets the server info by Config")]
        public async Task GetServerInfo(/*IUserMessage message*/)
        {
            
            List<ServerInfo> servers = _getBeamMpServers.GetServers();
            var myserver = servers.FirstOrDefault(x => x.Owner == _config["BeamMp:owner"]);
            if (myserver == null)
            {
                await ReplyAsync("Server Not Found", false);
            }
            else
            {
                var embed = GetServerEmbed(myserver);
                msg = await ReplyAsync("", false, embed);
                Helper.RunntimeTemp.UserMessage = msg;
                //msg = await socketMessageChannel.SendMessageAsync("", false, GetServerEmbed(myserver));
            }
            //await ReplyAsync("", false, builder.Build());
        }

        [Command("EnableAutoUpdate"), Alias("eau")]
        [Summary("Gets the server info by Config Automaticly")]
        public async Task EnabelAutoUpdate()
        {
            bool onOff = false;
            string filename = "settings.dat";
            if (File.Exists(filename))
            {
                var settings = Example.Helper.SerializToFile.DeSerializ<GetBeamMpServersDCBot.data.BeamMP_Config>(filename);
                if (settings != null)
                {
                    onOff = !settings.UpdateAuto;
                    settings.UpdateAuto = onOff;
                    Helper.SerializToFile.Serializ(settings, filename);
                }
                else
                {
                    File.Delete(filename);
                }
            }
            else
            {
                onOff = !onOff;
                Helper.SerializToFile.Serializ(new GetBeamMpServersDCBot.data.BeamMP_Config(onOff), filename);
            }
            if (onOff)
            {
                Example.BeamMp.BeamMpService.ON(int.Parse(_config["BeamMp:updateTime"]), new System.Timers.ElapsedEventHandler(UpdateMessage));
            }
            if (Helper.RunntimeTemp.UserMessage == null)
            {
                Example.BeamMp.BeamMpService.OFF(int.Parse(_config["BeamMp:updateTime"]));
                await ReplyAsync("Init Message can't be located Please let me know the message Id with the command set default status message (alias sdsm)", false);
            }
            else
            {
                await ReplyAsync((onOff ? "ON" : "OFF"), false);
            }

        }

        [Command("set_default_status_message"), Alias("sdsm")]
        [Summary("Set default status message")]
        public async Task SetDefaultUpdateMSG()
        {
            await ReplyAsync("Not implemented", false);
        }

        public async void UpdateMessage(object sender, System.Timers.ElapsedEventArgs e) 
        {

            ServerInfo serverInfo = _getBeamMpServers.GetServers().FirstOrDefault(x => x.Owner == _config["BeamMp:owner"]);
            if (serverInfo != null)
            {
                await Helper.RunntimeTemp.UserMessage.ModifyAsync(m => m.Embed = GetServerEmbed(serverInfo));
            }
        }

        private Embed GetServerEmbed(ServerInfo myserver) 
        {
            var auth = new EmbedAuthorBuilder() 
            {
                Name = myserver.Owner,
                Url = _config["BeamMp:yourweburl"],
                IconUrl = _config["BeamMp:icourl"]
            };

            var builder = new EmbedBuilder()
            {
                Color = new Color(114, 137, 218),
                Description = $"Server: ",
                Author = auth,
                Title = myserver.Sname
            };
            builder.AddField(x =>
            {
                x.Name = $"Name:";
                x.Value = $"{myserver.Sname}";
                x.IsInline = false;
            });
            builder.AddField(x =>
            {
                x.Name = $"Des:";
                x.Value = $"{myserver.Sdesc}";
                x.IsInline = false;
            });
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
                x.Value = myserver.Official ? "YES" : "NO";
                x.IsInline = false;
            });
            builder.AddField(x =>
            {
                x.Name = $"Playerslist";
                x.Value = myserver.Playerslist == ""?"Na": myserver.Playerslist;
                x.IsInline = false;
            });
            builder.AddField(x =>
            {
                x.Name = $"Ammount of Mods:";
                x.Value = $"{myserver.Modstotal}";
                x.IsInline = false;
            });
            builder.AddField(x =>
            {
                x.Name = $"Location:";
                x.Value = $"{myserver.Location}";
                x.IsInline = false;
            });
            return builder.Build();
        }
    }
}
