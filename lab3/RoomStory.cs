using static System.Console;
using static Tools;

class RoomStory
{
    //id локаций
    const int LOCATION_DOOR = 1;
    const int LOCATION_TABLE = 2;
    const int LOCATION_PICTURE = 3;
    const int LOCATION_CUPBOARD = 4;

    //состояние картины
    const int PICTURE_ON_WALL = 1;
    const int PICTURE_SAFE_LOCKED = 2;
    const int PICTURE_SAFE_UNLOCKED = 3;

    //данные
    int picture_state = PICTURE_ON_WALL;
    int code = Random.Shared.Next(1000, 9999);
    bool door_locked = true;
    bool has_key = false;
    bool has_gun = false;
    bool has_bullet=false;
    Story story = null;

    public Story Create()
    {
        story = new StoryBuilder("Вы заперты. Надо что-то делать.", "Игра закончена???......", LOCATION_DOOR)

           .AddLocation(LOCATION_DOOR, GetDoorDescription)
           .AddLocation(LOCATION_TABLE, "Вы стоите рядом с журнальным столиком. На нем лежит потрепанная газета.")
           .AddLocation(LOCATION_PICTURE, GetPictureDescription)
           .AddLocation(LOCATION_CUPBOARD, "Перед вами шкаф")

           .AddOption(LOCATION_DOOR, LOCATION_PICTURE, "подойти к картине")
           .AddOption(LOCATION_DOOR, LOCATION_TABLE, "подойти к столу")
           .AddOption(LOCATION_DOOR, LOCATION_CUPBOARD, "подойти к шкафу")
           .AddOption(LOCATION_DOOR, "открыть дверь", DoUnlockDoor, () => door_locked)
           .AddOption(LOCATION_DOOR, "бежать", DoLeave, () => !door_locked)

           .AddOption(LOCATION_PICTURE, LOCATION_DOOR, "подойти к двери")
           .AddOption(LOCATION_PICTURE, LOCATION_TABLE, "подойти к столику")
           .AddOption(LOCATION_PICTURE, LOCATION_CUPBOARD, "подойти к шкафу")
           .AddOption(LOCATION_PICTURE, "как в лучих фильмах снять картину", DoRepairPicture, () => picture_state == PICTURE_ON_WALL)
           .AddOption(LOCATION_PICTURE, "ввести код", DoEnterCode, () => picture_state == PICTURE_SAFE_LOCKED)
           .AddOption(LOCATION_PICTURE, "взять ключ", DoGetKey, () => picture_state == PICTURE_SAFE_UNLOCKED && !has_key)

           .AddOption(LOCATION_TABLE, LOCATION_DOOR, "подойти к двери")
           .AddOption(LOCATION_TABLE, LOCATION_PICTURE, "подойти к картине")
           .AddOption(LOCATION_TABLE, LOCATION_CUPBOARD, "подойти к шкафу")
           .AddOption(LOCATION_TABLE, "прочитать газету", DoReadNewspaper)
           .AddOption(LOCATION_TABLE, "Заглянуть под стол", DoTakeGun)

           .AddOption(LOCATION_CUPBOARD, LOCATION_DOOR, "подойти к двери")
           .AddOption(LOCATION_CUPBOARD, LOCATION_PICTURE, "подойти к картине")
           .AddOption(LOCATION_CUPBOARD, LOCATION_TABLE, "подойти к столу")
           .AddOption(LOCATION_CUPBOARD, "Заглянуть в шкаф", DoTakeBullet)
           

           .Build();

        return story;
    }

    string GetDoorDescription()
    {
        string desc = "Перед вами железная дверь в крови ";
        if (door_locked)
            desc += "\nОна заперта нужен ключ";
        return desc;
    }

    string GetPictureDescription()
    {
        string desc = "На стене висит картина клоуна.";
        if (picture_state == PICTURE_SAFE_LOCKED)
            desc = "Под ногами валяется картина а на ее месте - встроенный сейф с кодовым замком.";
        if (picture_state == PICTURE_SAFE_UNLOCKED)
        {
            desc = "Под ногами валяется картина а на ее месте - открытый сейф.";
            if (!has_key)
                desc += "\nВ глубине сейфа что-то блестит...";
            else
                desc += "\nСейф абсолютно пуст.";
        }
        return desc;
    }

    void DoUnlockDoor()
    {
        if (has_key)
        {
            door_locked = false;
            Alert("Вы отпираете дверь ключом!");
        }
        else
        {
            Alert("Для этого нужен ключ...");
        }
    }

    void DoLeave()
    {
        story.End = true;
        if (has_bullet && has_gun)
        {
            
            Alert("Вы успешно сбежали убив охранника!!!");
        }
        else
        {
            Alert("Вы открыли дверь но охранник ждал вас. Вас убили!!!");
        }
        
    }

    void DoReadNewspaper()
    {
        Alert("Вы берете в руки газету, но смогли разобрать только:");
        Alert($"год издания {code} ");
    }

    void DoRepairPicture()
    {
        Alert("Вы срываете картину, а за ней действительно...");
        Alert(" скрытый сейф!");
        picture_state = PICTURE_SAFE_LOCKED;
    }
    
    void DoEnterCode()
    {
        var c = GetInt("Введите код (4 цифры): ", 1000, 9999);
        if (c != code)
            Alert("ничего...видимо код неверен");
        else
        {
            Alert("бах!!! Похоже код подошел. Дверца сейфа отпала...");
            picture_state = PICTURE_SAFE_UNLOCKED;
        }
    }

    void DoGetKey()
    {
        Alert("А вот и  ключ!....но тот ли?");
        has_key = true;
    }
       void DoTakeGun()
    {
        Alert("Пистолет без пуль");
        has_gun = true;
    }
         void DoTakeBullet()
    {
        Alert("пули интересно для чего");
        has_bullet = true;
    }

}