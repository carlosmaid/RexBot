﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord1Test;

namespace RexBot.Commands
{
    class CommandRemoveCommand : IChatCommand
    {
        public bool IsPublic => false;
        public string Command => "!removecommand";
        public string HelpText => "Removes info command";
        public async Task<string> Handle(SocketMessage message)
        {
            string target = message.Content.Substring(Command.Length + 1);
            foreach (var info in RexBotCore.Instance.InfoCommands)
            {
                if (info.Command.Equals(target, StringComparison.CurrentCultureIgnoreCase))
                {
                    RexBotCore.Instance.InfoCommands.Remove(info);
                    RexBotCore.Instance.SaveCommands();
                    return ($"Removing command {info.Command}");
                }
            }

            return $"Couldn't find {target}";
        }
    }
}
