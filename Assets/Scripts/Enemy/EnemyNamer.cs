using TMPro;
using UnityEngine;

public class EnemyNamer : MonoBehaviour
{
    public TextMeshProUGUI title;

    public string[] firstNames = {
                    "Timmy",
                    "Jimothy",
                    "Larry Jr",
                    "Larry Sr",
                    "Barbara",
                    "Roger",
                    "Gary Jr",
                    "Gary Sr",
                    "Tod",
                    "Nathan",
                    "Robert",
                    "Gregor",
                    "Rodney",
                    "Bartholomew",
                    "Gustav",
                    "Kyle",
                    "Steve",
                    "Chad",
                    "Steven",
                    "Stevenson",
                    "Stevenfather",
                    "Anna",
                    "Alvin",
                    "Andrew",
                    "Jung",
                    "Niko",
                    "Julian",
                    "Avariel",
                    "Gabe",
                    "Embrodyle",
                    "Scott",
                    "Vincent",
                    "Joe",
                    "Peter",
                    "Alfred",
                    "Alfonso",
                    "Oregano",
                    "Daniel"
                };

    public string[] titles1 = {
                    "Demonspawn",
                    "Dragon Slayer",
                    "Bloody Barbarian",
                    "Necrotic Zombie",
                    "Succulent Blademaster",
                    "Divine Pioneer",
                    "Bog Man",
                    "Draconic Striker",
                    "Gleaming Archangel",
                    "Grotesque Valkyrja",
                    "Fruity Loop",
                    "Crunchy Captain",
                    "Salty Spitoon",
                    "Shadowcaster",
                    "Hell Warrior",
                    "Dragon Knight",
                    "Living Armor",
                    "Lich King",
                    "Eyeless Dark",
                    "Bison",
                    "Abyss Seeker",
                    "Scallop King",
                    "Numbers Lord",
                    "Crazed Maniac",
                    "Doubtful Heretic",
                    "Yap-master",
                    "Divine Mechanism",
                    "Approaching Storm",
                    "Cultist",
                    "Cawthorn",
                    "Purple Man",
                    "Bearlord",
                    "Mercenary King",
                    "United Independance",
                    "Righteous Chef",
                    "Spicy Growth",
                    "Bejeweled Jewel"
                };

    public string[] titles2 = {
                    "Scourge of Hell",
                    "Harbinger of the Dawn",
                    "Bioweapon of Ruin",
                    "Bard of 17 Hells",
                    "Delver of Disease",
                    "Anathema of Despair",
                    "Soothsayer of Meowmeow",
                    "Seeker of Truth",
                    "Acolyte of Innocence",
                    "Cardinal of the Depths",
                    "Aegisguard of Light",
                    "Lady of Silver",
                    "Ruination of Ithica",
                    "Exalt of Heaven",
                    "Keeper of Peace",
                    "Nemesis of God",
                    "Seeker of Love",
                    "Overlord of the Dead",
                    "Overlord of the Happy",
                    "Weaver of Fate",
                    "Scribe of Destiny",
                    "Supporter of Public Infrastructure",
                    "Scavenger of the Skies",
                    "Builder of the Raceways",
                    "Splatter of Toons",
                    "Witch of Deez",
                    "Warrior of Light",
                    "Traveler of Aurora",
                    "Fetcher of Felines",
                    "Guard of the Night",
                    "Butcher of Kin",
                    "Druid of the West",
                    "Eater of Ants",
                    "Knight of Slop",
                    "Player of the Ultimate Game",
                    "Sovereign of Peppers",
                    "Champion of the Dunes"
                };

    public string[] titles3 = {
                    "Lord of the Deep",
                    "Master of Bog",
                    "Wrangler of Soup",
                    "Vanquisher of Bugs",
                    "Keeper of Golden Riches",
                    "Sentinal of Dark Waters",
                    "Inquisitor of Plagues",
                    "Marquis of Control",
                    "Adjucator of Blossoms",
                    "Conduit to the Heavens",
                    "Hierophant of the Moon",
                    "Prophet of Somebody",
                    "Fish of No Maidens",
                    "Grand Wizard of Hoz",
                    "Hand of Flora and Fauna",
                    "Covenant of the Deep",
                    "Devil of Fire and Ice",
                    "Witness to the End",
                    "Creator of the Beginning",
                    "Throne of Sorrow",
                    "Dancer of Music",
                    "Keeper of Twin Beasts",
                    "Coder of Words",
                    "Crosser of Lines",
                    "Scourge of Silliness",
                    "Jester of Clowns",
                    "Great Spirit of Humanity",
                    "Muse of God",
                    "Captivator of Hearts",
                    "Bite of 87",
                    "Man behind the Slaughter",
                    "Crafter of Mines",
                    "Digger of Holes",
                    "Destruction of Consolations",
                    "Ripper of Contracts",
                    "Devil from the Bible",
                    "Guardian of No More Blood"
                };

    void Start() {
        // 1-3 Name, no Title
        // 4-6 Name, a Title
        // 7-8 Name, 2 Titles
        // 9-n Name, 3 Titles

        int enemyLevel = gameObject.GetComponentInParent<EnemyScript>().enemyLevel;
        if (enemyLevel < 4)
        {
            title.text = firstNames[Mathf.FloorToInt(Random.value * 38)];
        }
        else if (enemyLevel < 7)
        {
            title.text = firstNames[Mathf.FloorToInt(Random.value * 38)] + " the " + titles1[Mathf.FloorToInt(Random.value * 37)];
        }
        else if (enemyLevel < 9)
        {
            title.text = firstNames[Mathf.FloorToInt(Random.value * 38)] + " the " + titles1[Mathf.FloorToInt(Random.value * 37)] + " and the " + titles2[Mathf.FloorToInt(Random.value * 37)];
        }
        else
        {
            title.text = firstNames[Mathf.FloorToInt(Random.value * 38)] + " the " + titles1[Mathf.FloorToInt(Random.value * 37)] + ", the " + titles1[Mathf.FloorToInt(Random.value * 37)] + ", and the " + titles1[Mathf.FloorToInt(Random.value * 37)];
        }
    }
}
