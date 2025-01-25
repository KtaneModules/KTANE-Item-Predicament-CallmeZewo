using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KModkit;
using System.Linq;

public class ItemPredicament : MonoBehaviour
{

    public KMBombInfo Bomb;
    public KMAudio Audio;

    //Constants
    private const int NumberOfStats = 8;


    //Texts on Module
    public KMSelectable[] Buttons;
    public TextMesh[] DisplayTexts;

    //static Dictionarys

    //Name / ID / Quality / Stats effected
    static Dictionary<string, List<int>> ItemList = new Dictionary<string, List<int>>
            {
                { "Cricket's Head", new List<int> { 4, 3, 3 } },
                { "1UP", new List<int> { 11, 1, 0 } },
                { "The Belt", new List<int> { 28, 2, 1 } },
                { "Wire Coat Hanger", new List<int> { 32, 2, 2 } },
                { "The Book of Belial", new List<int> { 34, 4, 3 } },
                { "The Poop", new List<int> { 36, 0, 0 } },
                { "Yum Heart", new List<int> { 45, 1, 0 } },
                { "Lucky Foot", new List<int> { 46, 2, 6 } },
                { "Steam Sale", new List<int> { 64, 3, 0 } },
                { "Dead Cat", new List<int> { 81, 3, 0 } },
                { "The D6", new List<int> { 105, 4, 0 } },
                { "Money = Power", new List<int> { 109, 3, 3 } },
                { "Guardian Angel", new List<int> { 112, 4, 0 } },
                { "Mom's Knife", new List<int> { 114, 4, 0 } },
                { "Dead Bird", new List<int> { 117, 1, 0 } },
                { "Brimstone", new List<int> { 118, 4, -2 } },
                { "Whore of Babylon", new List<int> { 122, 2, 13 } },
                { "Bobby-Bomb", new List<int> { 125, 2, 0 } },
                { "Razor Blade", new List<int> { 126, 1, 3 } },
                { "Guppy's Paw", new List<int> { 133, 3, 0 } },
                { "Guppy's Tail", new List<int> { 134, 3, 0 } },
                { "Guppy's Head", new List<int> { 145, 3, 0 } },
                { "Polyphemus", new List<int> { 169, 4, -23 } },
                { "Guppy's Hairball", new List<int> { 187, 2, 0 } },
                { "Guppy's Collar", new List<int> { 212, 3, 0 } },
                { "Anemic", new List<int> { 214, 1, 4 } },
                { "Cricket's Body", new List<int> { 224, 3, 2-4 } },
                { "Death's Touch", new List<int> { 237, 4, -23 } },
                { "20/20", new List<int> { 245, 3, -3 } },
                { "Proptosis", new List<int> { 261, 4, 3 } },
                { "Blank Card", new List<int> { 286, 2, 0 } },
                { "Pandora's Box", new List<int> { 297, 3, 0 } },
                { "Holy Mantle", new List<int> { 313, 4, 0 } },
                { "Soy Milk", new List<int> { 330, 0, 2-3 } },
                { "Godhead", new List<int> { 331, 4, -23-5 } },
                { "Wooden Nickel", new List<int> { 349, 2, 0 } },
                { "Box of Friends", new List<int> { 357, 3, 0 } },
                { "Incubus", new List<int> { 360, 4, 0 } },
                { "Dead Eye", new List<int> { 373, 3, 3 } },
                { "Eden's Blessing", new List<int> { 381, 4, 2 } },
                { "Tech X", new List<int> { 395, 4, 0 } },
                { "Chaos", new List<int> { 402, 2, 0 } },
                { "Spider Mod", new List<int> { 403, 1, 0 } },
                { "Cambion Conception", new List<int> { 412, 2, 0 } },
                { "Kidney Stone", new List<int> { 440, 1, 2 } },
                { "Void", new List<int> { 477, 4, 0 } },
                { "Technology Zero", new List<int> { 524, 3, 0 } },
                { "120 Volt", new List<int> { 559, 2, 0 } },
                { "Rock Bottom", new List<int> { 562, 4, 0 } },
                { "Book of Virtues", new List<int> { 584, 4, 0 } },
                { "Eternal D6", new List<int> { 609, 4, 0 } },
                { "R Key", new List<int> { 636, 4, 0 } },
                { "Guppy's Eye", new List<int> { 665, 3, 0 } },
                { "C Section", new List<int> { 678, 4, 0 } },
                { "Dark Arts", new List<int> { 705, 4, 1 } },
                { "Abyss", new List<int> { 706, 4, 0 } },
                { "Suplex!", new List<int> { 709, 1, 0 } },
                { "Bag of Crafting", new List<int> { 710, 2, 0 } },
                { "Flip", new List<int> { 711, 4, 0 } },
                { "Lemegeton", new List<int> { 712, 3, 0 } },
                { "Sumptorium", new List<int> { 713, 1, 0 } },
                { "Hold", new List<int> { 715, 1, 0 } },
                { "Keeper's Sack", new List<int> { 716, 3, 0 } },
                { "Anima Sola", new List<int> { 722, 2, 0 } }
            };

