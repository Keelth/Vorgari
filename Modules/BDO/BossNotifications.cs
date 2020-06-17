using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vorgari.Modules.BDO {
    public class BossNotifications : IJob {

        DiscordSocketClient _client;

        public async Task SendBossNotificationAsync(string bossName) {
            DiscordWebhookClient client = new DiscordWebhookClient("https://discordapp.com/api/webhooks/720821572369252352/P4xS-Qup7uHYuaopDGs2d4VNQp7uXJUOaooKarh1i4hF3zcoD5G-CxXo5oM4uFI2lxWI");
            var utcNow = DateTimeOffset.UtcNow;
            string utcNowS = utcNow.ToString().Substring(0, utcNow.ToString().Length - 6);
            bossName = bossName.Substring(0, bossName.Length - 4);
            string bossAvatar = "";
            foreach ((string,string) avatar in GlobalVariables._bossAvatars) {
                if (avatar.Item1.CompareTo(bossName) == 0) {
                    bossAvatar = avatar.Item2;
                    break;
                }
            }
            await client.SendMessageAsync(
                text: $"{bossName} just spawned! <@&719346092537544785>",
                username: $"{bossName} - {utcNowS}",
                avatarUrl: $"{bossAvatar}"); ;
            GlobalVariables.InitBossTimers();
        }

       async Task IJob.Execute(IJobExecutionContext context) {
            await SendBossNotificationAsync(context.JobDetail.Key.Name);
        }
    }
}
