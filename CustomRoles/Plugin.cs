using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using System;
using System.Collections.Generic;

namespace CustomNames
{
    public class CustomNames : Plugin<Config>
    {
        public override string Name => "CustomNames";
        public override string Author => "Zazar";
        public override string Prefix => "customnames";
        public override Version Version => new Version(1, 5, 0);

        public static CustomNames Instance;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Instance = this;
            Exiled.Events.Handlers.Player.Spawned += OnSpawned;
            if (Config.ShowInfoOnRoundStart && Config.RoundMessageEnabled)
                Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Spawned -= OnSpawned;
            if (Config.ShowInfoOnRoundStart && Config.RoundMessageEnabled)
                Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Instance = null;
            base.OnDisabled();
        }

        private void OnSpawned(SpawnedEventArgs ev)
        {
            var cfg = Config;
            Player player = ev.Player;

            switch (player.Role.Type)
            {
                case RoleTypeId.ClassD:
                    if (cfg.EnableDClass)
                    {
                        player.DisplayNickname =
                            cfg.DClassCustomNamesEnabled && cfg.DClassCustomNames != null && cfg.DClassCustomNames.Count > 0
                                ? GetWeightedName(cfg.DClassCustomNames)
                                : GetDisplayName(cfg.DClassPrefixEnabled, cfg.DClassPrefix, GetDClassName(cfg));
                        if (cfg.DClassCustomInfoEnabled && cfg.DClassCustomInfos != null)
                            player.CustomInfo = GetWeightedCustomInfo(cfg.DClassCustomInfos);
                    }
                    break;
                case RoleTypeId.Scientist:
                    if (cfg.EnableScientist)
                    {
                        player.DisplayNickname =
                            cfg.ScientistCustomNamesEnabled && cfg.ScientistCustomNames != null && cfg.ScientistCustomNames.Count > 0
                                ? GetWeightedName(cfg.ScientistCustomNames)
                                : GetDisplayName(cfg.ScientistPrefixEnabled, cfg.ScientistPrefix, GetScientistName(cfg));
                        if (cfg.ScientistCustomInfoEnabled && cfg.ScientistCustomInfos != null)
                            player.CustomInfo = GetWeightedCustomInfo(cfg.ScientistCustomInfos);
                    }
                    break;
                case RoleTypeId.FacilityGuard:
                    if (cfg.EnableGuard)
                    {
                        player.DisplayNickname =
                            cfg.GuardCustomNamesEnabled && cfg.GuardCustomNames != null && cfg.GuardCustomNames.Count > 0
                                ? GetWeightedName(cfg.GuardCustomNames)
                                : GetDisplayName(cfg.GuardPrefixEnabled, cfg.GuardPrefix, GetGuardName(cfg));
                        if (cfg.GuardCustomInfoEnabled && cfg.GuardCustomInfos != null)
                            player.CustomInfo = GetWeightedCustomInfo(cfg.GuardCustomInfos);
                    }
                    break;
                case RoleTypeId.NtfPrivate:
                case RoleTypeId.NtfSergeant:
                case RoleTypeId.NtfCaptain:
                case RoleTypeId.NtfSpecialist:
                    if (cfg.EnableMTF)
                    {
                        player.DisplayNickname =
                            cfg.MTFCustomNamesEnabled && cfg.MTFCustomNames != null && cfg.MTFCustomNames.Count > 0
                                ? GetWeightedName(cfg.MTFCustomNames)
                                : GetDisplayName(cfg.MTFPrefixEnabled, cfg.MTFPrefix, GetMTFName(cfg));
                        if (cfg.MTFCustomInfoEnabled && cfg.MTFCustomInfos != null)
                            player.CustomInfo = GetWeightedCustomInfo(cfg.MTFCustomInfos);
                    }
                    break;
                case RoleTypeId.ChaosConscript:
                case RoleTypeId.ChaosRifleman:
                case RoleTypeId.ChaosMarauder:
                case RoleTypeId.ChaosRepressor:
                    if (cfg.EnableChaos)
                    {
                        player.DisplayNickname =
                            cfg.ChaosCustomNamesEnabled && cfg.ChaosCustomNames != null && cfg.ChaosCustomNames.Count > 0
                                ? GetWeightedName(cfg.ChaosCustomNames)
                                : GetDisplayName(cfg.ChaosPrefixEnabled, cfg.ChaosPrefix, GetChaosName(cfg));
                        if (cfg.ChaosCustomInfoEnabled && cfg.ChaosCustomInfos != null)
                            player.CustomInfo = GetWeightedCustomInfo(cfg.ChaosCustomInfos);
                    }
                    break;
                case RoleTypeId.Tutorial:
                    if (cfg.EnableTutorialNames)
                    {
                        if (cfg.TutorialNames != null && cfg.TutorialNames.Count > 0)
                            player.DisplayNickname = GetWeightedName(cfg.TutorialNames);
                    }
                    else if (cfg.TutorialResetToDefault)
                    {
                        player.DisplayNickname = player.Nickname ?? player.RawUserId;
                    }
                    break;
                case RoleTypeId.Spectator:
                    if (cfg.EnableSpectatorNames)
                    {
                        if (cfg.SpectatorNames != null && cfg.SpectatorNames.Count > 0)
                            player.DisplayNickname = GetWeightedName(cfg.SpectatorNames);
                    }
                    else if (cfg.SpectatorResetToDefault)
                    {
                        player.DisplayNickname = player.Nickname ?? player.RawUserId;
                    }
                    break;
                default:
                    if (player.Role.Type.ToString().StartsWith("Scp") && cfg.EnableScp)
                    {
                        player.DisplayNickname = GetDisplayName(cfg.ScpPrefixEnabled, cfg.ScpPrefix, GetScpName(cfg, player.Role.Type));
                        if (cfg.ScpCustomInfoEnabled && cfg.ScpCustomInfos != null)
                            player.CustomInfo = GetWeightedCustomInfo(cfg.ScpCustomInfos);
                    }
                    break;
            }

            if (Config.ShowInfoOnRoundStart && Config.RoundMessageEnabled && player.Role.Type != RoleTypeId.Tutorial)
            {
                string msg = Config.RoundMessageFormat
                    .Replace("{name}", player.DisplayNickname)
                    .Replace("{custominfo}", player.CustomInfo ?? "");
                player.Broadcast(Config.RoundMessageDuration, msg, Broadcast.BroadcastFlags.Normal, true);
            }
        }