    //Name / Pickups / Vowels * Konsonants
    static Dictionary<string, List<int>> CharacterList = new Dictionary<string, List<int>>
        {

            //Normal Characters

            { "Isaac", new List<int> { 1, 6 } },
            { "Magdalene", new List<int> { 1, 20 } },
            { "Cain", new List<int> { 2, 4 } },
            { "Judas", new List<int> { 3, 6 } },
            { "??? (Blue Baby)", new List<int> { 0, 15 } },
            { "Eve", new List<int> { 0, 2 } },
            { "Samson", new List<int> { 1, 8 } },
            { "Azazel", new List<int> { 1, 9 } },
            { "Lazarus", new List<int> { 1, 12 } },
            { "Eden", new List<int> { 0, 4 } },
            { "The Lost", new List<int> { 1, 10 } },
            { "Lilith", new List<int> { 0, 8 } },
            { "Keeper", new List<int> { 3, 9 } },
            { "Apollyon", new List<int> { 0, 15 } },
            { "The Forgotten", new List<int> { 0, 32 } },
            { "Bethany", new List<int> { 4, 10 } },
            { "Jacob and Esau", new List<int> { 0, 36 } },

            //Tainted Characters

            { "Tainted Isaac", new List<int> { 1, 36 } },
            { "Tainted Magdalene", new List<int> { 0, 63 } },
            { "Tainted Cain", new List<int> { 1, 30 } },
            { "Tainted Judas", new List<int> { 3, 35 } },
            { "Tainted ??? (Blue Baby)", new List<int> { 0, 54 } },
            { "Tainted Eve", new List<int> { 0, 25 } },
            { "Tainted Samson", new List<int> { 0, 40 } },
            { "Tainted Azazel", new List<int> { 1, 42 } },
            { "Tainted Lazarus", new List<int> { 0, 48 } },
            { "Tainted Eden", new List<int> { 0, 30 } },
            { "Tainted Lost", new List<int> { 1, 28 } },
            { "Tainted Lilith", new List<int> { 0, 40 } },
            { "Tainted Keeper", new List<int> { 3, 42 } },
            { "Tainted Apollyon", new List<int> { 0, 54 } },
            { "Tainted Forgotten", new List<int> { 0, 60 } },
            { "Tainted Bethany", new List<int> { 6, 45 } },
            { "Tainted Jacob", new List<int> { 0, 35 } }
        };

