using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace CustomNames
{
    public class Config : IConfig
    {
        [Description("Включить/Отключить плагин")]
        public bool IsEnabled { get; set; }
        [Description("Включить дебаг")]
        public bool Debug { get; set; }

        [Description("Включить команду .i в консоли ё")]
        public bool EnableInfoCommand { get; set; } = true;
        [Description("Формат ответа команды .i. {name} — имя, {custominfo} — custominfo")]
        public string InfoCommandFormat { get; set; } = "<color=yellow>Имя:</color> {name}\n<color=yellow>CustomInfo:</color> {custominfo}";

        [Description("Включить сообщение с именем и CustomInfo в начале раунда")]
        public bool ShowInfoOnRoundStart { get; set; } = false;
        [Description("Включить сообщение с именем и CustomInfo в начале раунда")]
        public bool RoundMessageEnabled { get; set; } = false;
        [Description("Формат сообщения в начале раунда. {name} — имя, {custominfo} — custominfo")]
        public string RoundMessageFormat { get; set; } = "<b><color=#ffc800>Ваша роль: {name}\nИнфо: {custominfo}</color></b>";
        [Description("Длительность Broadcast (сек)")]
        public ushort RoundMessageDuration { get; set; } = 5;

        [Description("Включить кастомные имена для D-Class?")]
        public bool EnableDClass { get; set; }
        [Description("Использовать кастомные номера для D-Class?")]
        public bool DClassUseCustomNumbers { get; set; }
        [Description("Список кастомных номеров для D-Class")]
        public List<int> DClassCustomNumbers { get; set; }
        [Description("Включить префикс для D-Class?")]
        public bool DClassPrefixEnabled { get; set; }
        [Description("Префикс для D-Class")]
        public string DClassPrefix { get; set; }
        [Description("Включить кастомное CustomInfo для D-Class?")]
        public bool DClassCustomInfoEnabled { get; set; }
        [Description("Список CustomInfo для D-Class")]
        public List<CustomInfoEntry> DClassCustomInfos { get; set; }
        [Description("Включить кастомные имена для D-Class?")]
        public bool DClassCustomNamesEnabled { get; set; }
        [Description("Список кастомных имён для D-Class")]
        public List<NameEntry> DClassCustomNames { get; set; }

        [Description("Включить кастомные имена для Scientist?")]
        public bool EnableScientist { get; set; }
        [Description("Список имён для Scientist")]
        public List<NameEntry> ScientistNames { get; set; }
        [Description("Включить префикс для Scientist?")]
        public bool ScientistPrefixEnabled { get; set; }
        [Description("Префикс для Scientist")]
        public string ScientistPrefix { get; set; }
        [Description("Включить кастомное CustomInfo для Scientist?")]
        public bool ScientistCustomInfoEnabled { get; set; }
        [Description("Список CustomInfo для Scientist")]
        public List<CustomInfoEntry> ScientistCustomInfos { get; set; }
        [Description("Включить кастомные имена для Scientist?")]
        public bool ScientistCustomNamesEnabled { get; set; }
        [Description("Список кастомных имён для Scientist")]
        public List<NameEntry> ScientistCustomNames { get; set; }

        [Description("Включить кастомные имена для Guard?")]
        public bool EnableGuard { get; set; }
        [Description("Список имён для Guard")]
        public List<NameEntry> GuardNames { get; set; }
        [Description("Включить префикс для Guard?")]
        public bool GuardPrefixEnabled { get; set; }
        [Description("Префикс для Guard")]
        public string GuardPrefix { get; set; }
        [Description("Включить кастомное CustomInfo для Guard?")]
        public bool GuardCustomInfoEnabled { get; set; }
        [Description("Список CustomInfo для Guard")]
        public List<CustomInfoEntry> GuardCustomInfos { get; set; }
        [Description("Включить кастомные имена для Guard?")]
        public bool GuardCustomNamesEnabled { get; set; }
        [Description("Список кастомных имён для Guard")]
        public List<NameEntry> GuardCustomNames { get; set; }

        [Description("Включить кастомные имена для MTF?")]
        public bool EnableMTF { get; set; }
        [Description("Список имён для MTF")]
        public List<NameEntry> MTFNames { get; set; }
        [Description("Включить префикс для MTF?")]
        public bool MTFPrefixEnabled { get; set; }
        [Description("Префикс для MTF")]
        public string MTFPrefix { get; set; }
        [Description("Включить кастомное CustomInfo для MTF?")]
        public bool MTFCustomInfoEnabled { get; set; }
        [Description("Список CustomInfo для MTF")]
        public List<CustomInfoEntry> MTFCustomInfos { get; set; }
        [Description("Включить кастомные имена для MTF?")]
        public bool MTFCustomNamesEnabled { get; set; }
        [Description("Список кастомных имён для MTF")]
        public List<NameEntry> MTFCustomNames { get; set; }

        [Description("Включить кастомные имена для Chaos?")]
        public bool EnableChaos { get; set; }
        [Description("Список имён для Chaos")]
        public List<NameEntry> ChaosNames { get; set; }
        [Description("Включить префикс для Chaos?")]
        public bool ChaosPrefixEnabled { get; set; }
        [Description("Префикс для Chaos")]
        public string ChaosPrefix { get; set; }
        [Description("Включить кастомное CustomInfo для Chaos?")]
        public bool ChaosCustomInfoEnabled { get; set; }
        [Description("Список CustomInfo для Chaos")]
        public List<CustomInfoEntry> ChaosCustomInfos { get; set; }
        [Description("Включить кастомные имена для Chaos?")]
        public bool ChaosCustomNamesEnabled { get; set; }
        [Description("Список кастомных имён для Chaos")]
        public List<NameEntry> ChaosCustomNames { get; set; }

        [Description("Включить кастомные имена для SCP?")]
        public bool EnableScp { get; set; }
        [Description("Список имён для SCP (по номерам SCP)")]
        public Dictionary<string, List<NameEntry>> ScpNames { get; set; }
        [Description("Включить префикс для SCP?")]
        public bool ScpPrefixEnabled { get; set; }
        [Description("Префикс для SCP")]
        public string ScpPrefix { get; set; }
        [Description("Включить кастомное CustomInfo для SCP?")]
        public bool ScpCustomInfoEnabled { get; set; }
        [Description("Список CustomInfo для SCP")]
        public List<CustomInfoEntry> ScpCustomInfos { get; set; }

        [Description("Включить кастомные имена для роли Tutorial")]
        public bool EnableTutorialNames { get; set; } = false;
        [Description("Сбросить ник на дефолтный при превращении в Tutorial (если кастомизация отключена)")]
        public bool TutorialResetToDefault { get; set; } = true;
        [Description("Список имён для Tutorial")]
        public List<NameEntry> TutorialNames { get; set; } = new List<NameEntry>
        {
            new NameEntry("Тестовый туториал", 1),
            new NameEntry("Новичок", 1)
        };

        [Description("Включить кастомные имена для роли Spectator")]
        public bool EnableSpectatorNames { get; set; } = false;
        [Description("Сбросить ник на дефолтный при превращении в Spectator (если кастомизация отключена)")]
        public bool SpectatorResetToDefault { get; set; } = true;
        [Description("Список имён для Spectator")]
        public List<NameEntry> SpectatorNames { get; set; } = new List<NameEntry>
        {
            new NameEntry("Наблюдатель", 1),
            new NameEntry("Призрак", 1)
        };

        public Config()
        {
            IsEnabled = true;
            Debug = false;

            EnableInfoCommand = true;
            InfoCommandFormat = "<color=yellow>Имя:</color> {name}\n<color=yellow>CustomInfo:</color> {custominfo}";

            ShowInfoOnRoundStart = false;
            RoundMessageEnabled = false;
            RoundMessageFormat = "<b><color=#ffc800>Ваша роль: {name}\nИнфо: {custominfo}</color></b>";
            RoundMessageDuration = 5;

            EnableDClass = true;
            DClassUseCustomNumbers = false;
            DClassCustomNumbers = new List<int> { 1234, 5678 };
            DClassPrefixEnabled = true;
            DClassPrefix = "D-Class";
            DClassCustomInfoEnabled = true;
            DClassCustomInfos = new List<CustomInfoEntry>
            {
                new CustomInfoEntry("Тестовый образец", 1),
                new CustomInfoEntry("D-класс персонал", 2)
            };
            DClassCustomNamesEnabled = true;
            DClassCustomNames = new List<NameEntry>
            {
                new NameEntry("D-Класс Особый", 1),
                new NameEntry("D-Класс Испытуемый", 1)
            };

            EnableScientist = true;
            ScientistNames = new List<NameEntry>
            {
                new NameEntry("Вася", 1),
                new NameEntry("Олег", 2),
                new NameEntry("Игорь", 1),
            };
            ScientistPrefixEnabled = true;
            ScientistPrefix = "Ученый";
            ScientistCustomInfoEnabled = true;
            ScientistCustomInfos = new List<CustomInfoEntry>
            {
                new CustomInfoEntry("Сотрудник научного отдела", 2),
                new CustomInfoEntry("Эксперт по SCP", 1)
            };
            ScientistCustomNamesEnabled = true;
            ScientistCustomNames = new List<NameEntry>
            {
                new NameEntry("Доктор Вася", 1),
                new NameEntry("Профессор Олег", 1)
            };

            EnableGuard = true;
            GuardNames = new List<NameEntry>
            {
                new NameEntry("Гриша", 1),
                new NameEntry("Максим", 1),
            };
            GuardPrefixEnabled = true;
            GuardPrefix = "Охранник";
            GuardCustomInfoEnabled = true;
            GuardCustomInfos = new List<CustomInfoEntry>
            {
                new CustomInfoEntry("Сотрудник охраны", 2)
            };
            GuardCustomNamesEnabled = true;
            GuardCustomNames = new List<NameEntry>
            {
                new NameEntry("Охранник Иван", 1),
                new NameEntry("Охранник Петр", 1)
            };

            EnableMTF = true;
            MTFNames = new List<NameEntry>
            {
                new NameEntry("Роман", 2),
                new NameEntry("Сергей", 1),
            };
            MTFPrefixEnabled = true;
            MTFPrefix = "МОГ";
            MTFCustomInfoEnabled = true;
            MTFCustomInfos = new List<CustomInfoEntry>
            {
                new CustomInfoEntry("МОГ подразделение", 1)
            };
            MTFCustomNamesEnabled = true;
            MTFCustomNames = new List<NameEntry>
            {
                new NameEntry("МОГ Альфа", 1),
                new NameEntry("МОГ Бета", 1)
            };

            EnableChaos = true;
            ChaosNames = new List<NameEntry>
            {
                new NameEntry("Зелёный", 1),
                new NameEntry("Красный", 1),
            };
            ChaosPrefixEnabled = true;
            ChaosPrefix = "Хаос";
            ChaosCustomInfoEnabled = true;
            ChaosCustomInfos = new List<CustomInfoEntry>
            {
                new CustomInfoEntry("Повстанец хаоса", 1)
            };
            ChaosCustomNamesEnabled = true;
            ChaosCustomNames = new List<NameEntry>
            {
                new NameEntry("Хаос Артур", 1),
                new NameEntry("Хаос Борис", 1)
            };

            EnableScp = true;
            ScpNames = new Dictionary<string, List<NameEntry>>
            {
                { "173", new List<NameEntry> { new NameEntry("Статуя", 1) } },
                { "106", new List<NameEntry> { new NameEntry("Старик", 1) } },
                { "049", new List<NameEntry> { new NameEntry("Доктор", 1) } },
                { "096", new List<NameEntry> { new NameEntry("Скромник", 1) } },
                { "939", new List<NameEntry> { new NameEntry("Собака", 1) } },
            };
            ScpPrefixEnabled = true;
            ScpPrefix = "SCP";
            ScpCustomInfoEnabled = true;
            ScpCustomInfos = new List<CustomInfoEntry>
            {
                new CustomInfoEntry("SCP-объект", 1)
            };

            EnableTutorialNames = false;
            TutorialResetToDefault = true;
            TutorialNames = new List<NameEntry>
            {
                new NameEntry("Тестовый туториал", 1),
                new NameEntry("Новичок", 1)
            };

            EnableSpectatorNames = false;
            SpectatorResetToDefault = true;
            SpectatorNames = new List<NameEntry>
            {
                new NameEntry("Наблюдатель", 1),
                new NameEntry("Призрак", 1)
            };
        }
    }
}