        private void OnRoundStarted()
        {
            if (!Config.RoundMessageEnabled)
                return;

            foreach (var player in Player.List)
            {
                if (player.Role.Type == RoleTypeId.Tutorial) continue;
                string msg = Config.RoundMessageFormat
                    .Replace("{name}", player.DisplayNickname)
                    .Replace("{custominfo}", player.CustomInfo ?? "");
                player.Broadcast(Config.RoundMessageDuration, msg, Broadcast.BroadcastFlags.Normal, true);
            }
        }

        private string GetDisplayName(bool prefixEnabled, string prefix, string name)
        {
            if (prefixEnabled && !string.IsNullOrEmpty(prefix))
                return prefix + " " + name;
            else
                return name;
        }

        private string GetDClassName(Config cfg)
        {
            if (cfg.DClassUseCustomNumbers && cfg.DClassCustomNumbers != null && cfg.DClassCustomNumbers.Count > 0)
            {
                int idx = UnityEngine.Random.Range(0, cfg.DClassCustomNumbers.Count);
                int num = cfg.DClassCustomNumbers[idx];
                return "D-" + num.ToString("D4");
            }
            else
            {
                return "D-" + UnityEngine.Random.Range(1000, 10000).ToString();
            }
        }

        private string GetScientistName(Config cfg)
        {
            if (cfg.ScientistNames == null || cfg.ScientistNames.Count == 0)
                return "Ученый";
            return GetWeightedName(cfg.ScientistNames);
        }

        private string GetGuardName(Config cfg)
        {
            if (cfg.GuardNames == null || cfg.GuardNames.Count == 0)
                return "Охранник";
            return GetWeightedName(cfg.GuardNames);
        }

        private string GetMTFName(Config cfg)
        {
            if (cfg.MTFNames == null || cfg.MTFNames.Count == 0)
                return "МОГ";
            return GetWeightedName(cfg.MTFNames);
        }

        private string GetChaosName(Config cfg)
        {
            if (cfg.ChaosNames == null || cfg.ChaosNames.Count == 0)
                return "Хаос";
            return GetWeightedName(cfg.ChaosNames);
        }

        private string GetScpName(Config cfg, RoleTypeId role)
        {
            string scpNum = "???";
            if (role == RoleTypeId.Scp173) scpNum = "173";
            else if (role == RoleTypeId.Scp106) scpNum = "106";
            else if (role == RoleTypeId.Scp049) scpNum = "049";
            else if (role == RoleTypeId.Scp096) scpNum = "096";
            else if (role == RoleTypeId.Scp939) scpNum = "939";
            else if (role == RoleTypeId.Scp3114) scpNum = "3114";
            else if (role == RoleTypeId.Scp0492) scpNum = "049-2";

            List<NameEntry> names;
            if (cfg.ScpNames != null && cfg.ScpNames.TryGetValue(scpNum, out names) && names.Count > 0)
            {
                string name = GetWeightedName(names);
                return "SCP-" + scpNum + " " + name;
            }
            else
            {
                return "SCP-" + scpNum;
            }
        }

        private string GetWeightedName(List<NameEntry> names)
        {
            if (names == null || names.Count == 0)
                return "";
            int totalWeight = 0;
            foreach (var x in names)
                totalWeight += x.Weight;
            int val = UnityEngine.Random.Range(1, totalWeight + 1);
            int sum = 0;
            foreach (var entry in names)
            {
                sum += entry.Weight;
                if (val <= sum)
                    return entry.Name;
            }
            return names[0].Name;
        }

        private string GetWeightedCustomInfo(List<CustomInfoEntry> infos)
        {
            if (infos == null || infos.Count == 0)
                return "";
            int totalWeight = 0;
            foreach (var x in infos)
                totalWeight += x.Weight;
            int val = UnityEngine.Random.Range(1, totalWeight + 1);
            int sum = 0;
            foreach (var entry in infos)
            {
                sum += entry.Weight;
                if (val <= sum)
                    return entry.Info;
            }
            return infos[0].Info;
        }
    }
}