    //Name / I, II or None / Letter Count
    static Dictionary<string, List<int>> ChapterList = new Dictionary<string, List<int>>
    {
        { "Basement I", new List<int> { 1, 8 } },
        { "Basement II", new List<int> { 2, 8 } },
        { "Cellar I", new List<int> { 1, 6 } },
        { "Cellar II", new List<int> { 2, 6 } },
        { "Burning Basement I", new List<int> { 1, 15 } },
        { "Burning Basement II", new List<int> { 2, 15 } },
        { "Downpour I", new List<int> { 1, 8 } },
        { "Downpour II", new List<int> { 2, 8 } },
        { "Dross I", new List<int> { 1, 5 } },
        { "Dross II", new List<int> { 2, 5 } },
        { "Caves I", new List<int> { 1, 5 } },
        { "Caves II", new List<int> { 2, 5 } },
        { "Catacombs I", new List<int> { 1, 9 } },
        { "Catacombs II", new List<int> { 2, 9 } },
        { "Flooded Caves I", new List<int> { 1, 12 } },
        { "Flooded Caves II", new List<int> { 2, 12 } },
        { "Mines I", new List<int> { 1, 5 } },
        { "Mines II", new List<int> { 2, 5 } },
        { "Ashpit I", new List<int> { 1, 6 } },
        { "Ashpit II", new List<int> { 2, 6 } },
        { "Depths I", new List<int> { 1, 6 } },
        { "Depths II", new List<int> { 2, 6 } },
        { "Necropolis I", new List<int> { 1, 10 } },
        { "Necropolis II", new List<int> { 2, 10 } },
        { "Dank Depths I", new List<int> { 1, 10 } },
        { "Dank Depths II", new List<int> { 2, 10 } },
        { "Mausoleum I", new List<int> { 1, 9 } },
        { "Mausoleum II", new List<int> { 2, 9 } },
        { "Gehenna I", new List<int> { 1, 7 } },
        { "Gehenna II", new List<int> { 2, 7 } },
        { "Womb I", new List<int> { 1, 4 } },
        { "Womb II", new List<int> { 2, 4 } },
        { "Utero I", new List<int> { 1, 5 } },
        { "Utero II", new List<int> { 2, 5 } },
        { "Scarred Womb I", new List<int> { 1, 11 } },
        { "Scarred Womb II", new List<int> { 2, 11 } },
        { "???", new List<int> { 0, 0 } },
        { "Corpse I", new List<int> { 1, 6 } },
        { "Corpse II", new List<int> { 2, 6 } },
        { "Cathedral", new List<int> { 0, 9 } },
        { "Sheol", new List<int> { 0, 5 } },
        { "Chest", new List<int> { 0, 5 } },
        { "Dark Room", new List<int> { 0, 8 } },
        { "The Void", new List<int> { 0, 7 } },
        { "Home", new List<int> { 0, 4 } },
    };

    //Name / Start Item
    static Dictionary<string, List<string>> CharacterStartItemList = new Dictionary<string, List<string>>
    {

        //Normal Characters

        { "Isaac", new List<string> { "The D6" } },
        { "Magdalene", new List<string> { "Yum Heart" } },
        { "Cain", new List<string> { "Lucky Foot" } },
        { "Judas", new List<string> { "The Book of Belial" } },
        { "Eve", new List<string> { "Whore of Babylon", "Dead Bird", "Razor Blade" } },
        { "Samson", new List<string> { "Bloody Lust" } },
        { "Azazel", new List<string> { "Brimstone" } },
        { "Lazarus", new List<string> { "Anemic" } },
        { "Eden", new List<string> { "Error 404", "Error 404" } },
        { "The Lost", new List<string> { "Eternal D6", "Holy Mantle" } },
        { "Lilith", new List<string> { "Incubus", "Cambion Concept", "Box of Friends" } },
        { "Keeper", new List<string> { "Wooden Nickel" } },
        { "Apollyon", new List<string> { "Void" } },
        { "Bethany", new List<string> { "Book of Virtues" } },

        // Tainted Characters

        { "Tainted Magdalene", new List<string> { "Yum Heart" } },
        { "Tainted Cain", new List<string> { "Bag of Crafting" } },
        { "Tainted Judas", new List<string> { "Dark Arts" } },
        { "Tainted ??? (Blue Baby)", new List<string> { "Hold" } },
        { "Tainted Eve", new List<string> { "Sumptorium" } },
        { "Tainted Lazarus", new List<string> { "Flip" } },
        { "Tainted Eden", new List<string> { "Error 404" } },
        { "Tainted Bethany", new List<string> { "Lemegeton" } },
        { "Tainted Jacob", new List<string> { "Anima Sola" } }
    };

