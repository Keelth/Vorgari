using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace Vorgari.Modules.LeagueOfLegends {
    public class Op: ModuleBase<SocketCommandContext> {
        
        [Command("lol.stats")]
        public Task LoLStatsAsync(string user) {
            HtmlWeb webP = new HtmlWeb();
            HtmlDocument doc = webP.Load("las.op.gg/userName=" + user);
            //Username
            var htmlNodes = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[2]/div/div/div/div[3]/div/span");

        }
        

    }
}
