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

namespace DashConsole
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speech = new SpeechSynthesizer();
        public Form1()
        {
            speech.SelectVoiceByHints(VoiceGender.Male);
            speech.Speak("Hello");    
            InitializeComponent();
        }
        
    }
    
}