    //Name / Item
    static Dictionary<string, List<string>> ItemPools = new Dictionary<string, List<string>>
    {
        // Boss Room Item Pool
        { "Boss Room", new List<string> { "The Belt", "Wire Coat Hanger", "Lucky Foot", "Cricket's Body", "Soy Milk", "120 Volt", "Anima Sola", "Suplex!" } },

        // Treasure Room Item Pool
        { "Treasure Room", new List<string> { "Cricket's Head", "The D6", "Technology Zero", "Dead Bird", "Bobby-Bomb", "20/20", "The Poop", "Yum Heart", "Razor Blade", "Dead Eye", "Polyphemus", "Anemic", "Proptosis" } },

        // Shop Room Item Pool
        { "Shop", new List<string> { "Steam Sale", "Hold", "Money = Power", "Blank Card", "Keeper's Sack", "Wooden Nickel", "Bag of Crafting", "Spider Mod", "Box of Friends" } },

        // Curse Room Item Pool
        { "Curse Room", new List<string> { "Guppy's Eye", "Whore of Babylon", "Guppy's Paw", "Pandora's Box", "Dark Arts", "Guppy's Head", "Guppy's Hairball" } },

        // Secret Room Item Pool
        { "Secret Room", new List<string> { "1UP", "Tech X", "Chaos", "Sumptorium", "Rock Bottom", "Dead Cat", "R Key", "Death's Touch", "C Section", "Kidney Stone" } },

        // Angel Deal Item Pool
        { "Angel Deal", new List<string> { "Guardian Angel", "Holy Mantle", "Eternal D6", "Godhead", "Eden's Blessing", "Void", "Book of Virtues" } },

        // Devil Deal Item Pool
        { "Devil Deal", new List<string> { "The Book of Belial", "Abyss", "Mom's Knife", "Brimstone", "Flip", "Guppy's Tail", "Lemegeton", "Guppy's Collar", "Incubus", "Cambion Conception" } }
    };

    //Default Var

    string SerialNumber;
    string ConvertedSerialNumber;

    string ChapterWithRoman;
    string Chapter;
    string Character;
    List<float> Stats;
    List<string> Items;

    //Step 1 Var
    int Roman;
    int FirstMatchInSerialNumber;
    string YourRoom;

    //Step 2 Var
    int CharacterNumber;
    List<int> YourStats;

    //Step 3 Var
    Dictionary<int, List<int>> ItemStats;
    List<bool> ButtonNeedsPress;
    List<int> ButtonOrder;


    static int ModuleIdCounter = 1;
    int ModuleId;
    private bool ModuleSolved;

    void Awake()
    { //Avoid doing calculations in here regarding edgework. Just use this for setting up buttons for simplicity.
        ModuleId = ModuleIdCounter++;
        GetComponent<KMBombModule>().OnActivate += Activate;
        /*
        foreach (KMSelectable object in keypad) {
            object.OnInteract += delegate () { keypadPress(object); return false; };
        }
        */

        //button.OnInteract += delegate () { buttonPress(); return false; };

    }

    void OnDestroy()
    { //Shit you need to do when the bomb ends

    }

    void Activate()
    { //Shit that should happen when the bomb arrives (factory)/Lights turn on

    }

    void Start()
    { //Shit that you calculate, usually a majority if not all of the module

        //Get Bomb Info
        SerialNumber = Bomb.GetSerialNumber();
        ConvertedSerialNumber = ConvertSerialNumber(SerialNumber);

        //
        // Setup Bomb (Randomize stuff)
        //

        //Chapter Name
        DisplayTexts[0].text = ChapterWithRoman = GetRandomChapterName();

        //Character Name
        DisplayTexts[1].text = Character = GetRandomCharacterName();

        //Stats Values
        //Coming after prep
        Stats = GetRandomStats();
        DisplayTexts[2].text = "Speed:      " + Stats[0] +
                               "\nTears:      " + Stats[1] +
                               "\nDamage:     " + Stats[2] +
                               "\nRange:      " + Stats[3] +
                               "\nShotspeed:  " + Stats[4] +
                               "\nLuck:       " + Stats[5] +
                               "\nDevil Deal: " + Stats[6] + "%" +
                               "\nAngel Deal: " + Stats[7] + "%";

        //Item Names
        Items = GetRandomItemNames();
        for (int i = 0; i < Items.Count; i++)
        {
            DisplayTexts[i + 3].text = Items[i];
        }

        //
        //Step 1
        //

        Roman = GetRomanAsIntAndConvertChapterRomanToChapter();
        FirstMatchInSerialNumber = GetFirstMatchInConvertedSerialNumber();
        YourRoom = GetYourRoom();

        //
        //Step 2
        //

        CharacterNumber = CalculateCharacterNumber();
        YourStats = GetYourStats();

        foreach (int i in YourStats)
        {
            Debug.Log(i);
        }

        //
        //Step 3
        //
        ItemStats = new Dictionary<int, List<int>>();
        ButtonNeedsPress = GetButtonsThatNeedsToBePressed();
        ButtonOrder = GetButtonOrder();
        for (int i = 0; i < 4; i++)
        {
            foreach (int y in ItemStats[i])
            {
                Debug.Log(y);
            }
        }

    }

