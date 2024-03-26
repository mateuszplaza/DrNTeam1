using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Initial_Consonant_Choice.Utilities
{
    public class AudioManager
    {
        SoundPlayer soundPlayer;

        //Maps a tuple containing the trial number and word index to a string containing the word
        private Dictionary<Tuple<int, int>, String> wordMap = new Dictionary<Tuple<int, int>, String>();

        //Constructor that takes a path to the folder containing the audio files and builds the wordMap
        public AudioManager()
        {
            var resourceManager = Properties.Resources.ResourceManager;
            var resourceSet = resourceManager.GetResourceSet(CultureInfo.InvariantCulture, createIfNotExists: true, tryParents: true);

            foreach (DictionaryEntry entry in resourceSet)
            {
                string[] fileNameSplit = entry.Key.ToString().Split('_');
                if (fileNameSplit.Length == 4 && fileNameSplit[0] == "") //Audio resources start with _ and have 3 underlines
                {
                    try
                    {
                        Tuple<int, int> t = new Tuple<int, int>(Int32.Parse(fileNameSplit[1]), Int32.Parse(fileNameSplit[2]));
                        wordMap.Add(t, fileNameSplit[3]);
                    } catch //In case non-audio files pass the if statement
                    {
                        Console.WriteLine(entry.Key.ToString());
                    }
                }
            }
        }
        //Given a trial number and word index, play the given sound.
        public void PlaySound(int trial, int index, bool isPractice)
        {
            if (isPractice)
            {
                trial += 100;
            }
            soundPlayer = new SoundPlayer(Properties.Resources.ResourceManager.GetStream($"_{trial}_{index}_{wordMap[new Tuple<int, int>(trial, index)]}"));
            soundPlayer.Play();
        }

        //Same as PlaySound, but synchronous
        public void PlaySoundSync(int trial, int index, bool isPractice)
        {
            if (isPractice)
            {
                trial += 100;
            }
            soundPlayer = new SoundPlayer(Properties.Resources.ResourceManager.GetStream($"_{trial}_{index}_{wordMap[new Tuple<int, int>(trial, index)]}"));
            soundPlayer.PlaySync();
        }

        public void StartHorseSound()
        {
            soundPlayer = new SoundPlayer(Properties.Resources.ResourceManager.GetStream($"horse_snort_audio"));
            soundPlayer.Play();
        }
        public void HorseRunSound()
        {
            soundPlayer = new SoundPlayer(Properties.Resources.ResourceManager.GetStream($"horse_gallop_audio"));
            soundPlayer.Play();
        }

        public void PlayCheer()
        {
            soundPlayer = new SoundPlayer(Properties.Resources.ResourceManager.GetStream($"cheer_audio"));
            soundPlayer.Play();
        }

        public void StopSound()
        {
            soundPlayer.Stop();
        }
    }
}

