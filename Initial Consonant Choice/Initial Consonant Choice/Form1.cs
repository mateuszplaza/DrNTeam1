using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Speech.Synthesis;


namespace Initial_Consonant_Choice
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer synth;
        ReadOnlyCollection<InstalledVoice> voices;
        public Form1()
        {
            InitializeComponent();
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            voices = synth.GetInstalledVoices();
            foreach (InstalledVoice voice in voices)
            {
                if(voice.Enabled)
                {
                    voicesBox.Items.Add(voice.VoiceInfo.Name);
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            synth.SelectVoice(voices[voicesBox.SelectedIndex].VoiceInfo.Name);
            synth.Rate = int.Parse(speedBox.Text);
            synth.SpeakAsync(input.Text);
        }
    }
}