    void Update()
    { //Shit that happens at any point after initialization

    }

    #region Setup Methodes

    string GetRandomChapterName()
    {
        return ChapterList.Keys.ElementAt(Random.Range(0, ChapterList.Count));
    }

    string GetRandomCharacterName()
    {
        return CharacterList.Keys.ElementAt(Random.Range(0, CharacterList.Count));
    }

    List<string> GetRandomItemNames()
    {
        return ItemList.Keys
            .OrderBy(x => Random.Range(0, int.MaxValue))
            .Take(4)
            .ToList();
    }

    List<float> GetRandomStats()
    {
        int[] minValues = { 85, 223, 250, 500, 75, 0, 0 };
        int[] maxValues = { 155, 348, 450, 800, 125, 100, 100 };
        List<float> randomStats = new List<float>();

        for (int i = 0; i < minValues.Length - 1; i++)
        {
            randomStats.Add(Random.Range(minValues[i], maxValues[i]) / 100f);
        }

        randomStats.Add(Random.Range(minValues[6], maxValues[6]));
        randomStats.Add(100 - randomStats[6]);

        return randomStats;
    }

    #endregion

    #region Step 1

    string ConvertSerialNumber(string serialNumber)
    {
        string result = "";

        foreach (char c in serialNumber)
        {
            if (char.IsDigit(c))
            {
                result += (char)('a' + (c - '0'));
            }
            else
            {
                result += c;
            }
        }
        return result.ToUpper();
    }

    int GetRomanAsIntAndConvertChapterRomanToChapter()
    {
        if (ChapterWithRoman.EndsWith(" I"))
        {
            Chapter = ChapterWithRoman.Substring(0, ChapterWithRoman.Length - 2);
            return 1;
        }
        else if (ChapterWithRoman.EndsWith(" II"))
        {

            Chapter = ChapterWithRoman.Substring(0, ChapterWithRoman.Length - 3);
            return 2;
        }

        Chapter = ChapterWithRoman;
        return 0;
    }

    int GetFirstMatchInConvertedSerialNumber()
    {
        for (int i = 0; i < ConvertedSerialNumber.Length; i++)
        {
            char currentCharacter = ConvertedSerialNumber[i];
            if (Chapter.IndexOf(currentCharacter.ToString(), System.StringComparison.OrdinalIgnoreCase) >= 0)
            {

                return i + 1;

            }
        }

        return 0;
    }

    string GetYourRoom()
    {
        Dictionary<int, string> yourRooms = new Dictionary<int, string>
        {
            { 10, "Secret Room" },
            { 11, "Shop" },
            { 12, "Treasure Room" },
            { 20, "Shop" },
            { 21, "Curse Room" },
            { 22, "Boss Room" },
            { 30, "Treasure Room" },
            { 31, "Secret Room" },
            { 32, "Shop" },
            { 40, "Secret Room" },
            { 41, "Boss Room" },
            { 42, "Treasure Room" },
            { 50, "Curse Room" },
            { 51, "Treasure Room" },
            { 52, "Boss Room" },
            { 60, "Treasure Room" },
            { 61, "Shop" },
            { 62, "Curse Room" },
        };

        int generatedKey = FirstMatchInSerialNumber * 10 + Roman;
        if (yourRooms.ContainsKey(generatedKey))
        {
            return yourRooms[generatedKey];
        }

        return "Boss Room";
    }

    #endregion

    #region Step 2

    int CalculateCharacterNumber()
    {
        int yourRoomCount = YourRoom.Count(char.IsLetter);
        int vowTimesKonsNumber = CharacterList[Character][1];
        if (vowTimesKonsNumber % 3 == 0)
        {
            return vowTimesKonsNumber + yourRoomCount;
        }

        return Mathf.Abs(vowTimesKonsNumber - yourRoomCount);
    }

