using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vorgari {
    public class CommandHandler {
        DiscordSocketClient _client;
        CommandService _commands;
        public async Task InstallCommandsAsync(DiscordSocketClient cliente) {
            //Referencing the client.
            _client = cliente;
            //Creating a command service to work with.
            _commands = new CommandService();
            //Obtaining the commands available.
            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),
                services: null);
            //Hooking MessageReceived event to HandleCommandAsync to work with the commands.
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage messageParam) {
            //Creating a SocketUserMessage with the message received from the chat.
            var message = messageParam as SocketUserMessage;
            //Do nothing if the message is empty.
            if (message == null) return;
            int argPos = 0;
            //Do nothing if the meesage doesn't have the command prefix or the bot is mentioned in the command or if the creator is a bot.
            if (!(message.HasStringPrefix(GlobalVariables.cmdPrefix, ref argPos) ||
            message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
            message.Author.IsBot)
                return;

            //Creating a context to work with the command.
            var context = new SocketCommandContext(_client, message);

            //Executing the command and storing the result.
            var result = await _commands.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: null);

            //If the command didn't work properly, send a message to the chat, explaining the error.
            if (!result.IsSuccess) {
                await context.Channel.SendMessageAsync("Command couldn't be processed due to an error: " + result.ErrorReason);
            }
        }


    }
}
