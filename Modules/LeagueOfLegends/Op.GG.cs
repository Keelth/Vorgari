using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Drawing;
using Discord;

namespace Vorgari.Modules.LeagueOfLegends {
    public class Op: ModuleBase<SocketCommandContext> {

        [Command("lol.stats")]
        public async Task LoLStatsAsync([Remainder] string user) {
            string userName, level, ladder, ranked, rank, lp, win, lose, wl, wRatio, league, thumbnail, url;
            HtmlWeb webP = new HtmlWeb();
            HtmlDocument doc = webP.Load("https://las.op.gg/summoner/userName=" + user);
            /*var htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div/div/div/div[3]/div/span");
            userName = htmlNode.InnerText.Trim();*/
            var htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div/div/div[2]");
            level = htmlNode.InnerText.Trim();
            htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div/div/div/div[3]/div/div");
            ladder = htmlNode.InnerText.Trim();
            ranked = "Ranked Solo/Duo";
            htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div/div[5]/div[2]/div/div/div/div[2]/div[2]");
            rank = htmlNode.InnerText.Trim();
            htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div/div[5]/div[2]/div/div/div/div[2]/div/span");
            lp = htmlNode.InnerText.Trim();
            htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div/div[5]/div[2]/div/div/div/div[2]/div/span[2]/span");
            win = htmlNode.InnerText.Trim();
            htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div/div[5]/div[2]/div/div/div/div[2]/div/span[2]/span[2]");
            lose = htmlNode.InnerText.Trim();
            wl = win + "/" + lose;
            htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div/div[5]/div[2]/div/div/div/div[2]/div[3]/span[2]/span[3]");
            wRatio = htmlNode.InnerText.Trim();
            htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div/div[5]/div[2]/div/div/div/div[2]/div[4]");
            league = htmlNode.InnerText.Trim();
            league = league.Replace("&#039;","'");
            var htmlNodes = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div/div/div[2]/div/img");
            thumbnail = htmlNodes.OuterHtml.Substring(12);
            thumbnail = thumbnail.Remove(thumbnail.Length - 23);
            if(user.Split(' ').Length > 1) {
                string newUser = "";
                for (int i = 0; i < user.Split(' ').Length; i++) {
                    newUser += user.Split(' ')[i] + "+";
                }
                newUser = newUser.Remove(newUser.Length-1);
                url = "https://las.op.gg/summoner/userName=" + newUser;

            } else {
                url = "https://las.op.gg/summoner/userName=" + user;
            }
            var builder = new EmbedBuilder()
                    .WithTitle($"{user}")
                    .WithUrl(url)
                    .WithColor(new Discord.Color(0x890D42))
                    .WithTimestamp(DateTimeOffset.Now)
                    .WithFooter(footer => {
                        footer
                            .WithText("Vorgari");
                    })
                    .WithThumbnailUrl($"http://{thumbnail}")
                    .AddField($"Level {level}", $"{ladder}")
                    .AddField($"{ranked}", $"{rank}")
                    .AddField($"{lp}", $"{wl}")
                    .AddField($"{wRatio}", $"{league}");
            var embed = builder.Build();
            await ReplyAsync("", false, embed);
        }

        [Command("echo")]
        public async Task Echo([Remainder] string msg) {
            //Embed
            Form1.Instance.console_output_rt.AppendText("Entre");
            var embed = new EmbedBuilder();
            embed.WithTitle("Echoed message");
            embed.WithDescription(msg);
            embed.WithColor(new Discord.Color(0, 255, 0));
            await Context.Channel.SendMessageAsync("", false, embed.Build());

            //Normal
            //await Context.Channel.SendMessageAsync(msg);
        }


    }
}