    string ConvertCharacterNumber()
    {
        if (CharacterNumber <= 10)
            return "1";
        if (CharacterNumber <= 20)
            return "2";
        if (CharacterNumber <= 30)
            return "3";
        if (CharacterNumber == 30)
            return "4";
        if (CharacterNumber >= 30)
            return "5";
        if (CharacterNumber >= 40)
            return "6";
        if (CharacterNumber >= 50)
            return "7";
        return "8";
    }

    List<int> GetYourStats()
    {
        List<int> yourStats = new List<int>();

        Dictionary<string, List<int>> statDictionary = new Dictionary<string, List<int>>
        {
            //Boss Room
            { "Boss Room_1", new List<int> { 6, 1, 4 } },
            { "Boss Room_2", new List<int> { 6, 1 } },
            { "Boss Room_3", new List<int> { 6 } },
            { "Boss Room_4", new List<int> { 6, 3 } },
            { "Boss Room_5", new List<int> { 3 } },
            { "Boss Room_6", new List<int> { 3, 5 } },
            { "Boss Room_7", new List<int> { 3, 5, 2 } },
            { "Boss Room_8", new List<int> { 3, 5, 2, 8 } },

            //Treasure Room
            { "Treasure Room_1", new List<int> { 2, 1, 5 } },
            { "Treasure Room_2", new List<int> { 2, 1 } },
            { "Treasure Room_3", new List<int> { 2 } },
            { "Treasure Room_4", new List<int> { 2, 4 } },
            { "Treasure Room_5", new List<int> { 4 } },
            { "Treasure Room_6", new List<int> { 4, 3 } },
            { "Treasure Room_7", new List<int> { 4, 3, 8 } },
            { "Treasure Room_8", new List<int> { 4, 3, 8, 6 } },

            //Shop
            { "Shop_1", new List<int> { 2, 4, 6 } },
            { "Shop_2", new List<int> { 2, 4 } },
            { "Shop_3", new List<int> { 2 } },
            { "Shop_4", new List<int> { 2, 1 } },
            { "Shop_5", new List<int> { 1 } },
            { "Shop_6", new List<int> { 1, 3 } },
            { "Shop_7", new List<int> { 1, 3, 7 } },
            { "Shop_8", new List<int> { 1, 3, 7, 5 } },

            //Curse Room
            { "Curse Room_1", new List<int> { 7, 3, 5 } },
            { "Curse Room_2", new List<int> { 7, 3 } },
            { "Curse Room_3", new List<int> { 7 } },
            { "Curse Room_4", new List<int> { 7, 6 } },
            { "Curse Room_5", new List<int> { 6 } },
            { "Curse Room_6", new List<int> { 6, 4 } },
            { "Curse Room_7", new List<int> { 6, 4, 2 } },
            { "Curse Room_8", new List<int> { 6, 4, 2, 1 } },

            //Secret Room
            { "Secret Room_1", new List<int> { 1, 5, 3 } },
            { "Secret Room_2", new List<int> { 1, 5 } },
            { "Secret Room_3", new List<int> { 1 } },
            { "Secret Room_4", new List<int> { 1, 7 } },
            { "Secret Room_5", new List<int> { 7 } },
            { "Secret Room_6", new List<int> { 7, 2 } },
            { "Secret Room_7", new List<int> { 7, 2, 8 } },
            { "Secret Room_8", new List<int> { 7, 2, 8, 4 } },
        };

        string generateKey = YourRoom + "_" + ConvertCharacterNumber();

        yourStats.AddRange(statDictionary[generateKey]);

        return yourStats;
    }

    #endregion

    #region Step 3

    List<bool> GetButtonsThatNeedsToBePressed()
    {
        List<bool> buttonPressListMain = new List<bool> { false, false, false, false };


        buttonPressListMain = FirstCheck(buttonPressListMain);
        buttonPressListMain = SecondCheck(buttonPressListMain);
        buttonPressListMain = ThirdCheck(buttonPressListMain);
        buttonPressListMain = FourthCheck(buttonPressListMain);

        if (buttonPressListMain[0] == false &&
            buttonPressListMain[1] == false &&
            buttonPressListMain[2] == false &&
            buttonPressListMain[3] == false)
        {
            buttonPressListMain[0] = buttonPressListMain[1] = buttonPressListMain[2] = buttonPressListMain[3] = true;
        }

        return buttonPressListMain;

    }

