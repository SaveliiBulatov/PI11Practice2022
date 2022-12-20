using static System.Console;
using static Tools;

class RoomStory
{
    //id �������
    const int LOCATION_DOOR = 1;
    const int LOCATION_TABLE = 2;
    const int LOCATION_PICTURE = 3;
    const int LOCATION_CUPBOARD = 4;

    //��������� �������
    const int PICTURE_ON_WALL = 1;
    const int PICTURE_SAFE_LOCKED = 2;
    const int PICTURE_SAFE_UNLOCKED = 3;

    //������
    int picture_state = PICTURE_ON_WALL;
    int code = Random.Shared.Next(1000, 9999);
    bool door_locked = true;
    bool has_key = false;
    bool has_gun = false;
    bool has_bullet=false;
    Story story = null;

    public Story Create()
    {
        story = new StoryBuilder("�� �������. ���� ���-�� ������.", "���� ���������???......", LOCATION_DOOR)

           .AddLocation(LOCATION_DOOR, GetDoorDescription)
           .AddLocation(LOCATION_TABLE, "�� ������ ����� � ���������� ��������. �� ��� ����� ����������� ������.")
           .AddLocation(LOCATION_PICTURE, GetPictureDescription)
           .AddLocation(LOCATION_CUPBOARD, "����� ���� ����")

           .AddOption(LOCATION_DOOR, LOCATION_PICTURE, "������� � �������")
           .AddOption(LOCATION_DOOR, LOCATION_TABLE, "������� � �����")
           .AddOption(LOCATION_DOOR, LOCATION_CUPBOARD, "������� � �����")
           .AddOption(LOCATION_DOOR, "������� �����", DoUnlockDoor, () => door_locked)
           .AddOption(LOCATION_DOOR, "������", DoLeave, () => !door_locked)

           .AddOption(LOCATION_PICTURE, LOCATION_DOOR, "������� � �����")
           .AddOption(LOCATION_PICTURE, LOCATION_TABLE, "������� � �������")
           .AddOption(LOCATION_PICTURE, LOCATION_CUPBOARD, "������� � �����")
           .AddOption(LOCATION_PICTURE, "��� � ����� ������� ����� �������", DoRepairPicture, () => picture_state == PICTURE_ON_WALL)
           .AddOption(LOCATION_PICTURE, "������ ���", DoEnterCode, () => picture_state == PICTURE_SAFE_LOCKED)
           .AddOption(LOCATION_PICTURE, "����� ����", DoGetKey, () => picture_state == PICTURE_SAFE_UNLOCKED && !has_key)

           .AddOption(LOCATION_TABLE, LOCATION_DOOR, "������� � �����")
           .AddOption(LOCATION_TABLE, LOCATION_PICTURE, "������� � �������")
           .AddOption(LOCATION_TABLE, LOCATION_CUPBOARD, "������� � �����")
           .AddOption(LOCATION_TABLE, "��������� ������", DoReadNewspaper)
           .AddOption(LOCATION_TABLE, "��������� ��� ����", DoTakeGun)

           .AddOption(LOCATION_CUPBOARD, LOCATION_DOOR, "������� � �����")
           .AddOption(LOCATION_CUPBOARD, LOCATION_PICTURE, "������� � �������")
           .AddOption(LOCATION_CUPBOARD, LOCATION_TABLE, "������� � �����")
           .AddOption(LOCATION_CUPBOARD, "��������� � ����", DoTakeBullet)
           

           .Build();

        return story;
    }

    string GetDoorDescription()
    {
        string desc = "����� ���� �������� ����� � ����� ";
        if (door_locked)
            desc += "\n��� ������� ����� ����";
        return desc;
    }

    string GetPictureDescription()
    {
        string desc = "�� ����� ����� ������� ������.";
        if (picture_state == PICTURE_SAFE_LOCKED)
            desc = "��� ������ �������� ������� � �� �� ����� - ���������� ���� � ������� ������.";
        if (picture_state == PICTURE_SAFE_UNLOCKED)
        {
            desc = "��� ������ �������� ������� � �� �� ����� - �������� ����.";
            if (!has_key)
                desc += "\n� ������� ����� ���-�� �������...";
            else
                desc += "\n���� ��������� ����.";
        }
        return desc;
    }

    void DoUnlockDoor()
    {
        if (has_key)
        {
            door_locked = false;
            Alert("�� ��������� ����� ������!");
        }
        else
        {
            Alert("��� ����� ����� ����...");
        }
    }

    void DoLeave()
    {
        story.End = true;
        if (has_bullet && has_gun)
        {
            
            Alert("�� ������� ������� ���� ���������!!!");
        }
        else
        {
            Alert("�� ������� ����� �� �������� ���� ���. ��� �����!!!");
        }
        
    }

    void DoReadNewspaper()
    {
        Alert("�� ������ � ���� ������, �� ������ ��������� ������:");
        Alert($"��� ������� {code} ");
    }

    void DoRepairPicture()
    {
        Alert("�� �������� �������, � �� ��� �������������...");
        Alert(" ������� ����!");
        picture_state = PICTURE_SAFE_LOCKED;
    }
    
    void DoEnterCode()
    {
        var c = GetInt("������� ��� (4 �����): ", 1000, 9999);
        if (c != code)
            Alert("������...������ ��� �������");
        else
        {
            Alert("���!!! ������ ��� �������. ������ ����� ������...");
            picture_state = PICTURE_SAFE_UNLOCKED;
        }
    }

    void DoGetKey()
    {
        Alert("� ��� �  ����!....�� ��� ��?");
        has_key = true;
    }
       void DoTakeGun()
    {
        Alert("�������� ��� ����");
        has_gun = true;
    }
         void DoTakeBullet()
    {
        Alert("���� ��������� ��� ����");
        has_bullet = true;
    }

}