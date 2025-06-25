# CustomNames

**CustomNames** — это Exiled-плагин для SCP:SL, позволяющий назначать игрокам уникальные имена и дополнительную информацию (CustomInfo) в зависимости от их роли, а также отображать это сообщение в начале раунда и через команду `.i` в консоли игры.

## Возможности

- Кастомные имена для всех ролей (D-Class, Scientist, Guard, MTF, Chaos, SCP и др.).
- Система взвешенных (weighted) имён — вероятность выпадения определённого имени регулируется через вес.
- Кастомная информация (CustomInfo) для каждой роли, также с поддержкой весов.
- Поддержка префиксов для ролей.
- Сообщение с именем и CustomInfo в начале раунда (broadcast).
- Команда `.i` для вывода информации о текущем имени и CustomInfo игрока.
- Возможность использовать случайные или заранее заданные номера для D-Class.
- Гибкая настройка через `config.yml`/`config.json` (или плагин-конфиг).
- Русскоязычные и английские строки по умолчанию.

## Быстрый старт

1. **Скопируйте сборку плагина** в папку `SCP Secret Laboratory/EXILED/Plugins/`.
2. **Запустите сервер** — файл конфигурации сгенерируется автоматически.
3. **Настройте файл конфигурации** (по умолчанию: `CustomNames/config.yml` или `CustomNames/config.json`).

## Пример настройки

```yaml
IsEnabled: true
EnableDClass: true
DClassCustomNamesEnabled: true
DClassCustomNames:
  - Name: "D-Класс Особый"
    Weight: 1
  - Name: "D-Класс Испытуемый"
    Weight: 2
DClassCustomInfoEnabled: true
DClassCustomInfos:
  - Info: "D-класс персонал"
    Weight: 2
  - Info: "Тестовый образец"
    Weight: 1
ShowInfoOnRoundStart: true
RoundMessageEnabled: true
RoundMessageFormat: "<b><color=#ffc800>Ваша роль: {name}\nИнфо: {custominfo}</color></b>"
RoundMessageDuration: 5
...
```

> Подробнее о всех опциях — см. секцию **Конфигурация** ниже!

## Использование

### Сообщение в начале раунда

Если `ShowInfoOnRoundStart` и `RoundMessageEnabled` включены, каждый игрок при старте получает Broadcast с кастомным именем и CustomInfo.

### Команда `.i`

В консоли клиента (`ё` или `~` по умолчанию) введите:

```
.i
```

Игрок увидит свой ник и CustomInfo в формате, заданном через `InfoCommandFormat`.

## Конфигурация

Все параметры подробно документированы в файле `Config.cs` (см. атрибуты `[Description]`).

**Основные параметры:**

- `IsEnabled` — включить/выключить плагин.
- `EnableInfoCommand` — включить команду `.i`.
- `ShowInfoOnRoundStart` — включить сообщение в начале раунда.
- `RoundMessageEnabled` — активировать сообщение в начале раунда.
- `RoundMessageFormat` — формат сообщения (поддерживаются плейсхолдеры: `{name}`, `{custominfo}`).
- `RoundMessageDuration` — длительность сообщения (сек).

**Для каждой роли** есть блоки:
- Включение кастомных имён/CustomInfo
- Списки имён/CustomInfo с весами (`Weight`)
- Включение префикса и его текст

**SCP:**
- Для SCP используется словарь по номерам (например, `"173": [ ... ]`).

**Tutorial/Spectator:**
- Можно включить кастомные имена для наблюдателей и туториала. Есть опция сброса к дефолтному нику.

**Пример блока для Scientist:**

```yaml
EnableScientist: true
ScientistNames:
  - Name: "Вася"
    Weight: 2
  - Name: "Олег"
    Weight: 1
ScientistPrefixEnabled: true
ScientistPrefix: "Ученый"
ScientistCustomInfoEnabled: true
ScientistCustomInfos:
  - Info: "Эксперт по SCP"
    Weight: 1
ScientistCustomNamesEnabled: true
ScientistCustomNames:
  - Name: "Доктор Вася"
    Weight: 1
```

## Взвешенные значения (Weight)

**Вес** — это целое число, определяющее вероятность выпадения того или иного имени/инфы. Чем больше вес, тем чаще будет выпадать соответствующий вариант.

## Расширение/модификация

- Для добавления новых ролей или изменений логики используйте файлы:
  - `CustomNames.cs` — основная логика
  - `Config.cs` — структура конфига
  - `NameEntry.cs`, `CustomInfoEntry.cs` — структуры для имён и инфы

## FAQ

**В: Как добавить кастомные имена для SCP-106?**  
О: В секции `ScpNames` добавьте/измените блок:
```yaml
ScpNames:
  "106":
    - Name: "Старик"
      Weight: 2
    - Name: "Пожиратель"
      Weight: 1
```

**В: Почему сообщение не появляется?**  
О: Проверьте, что оба параметра `ShowInfoOnRoundStart` и `RoundMessageEnabled` включены.

**В: Как изменить формат сообщения?**  
О: Используйте параметр `RoundMessageFormat` и плейсхолдеры `{name}`, `{custominfo}`.

## Поддержка

Плагин написан Zazar.  
Вопросы и предложения — в Issues или напрямую.

---

**Сборка:**  
- Exiled 9.6.1+
- SCP:SL 14.1.+