    List<bool> FirstCheck(List<bool> buttonPressListSub1)
    {
        int index = 0;
        foreach (string item in Items)
        {
            int itemStatsRaw = ItemList[item][2];
            var numbers = System.Text.RegularExpressions.Regex.Matches(itemStatsRaw.ToString(), @"-?\d");
            List<int> itemStatsConvert = new List<int>();

            foreach (var digit in numbers)
            {
                itemStatsConvert.Add(int.Parse(digit.ToString()));
            }

            ItemStats[index] = itemStatsConvert;

            List<int> duplicates = ItemStats[index].Intersect(YourStats).ToList();

            if (duplicates.Count != 0)
            {
                buttonPressListSub1[index] = true;
            }

            index++; 
        }

        return buttonPressListSub1;
    }

    List<bool> SecondCheck(List<bool> buttonPressListSub2)
    {
        int characterPickups = CharacterList[Character][0];
        int index = 0;
        foreach (string item in Items)
        {
            int itemID = ItemList[item][0];

            if (itemID.ToString().Contains(characterPickups.ToString()))
            {
                buttonPressListSub2[index] = true;
            }
        }

        return buttonPressListSub2;
    }

    List<bool> ThirdCheck(List<bool> buttonPressListSub3)
    {
        if (Stats[6] >= 70 || Stats[7] >= 70)
        {
            return buttonPressListSub3;
        }

        int index = 0;
        foreach (string item in Items)
        {
            bool devilDeal = ItemPools["Devil Deal"].Contains(item);
            bool angelDeal = ItemPools["Angel Deal"].Contains(item);

            if (angelDeal || devilDeal)
            {
                buttonPressListSub3[index] = true;
            }
        }

        return buttonPressListSub3;

    }

    List<bool> FourthCheck(List<bool> buttonPressListSub4)
    {
        if (!CharacterStartItemList.ContainsKey(Character))
        {
            return buttonPressListSub4;
        }

        int index = 0;
        foreach (string item in Items)
        {
            if (CharacterStartItemList[Character].Contains(item))
            {
                buttonPressListSub4[index] = true;
            }
        }

        return buttonPressListSub4;
    }


    List<int> GetButtonOrder()
    {
        List<List<int>> buttonChecks = new List<List<int>>
        {
            new List<int>(),
            new List<int>(),
            new List<int>(),
            new List<int>(),
        };

        int index = 0;
        foreach (List<int> button in buttonChecks)
        {
            button.Add(FirstOrderCheck(index));
            button.Add(SecondOrderCheck(index));
            button.Add(ThirdOrderCheck(index));
            button.Add(FourthOrderCheck(index));
            button.Add(FifthOrderCheck(index));
        }

        return new List<int>();

    }

    int FirstOrderCheck(int index)
    {
        if (ItemPools[YourRoom].Contains(Items[index]))
        {
            return 1;
        }

        return 0;
    }

    int SecondOrderCheck(int index)
    {
        if (ItemPools["Devil Deal"].Contains(Items[index]) || ItemPools["Angel Deal"].Contains(Items[index]))
        {
            return 2;
        }

        return 0;
    }

    int ThirdOrderCheck(int index)
    {
        List<int> duplicates = ItemStats[index].Intersect(YourStats).ToList();
        List<int> YourStatsN = YourStats.Select(x => -x).ToList();
        List<int> duplicatesN = ItemStats[index].Intersect(YourStatsN).ToList();

        duplicates.AddRange(duplicatesN);

        List<int> affectedStats = duplicates.Select(System.Math.Abs).ToList();

        foreach (int stat in affectedStats)
        {
            if (Stats[stat - 1] % 2 == 0)
            {
                return 3;
            }
        }

        return 0;
    }

    int FourthOrderCheck(int index)
    {
        return 0;
    }

    int FifthOrderCheck(int index)
    {
        return 0;
    }

    #endregion

    void Solve()
    {
        GetComponent<KMBombModule>().HandlePass();
    }

    void Strike()
    {
        GetComponent<KMBombModule>().HandleStrike();
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use !{0} to do something.";
#pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string Command)
    {
        yield return null;
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        yield return null;
    }
}
