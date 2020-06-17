using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Vorgari.Modules.BDO;
using Vorgari.Modules.Core;

namespace Vorgari {
    public partial class Form1: Form {

        private DiscordSocketClient _client;
        private CommandHandler _handler;
        private static readonly Form1 instance = new Form1();
        public List<long> messagesID { get; set; } = new List<long>();

        public static Form1 Instance {
            get {
                return instance;
            }
        }

        public Form1() {
            InitializeComponent();
        }

        private async void connect_btn_Click(object sender, EventArgs e) {
            GlobalVariables.Init();
            _client = new DiscordSocketClient(new DiscordSocketConfig() {
                LogLevel = LogSeverity.Verbose,
                MessageCacheSize = 100
            });

            _client.Log += Client_Log;
            await _client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("VORGARI_BOT"));
            await _client.StartAsync();
            _handler = new CommandHandler();
            await _handler.InstallCommandsAsync(_client);
            _client.MessageUpdated += MessageUpdated;
            _client.ReactionAdded += HandleReactionAddedAsync;
            new BossTimer(_client);
            await Task.Delay(-1);
        }

        public async Task HandleReactionAddedAsync(Cacheable<IUserMessage, ulong> cachedMessage,
            ISocketMessageChannel originChannel,
            SocketReaction reaction) {
            var message = await cachedMessage.GetOrDownloadAsync();
            ReactionToRole RTR = new ReactionToRole(reaction, message, originChannel);
            await RTR.addRoleAsync();
            /*if (message != null && reaction.User.IsSpecified && message.Id == 717189399124770826) {
                Invoke((Action)delegate {
                    console_output_rt.AppendText($"{DateTime.Now.TimeOfDay.ToString().Split('.')[0]} {reaction.User.Value} just added a reaction '{reaction.Emote}' " +
                      $"to {message.Author}'s message ({message.Id}). \n");
                    ((SocketGuildUser)reaction.User).AddRoleAsync(((SocketGuildChannel)originChannel).Guild.GetRole(717536020446314507));
                });
            }*/
        }

        private async Task MessageUpdated(Cacheable<IMessage, ulong> before,
            SocketMessage after, ISocketMessageChannel channel) {
            var message = await before.GetOrDownloadAsync();
            Invoke((Action)delegate {
                console_output_rt.AppendText($"{message} -> {after} \n");
            });
        }

        private Task Client_Log(LogMessage msg) {
            Invoke((Action)delegate {
                console_output_rt.AppendText(msg + "\n");
            });
            return null;
        }
    }
}
