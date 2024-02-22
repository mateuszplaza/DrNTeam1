using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Initial_Consonant_Choice.Utilities
{
    internal class AudioManager
    {
        private String audioPath = "";
        private Dictionary<Tuple<int, int>, String> wordMap = new Dictionary<Tuple<int, int>, String>();
        public AudioManager(String audioPath)
        {
            this.audioPath = audioPath;
            string[] files = Directory.GetFiles(audioPath, "*.wav", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                string fileName = file.Substring(file.LastIndexOf('\\') + 1);
                string[] fileNameSplit = fileName.Split('_');
                Tuple<int, int> t = new Tuple<int, int>(Int32.Parse(fileNameSplit[0]), Int32.Parse(fileNameSplit[1]));
                wordMap.Add(t, fileNameSplit[2].Substring(0, fileNameSplit[2].Length-4));
            }
        }
        public void PlaySound(int trial, int index)
        {
            SoundPlayer soundPlayer = new SoundPlayer(audioPath + "\\" + trial + "_" + index + "_" + wordMap[new Tuple<int, int>(trial, index)] + ".wav");
            soundPlayer.Play();
        }
    }
}

