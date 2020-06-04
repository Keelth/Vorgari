﻿using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Drawing;
using Discord;
using System.Text.RegularExpressions;

namespace Vorgari.Modules.LeagueOfLegends {
    public class Op: ModuleBase<SocketCommandContext> {

        [Command("lol.stats")]
        public async Task LoLStatsAsync(string server, [Remainder] string user) {
            string level, ladder, ranked, rank, lp, win, lose, wl, wRatio, league, thumbnail, url;
            HtmlWeb webP = new HtmlWeb();
            HtmlDocument doc = webP.Load("https://" + server + ".op.gg/summoner/userName=" + user);
            var htmlNode = doc.DocumentNode.SelectSingleNode("/html");
            Regex regex = new Regex("<span class=\"Level tip\" title=\"Level\">(.*?)</span>");
            var v = regex.Match(htmlNode.OuterHtml);
            level = v.Groups[1].ToString();
            regex = new Regex("<span class=\"ranking\">(.*?)</span>");
            v = regex.Match(htmlNode.OuterHtml);
            ladder = "Ladder Rank " + v.Groups[1].ToString();
            ranked = "Ranked Solo/Duo";
            regex = new Regex("<div class=\"TierRank\">(.*?)</div>");
            v = regex.Match(htmlNode.OuterHtml);
            rank = v.Groups[1].ToString();
            htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div/div[5]/div[2]/div/div/div/div[2]/div/span");
            lp = htmlNode.InnerText.Trim();
            htmlNode = doc.DocumentNode.SelectSingleNode("/html");
            regex = new Regex("<span class=\"wins\">(.*?)</span>");
            v = regex.Match(htmlNode.OuterHtml);
            win = v.Groups[1].ToString();
            regex = new Regex("<span class=\"losses\">(.*?)</span>");
            v = regex.Match(htmlNode.OuterHtml);
            lose = v.Groups[1].ToString();
            wl = win + "/" + lose;
            regex = new Regex("<span class=\"winratio\">(.*?)</span>");
            v = regex.Match(htmlNode.OuterHtml);
            wRatio = v.Groups[1].ToString();
            htmlNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div/div[5]/div[2]/div/div/div/div[2]/div[4]");
            league = htmlNode.InnerText.Trim();
            league = league.Replace("&#039;", "'");
            htmlNode = doc.DocumentNode.SelectSingleNode("/html");
            regex = new Regex("<img src=\"//(.*?)\" class=\"ProfileImage\">");
            v = regex.Match(htmlNode.OuterHtml);
            thumbnail = v.Groups[1].ToString();
            if(user.Split(' ').Length > 1) {
                string newUser = "";
                for (int i = 0; i < user.Split(' ').Length; i++) {
                    newUser += user.Split(' ')[i] + "+";
                }
                newUser = newUser.Remove(newUser.Length-1);
                url = "https://" + server + ".op.gg/summoner/userName=" + newUser;

            } else {
                url = "https://" + server + ".op.gg/summoner/userName=" + user;
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
                    .WithThumbnailUrl($"https://{thumbnail}")
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
