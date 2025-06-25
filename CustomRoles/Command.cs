using Exiled.API.Features;
using CommandSystem;
using System;

namespace CustomNames
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class InfoCommand : ICommand
    {
        public string Command => "i";
        public string[] Aliases => new string[0];
        public string Description => "Показывает ник и CustomInfo игрока";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = "Ты не игрок!";
                return false;
            }

            response = CustomNames.Instance.Config.InfoCommandFormat
                .Replace("{name}", player.DisplayNickname)
                .Replace("{custominfo}", player.CustomInfo ?? "");

            return true;
        }
    }
}