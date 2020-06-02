using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.WebSocket;

namespace Vorgari {
    public partial class Form1: Form {

        private DiscordSocketClient _client;
        public Form1() {
            InitializeComponent();
        }

        private async void connect_btn_Click(object sender, EventArgs e) {
            _client = new DiscordSocketClient(new DiscordSocketConfig() {
                LogLevel = LogSeverity.Verbose
            });

            _client.Log += Client_Log;

            await _client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("VORGARI_BOT"));
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private Task Client_Log(LogMessage msg) {
            Invoke((Action)delegate {
                console_output_rt.AppendText(msg + "\n");
            });
            return null;
        }
    }
}
