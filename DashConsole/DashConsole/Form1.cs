using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace DashConsole
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speech = new SpeechSynthesizer();
        Choices choices = new Choices();

        public Form1()
        {


            SpeechRecognitionEngine rec = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));

            choices.Add(new String[] { "hello", "how are you", "open primary applications" });

            Grammar grammar = new Grammar(new GrammarBuilder(choices));

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(grammar);
                rec.SpeechRecognized += rec_SpeachRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return;}

            speech.SelectVoiceByHints(VoiceGender.Male);  
            InitializeComponent();
        }

        public void Say(String h)
        {
            speech.Speak(h);
        }

        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;

            if(r == "hello")
            {
                Say("hi");
            }

            if(r == "how are you")
            {
                Say("i am fine uh, thanks uh");
            }

            if (r == "open primary applications")
            {
                Say("okay");
                Process.Start(@"C:\Users\csc\Desktop\GoPassCSCBO.exe");
                Process.Start("https://outlook.office.com/owa/?path=/mail/inbox");
            }
        }
                
    }
    
}
