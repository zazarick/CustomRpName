# CustomNames

**CustomNames** � ��� Exiled-������ ��� SCP:SL, ����������� ��������� ������� ���������� ����� � �������������� ���������� (CustomInfo) � ����������� �� �� ����, � ����� ���������� ��� ��������� � ������ ������ � ����� ������� `.i` � ������� ����.

## �����������

- ��������� ����� ��� ���� ����� (D-Class, Scientist, Guard, MTF, Chaos, SCP � ��.).
- ������� ���������� (weighted) ��� � ����������� ��������� ������������ ����� ������������ ����� ���.
- ��������� ���������� (CustomInfo) ��� ������ ����, ����� � ���������� �����.
- ��������� ��������� ��� �����.
- ��������� � ������ � CustomInfo � ������ ������ (broadcast).
- ������� `.i` ��� ������ ���������� � ������� ����� � CustomInfo ������.
- ����������� ������������ ��������� ��� ������� �������� ������ ��� D-Class.
- ������ ��������� ����� `config.yml`/`config.json` (��� ������-������).
- ������������� � ���������� ������ �� ���������.

## ������� �����

1. **���������� ������ �������** � ����� `SCP Secret Laboratory/EXILED/Plugins/`.
2. **��������� ������** � ���� ������������ ������������� �������������.
3. **��������� ���� ������������** (�� ���������: `CustomNames/config.yml` ��� `CustomNames/config.json`).

## ������ ���������

```yaml
IsEnabled: true
EnableDClass: true
DClassCustomNamesEnabled: true
DClassCustomNames:
  - Name: "D-����� ������"
    Weight: 1
  - Name: "D-����� ����������"
    Weight: 2
DClassCustomInfoEnabled: true
DClassCustomInfos:
  - Info: "D-����� ��������"
    Weight: 2
  - Info: "�������� �������"
    Weight: 1
ShowInfoOnRoundStart: true
RoundMessageEnabled: true
RoundMessageFormat: "<b><color=#ffc800>���� ����: {name}\n����: {custominfo}</color></b>"
RoundMessageDuration: 5
...
```

> ��������� � ���� ������ � ��. ������ **������������** ����!

## �������������

### ��������� � ������ ������

���� `ShowInfoOnRoundStart` � `RoundMessageEnabled` ��������, ������ ����� ��� ������ �������� Broadcast � ��������� ������ � CustomInfo.

### ������� `.i`

� ������� ������� (`�` ��� `~` �� ���������) �������:

```
.i
```

����� ������ ���� ��� � CustomInfo � �������, �������� ����� `InfoCommandFormat`.

## ������������

��� ��������� �������� ��������������� � ����� `Config.cs` (��. �������� `[Description]`).

**�������� ���������:**

- `IsEnabled` � ��������/��������� ������.
- `EnableInfoCommand` � �������� ������� `.i`.
- `ShowInfoOnRoundStart` � �������� ��������� � ������ ������.
- `RoundMessageEnabled` � ������������ ��������� � ������ ������.
- `RoundMessageFormat` � ������ ��������� (�������������� ������������: `{name}`, `{custominfo}`).
- `RoundMessageDuration` � ������������ ��������� (���).

**��� ������ ����** ���� �����:
- ��������� ��������� ���/CustomInfo
- ������ ���/CustomInfo � ������ (`Weight`)
- ��������� �������� � ��� �����

**SCP:**
- ��� SCP ������������ ������� �� ������� (��������, `"173": [ ... ]`).

**Tutorial/Spectator:**
- ����� �������� ��������� ����� ��� ������������ � ���������. ���� ����� ������ � ���������� ����.

**������ ����� ��� Scientist:**

```yaml
EnableScientist: true
ScientistNames:
  - Name: "����"
    Weight: 2
  - Name: "����"
    Weight: 1
ScientistPrefixEnabled: true
ScientistPrefix: "������"
ScientistCustomInfoEnabled: true
ScientistCustomInfos:
  - Info: "������� �� SCP"
    Weight: 1
ScientistCustomNamesEnabled: true
ScientistCustomNames:
  - Name: "������ ����"
    Weight: 1
```

## ���������� �������� (Weight)

**���** � ��� ����� �����, ������������ ����������� ��������� ���� ��� ����� �����/����. ��� ������ ���, ��� ���� ����� �������� ��������������� �������.

## ����������/�����������

- ��� ���������� ����� ����� ��� ��������� ������ ����������� �����:
  - `CustomNames.cs` � �������� ������
  - `Config.cs` � ��������� �������
  - `NameEntry.cs`, `CustomInfoEntry.cs` � ��������� ��� ��� � ����

## FAQ

**�: ��� �������� ��������� ����� ��� SCP-106?**  
�: � ������ `ScpNames` ��������/�������� ����:
```yaml
ScpNames:
  "106":
    - Name: "������"
      Weight: 2
    - Name: "����������"
      Weight: 1
```

**�: ������ ��������� �� ����������?**  
�: ���������, ��� ��� ��������� `ShowInfoOnRoundStart` � `RoundMessageEnabled` ��������.

**�: ��� �������� ������ ���������?**  
�: ����������� �������� `RoundMessageFormat` � ������������ `{name}`, `{custominfo}`.

## ���������

������ ������� Zazar.  
������� � ����������� � � Issues ��� ��������.

---

**������:**  
- Exiled 9.6.1+
- SCP:SL 14.1.+
