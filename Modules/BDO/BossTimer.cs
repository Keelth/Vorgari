using Discord;
using Discord.Commands;
using Discord.Webhook;
using Discord.WebSocket;
using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vorgari.Modules.BDO {
    public class BossTimer {

        DiscordSocketClient _client;
        System.Timers.Timer t;

        public BossTimer(DiscordSocketClient client) {
            _client = client;
            t = new System.Timers.Timer();
            t.Interval = 1000 * 60;
            t.Elapsed += new System.Timers.ElapsedEventHandler(RefreshTimerAsync);
            t.AutoReset = false;
            t.Start();
        }
        public async void RefreshTimerAsync(object sender, System.Timers.ElapsedEventArgs e) {
            DiscordWebhookClient client = new DiscordWebhookClient("https://discordapp.com/api/webhooks/720783757497335839/78WsX54MPCYm3dBaRPl5_5miS_HPuG-OdKxuD4wIn6uv0qwPiSKGccN827zNSpSYP4oK");
            var channel = _client.GetChannel(720402142925553734) as IMessageChannel;
            var message = await channel.GetMessagesAsync(1).FlattenAsync();
            if (!(message.ToList().Count() == 0)) await message.ToList().First().DeleteAsync();

            #region Timer Creation
            (TimeSpan?, string, string) _karandaTimer = TimeLeft("Karanda");
            (TimeSpan?, string, string) _kzarkaTimer = TimeLeft("Kzarka");
            (TimeSpan?, string, string) _nouverTimer = TimeLeft("Nouver");
            (TimeSpan?, string, string) _kutumTimer = TimeLeft("Kutum");
            (TimeSpan?, string, string) _offinTimer = TimeLeft("OffinTett");
            (TimeSpan?, string, string) _murakaTimer = TimeLeft("Muraka");
            (TimeSpan?, string, string) _quintTimer = TimeLeft("Quint");
            (TimeSpan?, string, string) _vellTimer = TimeLeft("Vell");
            (TimeSpan?, string, string) _garmothTimer = TimeLeft("Garmoth");
            List<(TimeSpan?, string, string)> timers = new List<(TimeSpan?, string, string)>();
            string[,] timersFinal = new string[9, 2];
            timers.Add(_karandaTimer);
            timers.Add(_kzarkaTimer);
            timers.Add(_nouverTimer);
            timers.Add(_kutumTimer);
            timers.Add(_offinTimer);
            timers.Add(_murakaTimer);
            timers.Add(_quintTimer);
            timers.Add(_vellTimer);
            timers.Add(_garmothTimer);
            timersFinal = timesInOrder(timers);
            #endregion

            #region String creation
            string final = "";
            for (int i = 0; i < 9; i++) {
                if (timersFinal[i, 1].CompareTo("Vell") == 0) {
                    final += $"\n{timersFinal[i, 1]}".PadRight(15) + $"{timersFinal[i, 0]}".PadLeft(10) + " until 30m warning.";
                } else {
                    final += $"\n{timersFinal[i, 1]}".PadRight(15) + $"{timersFinal[i, 0]}".PadLeft(10) + " until spawn.";
                }
            }
            #endregion

            var builder = new EmbedBuilder()
                .WithTitle(":calendar_spiral: World Boss Schedule")
                .WithDescription("```" + final + "```");
            var _embed = builder.Build();
            Embed[] _eb = { _embed };

            await client.SendMessageAsync(
                embeds: _eb,
                username: "Timers",
                avatarUrl: "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fb/Icon_Clock.svg/55px-Icon_Clock.svg.png");
            t.Start();
        }

        private (TimeSpan?, string, string) TimeLeft(string bossName) {
            if (bossName.CompareTo("Vell") == 0) {
                return (Times(GlobalVariables._VellTimes.Values).Min(),
                    FormatTimeLeft(Times(GlobalVariables._VellTimes.Values).Min().Value.ToString(@"dd\.hh\:mm\:ss")),
                    bossName);
            } else if (bossName.CompareTo("Kzarka") == 0) {
                return (Times(GlobalVariables._KzarkaTimes.Values).Min(),
                    FormatTimeLeft(Times(GlobalVariables._KzarkaTimes.Values).Min().Value.ToString(@"dd\.hh\:mm\:ss")),
                    bossName);
            } else if (bossName.CompareTo("Kutum") == 0) {
                return (Times(GlobalVariables._KutumTimes.Values).Min(),
                    FormatTimeLeft(Times(GlobalVariables._KutumTimes.Values).Min().Value.ToString(@"dd\.hh\:mm\:ss")),
                    bossName); ;
            } else if (bossName.CompareTo("Nouver") == 0) {
                return (Times(GlobalVariables._NouverTimes.Values).Min(),
                    FormatTimeLeft(Times(GlobalVariables._NouverTimes.Values).Min().Value.ToString(@"dd\.hh\:mm\:ss")),
                    bossName); ;
            } else if (bossName.CompareTo("OffinTett") == 0) {
                return (Times(GlobalVariables._OffinTimes.Values).Min(),
                    FormatTimeLeft(Times(GlobalVariables._OffinTimes.Values).Min().Value.ToString(@"dd\.hh\:mm\:ss")),
                    bossName); ;
            } else if (bossName.CompareTo("Karanda") == 0) {
                return (Times(GlobalVariables._KarandaTimes.Values).Min(),
                    FormatTimeLeft(Times(GlobalVariables._KarandaTimes.Values).Min().Value.ToString(@"dd\.hh\:mm\:ss")),
                    bossName); ;
            } else if (bossName.CompareTo("Quint") == 0) {
                return (Times(GlobalVariables._QuintTimes.Values).Min(),
                    FormatTimeLeft(Times(GlobalVariables._QuintTimes.Values).Min().Value.ToString(@"dd\.hh\:mm\:ss")),
                    bossName); ;
            } else if (bossName.CompareTo("Muraka") == 0) {
                return (Times(GlobalVariables._MurakaTimes.Values).Min(),
                FormatTimeLeft(Times(GlobalVariables._MurakaTimes.Values).Min().Value.ToString(@"dd\.hh\:mm\:ss")),
                    bossName); ;
            } else if (bossName.CompareTo("Garmoth") == 0) {
                return (Times(GlobalVariables._GarmothTimes.Values).Min(),
                    FormatTimeLeft(Times(GlobalVariables._GarmothTimes.Values).Min().Value.ToString(@"dd\.hh\:mm\:ss")),
                    bossName); ;
            } else {
                return (null, "Not a valid boss name.", "Invalid");

            }
        }

        private List<TimeSpan?> Times(Dictionary<string, ITrigger>.ValueCollection values) {
            List<TimeSpan?> times = new List<TimeSpan?>();
            foreach (ITrigger tri in values) {
                var bossTime = tri.GetNextFireTimeUtc();
                var timeNow = DateTimeOffset.UtcNow;
                TimeSpan? timer = bossTime - timeNow;
                times.Add(timer);
            }
            return times;
        }

        private string[,] timesInOrder(List<(TimeSpan?, string, string)> values) {
            string[,] bossTimes = new string[9, 2];
            int idx;
            int aux;
            int j = 0;
            int k = 0;
            (TimeSpan?, string, string) min;
            int finish = values.Count;
            for (int i = 0; i < finish; i++) {
                min = values.First();
                idx = 0;
                aux = 0;
                foreach ((TimeSpan?, string, string) bossTime in values) {
                    if (bossTime.Item1 < min.Item1) {
                        min = bossTime;
                        aux = idx;
                        idx++;
                    } else {
                        idx++;
                    }
                }
                bossTimes[j, k] = min.Item2;
                k++;
                bossTimes[j, k] = min.Item3;
                j++;
                k--;
                values.RemoveAt(aux);
            }
            return bossTimes;
        }

        private string FormatTimeLeft(string timeLeft) {
            string[] days = timeLeft.Split('.');
            string[] hms = days[1].Split(':');
            if (days[0].CompareTo("00") == 0) {
                if (hms[0].CompareTo("00") == 0) {
                    return $"{hms[1]}m";
                } else {
                    return $"{hms[0]}h{hms[1]}m";
                }
            } else {
                return $"{days[0]}d{hms[0]}h{hms[1]}m";
            }
        }
    }
}
