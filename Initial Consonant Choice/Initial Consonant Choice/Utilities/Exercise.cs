using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_Consonant_Choice.Utilities
{
    public class Exercise
    {
        public String promptWord;
        public String[] choices;
        public int[] choiceOrder = new int[] { 1, 2, 3 };
        public String correctChoice;
        public int correctChoiceIndex;

        public Exercise(String promptWord, String[] choices, String correctChoice)
        {
            this.promptWord = promptWord;
            this.choices = choices;
            this.correctChoice = correctChoice;
            shuffleChoices();
            this.correctChoiceIndex = Array.IndexOf(choices, correctChoice);
        }

        public Exercise(String promptWord, String[] choices, int correctChoiceIndex)
        {
            this.promptWord = promptWord;
            this.choices = choices;
            this.correctChoice = choices[correctChoiceIndex];
            shuffleChoices();
            this.correctChoiceIndex = Array.IndexOf(choices, correctChoice);
        }

        public Exercise(String promptWord, String choice1, String choice2, String choice3, String correctChoice)
        {
            this.promptWord = promptWord;
            this.choices = new String[] { choice1, choice2, choice3 };
            this.correctChoice = correctChoice;
            shuffleChoices();
            this.correctChoiceIndex = Array.IndexOf(choices, correctChoice);
        }

        public void shuffleChoices()
        {
            Random rand = new Random();
            for (int i = 0; i < choices.Length; i++)
            {
                int randomIndex = rand.Next(choices.Length);
                String temp = choices[i];
                int tempOrder = choiceOrder[i];
                choices[i] = choices[randomIndex];
                choiceOrder[i] = choiceOrder[randomIndex];
                choices[randomIndex] = temp;
                choiceOrder[randomIndex] = tempOrder;
            }
        }
    }

    public static class ExerciseManager
    {
        public static List<Exercise> practiceExercises = new List<Exercise>()
        {
            new Exercise("pet", "fire", "pack", "night", "pack"),
            new Exercise("blue", "bag", "fox", "egg", "bag"),
            new Exercise("cake", "sheep", "note", "kite", "kite"),
            new Exercise("ball", "book", "seed", "mouth", "book"),
            new Exercise("face", "pig", "fur", "top", "fur"),
            new Exercise("seal", "can", "dog", "sun", "sun")
        };

        public static List<Exercise> exercises = new List<Exercise>()
        {
            new Exercise("milk", "date", "moon", "bag", "moon"),
            new Exercise("pear", "pen", "tile", "mask", "pen"),
            new Exercise("stick", "slide", "drum", "flag", "slide"),
            new Exercise("bone", "meat", "lace", "bud", "bud"),
            new Exercise("soap", "king", "dime", "salt", "salt"),
            new Exercise("claw", "prize", "crib", "stair", "crib"),
            new Exercise("leg", "pin", "lock", "boat", "lock"),
            new Exercise("duck", "door", "soup", "light", "door"),
            new Exercise("plum", "tree", "star", "price", "price"),
            new Exercise("key", "fist", "cap", "sap", "cap"),
            new Exercise("zip", "zoo", "web", "man", "zoo"),
            new Exercise("gate", "sun", "bin", "gum", "gum"),
            new Exercise("rug", "can", "rag", "pit", "rag"),
            new Exercise("sky", "sleep", "crumb", "drip", "sleep"),
            new Exercise("fun", "dark", "pet", "fan", "fan"),
            new Exercise("peel", "wash", "pat", "vine", "pat"),
            new Exercise("grape", "class", "glue", "swing", "glue"),
            new Exercise("leap", "lip", "note", "wheel", "lip"),
            new Exercise("house", "rain", "heel", "kid", "heel"),
            new Exercise("toes", "bit", "girl", "tip", "tip"),
            new Exercise("win", "well", "foot", "pan", "well"),
            new Exercise("met", "map", "day", "box", "map"),
            new Exercise("sled", "frog", "brush", "stick", "stick"),
            new Exercise("jeep", "lock", "pail", "jug", "jug"),
            new Exercise("clean", "spoon", "cry", "free", "cry"),
            new Exercise("lamb", "juice", "cage", "lick", "lick"),
            new Exercise("dog", "dart", "fall", "girl", "dart"),
            new Exercise("rake", "pig", "root", "bike", "root"),
            new Exercise("meat", "new", "doll", "mice", "mice"),
            new Exercise("boot", "cat", "bus", "push", "bus"),
            new Exercise("nail", "lay", "bye", "nut", "nut"),
            new Exercise("stop", "skirt", "train", "crawl", "skirt"),
            new Exercise("top", "gum", "big", "two", "two"),
            new Exercise("hen", "have", "save", "down", "have"),
            new Exercise("keep", "kiss", "rock", "bark", "kiss"),
            new Exercise("clap", "tree", "crab", "slip", "crab"),
            new Exercise("queen", "wheel", "gift", "quit", "quit"),
            new Exercise("hot", "hill", "fence", "base", "hill"),
            new Exercise("jog", "jar", "dig", "cow", "jar"),
            new Exercise("zap", "game", "zoom", "bed", "zoom"),
            new Exercise("dot", "pink", "fish", "dime", "dime"),
            new Exercise("bat", "song", "barn", "fun", "barn"),
            new Exercise("fly", "truck", "fruit", "skip", "fruit"),
            new Exercise("need", "nose", "hop", "draw", "nose"),
            new Exercise("wall", "deer", "leaf", "web", "web"),
            new Exercise("van", "vase", "part", "like", "vase"),
            new Exercise("town", "dip", "tick", "king", "tick"),
            new Exercise("glow", "fry", "drop", "grass", "grass")
        };
    }
}
