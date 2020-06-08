using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.WebSocket;

namespace Vorgari.Modules.Core {
    public class ReactionToRole {
        private ulong _msgId = 719349729338720266;
        private SocketReaction _reaction;
        private IUserMessage _message;
        private ISocketMessageChannel _channel;

        public ReactionToRole(SocketReaction reaction, IUserMessage message, ISocketMessageChannel channel) {
            this._reaction = reaction;
            this._message = message;
            this._channel = channel;
        }

        public async Task addRoleAsync() {
            if (_message != null && _reaction.User.IsSpecified && _message.Id == _msgId) {
                //League of Legends.
                if (_reaction.Emote.Name.CompareTo("LeagueOfLegendsLogo") == 0) {
                    await ((SocketGuildUser)_reaction.User).AddRoleAsync(((SocketGuildChannel)_channel).Guild.GetRole(635256283003617280));
                }
                //Black Desert Online
                if (_reaction.Emote.Name.CompareTo("BlackDesertOnlineLogo") == 0) {
                    await ((SocketGuildUser)_reaction.User).AddRoleAsync(((SocketGuildChannel)_channel).Guild.GetRole(719346092537544785));
                }
            }
        }
    }
}

