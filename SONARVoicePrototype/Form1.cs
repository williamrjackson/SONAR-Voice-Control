using System;
using System.Speech.Recognition;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Sanford.Multimedia.Midi;
using Sanford.Multimedia.Midi.UI;

namespace SONARVoicePrototype
{
    public partial class Form1 : Form
    {
        bool bListening;
        bool bLearning;
        private OutputDevice outDevice;
        private InputDevice inDevice;
        int outDeviceID;
        int inDeviceID;

        int listenModeCC = Properties.Settings.Default.ListenCC;

        public delegate void DoneListening_Delegate(string heardString);

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            //Set the out and in device to last saved.
            //If it's out of range (removed?), use 0.
            if (OutputDevice.DeviceCount <= Properties.Settings.Default.OutPort)
            {
                outDeviceID = 0;
            }
            else
            {
                outDeviceID = Properties.Settings.Default.OutPort;
            }

            if (InputDevice.DeviceCount <= Properties.Settings.Default.InPort)
            {
                inDeviceID = 0;
            }
            else
            {
                inDeviceID = Properties.Settings.Default.InPort;
            }

            //Set up last saved values
            SetOutput();
            SetInput();

            //Last saved custom function terms:
            textBox1.Text = Properties.Settings.Default.F1;
            textBox2.Text = Properties.Settings.Default.F2;
            textBox3.Text = Properties.Settings.Default.F3;
            textBox4.Text = Properties.Settings.Default.F4;
            textBox5.Text = Properties.Settings.Default.F5;
            textBox6.Text = Properties.Settings.Default.F6;
            textBox7.Text = Properties.Settings.Default.F7;
            textBox8.Text = Properties.Settings.Default.F8;

            //Last saved options
            muteMasterCheckBox.Checked = Properties.Settings.Default.MuteListen;
            learnButton.Text = "Learn Trigger CC (Currently " + listenModeCC + ")";

            //Add device names to input/output port dropdowns
            for (int i = 0; i < InputDevice.DeviceCount; i++)
            {
                inputComboBox1.Items.Add(InputDevice.GetDeviceCapabilities(i).name.ToString());
            }
            for (int i = 0; i < OutputDevice.DeviceCount; i++)
            {
                outputComboBox1.Items.Add(OutputDevice.GetDeviceCapabilities(i).name.ToString());
            }

            base.OnLoad(e);

        }

        private void SetInput()
        {
            //Set the input device and start listening for trigger CC data
            if (inDevice != null)
            {
                inDevice.Dispose();
            }

            try
            {
                inDevice = new InputDevice(inDeviceID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Close();
            }
            inputComboBox1.Text = InputDevice.GetDeviceCapabilities(inDeviceID).name.ToString();
            
            //Listen for Trigger CC - if you hear it, enter Voice Listening Mode.
            //If you're in learn mode, set the event as the trigger CC.
            inDevice.StartRecording();
            inDevice.ChannelMessageReceived += delegate(object sender, ChannelMessageEventArgs er)
            {
                if ((er.Message.Data1 == listenModeCC) && (er.Message.Data2 == 127) && (bListening == false))
                {
                    bListening = true;
                    tabControl1.SelectedIndex = 0;
                    listenButton.Enabled = false;
                    listenButton.Text = "Say Command Now";
                    listenButton.Invalidate();
                    listenButton.Update(); 
                    Listen();
                }
                if (bLearning == true)
                {
                    listenModeCC = er.Message.Data1;
                    learnButton.Text = "Learn Trigger CC (Currently " + listenModeCC + ")";
                    bLearning = false;
                }

            };
        }

        private void SetOutput()
        {
            //Assign output device
            //Send Mackie Control handshake (one way - any incoming sysex is ignored)
            if (outDevice != null)
            {
                outDevice.Dispose();
            }

            try
            {
                outDevice = new OutputDevice(outDeviceID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Close();
            }

            outputComboBox1.Text = OutputDevice.GetDeviceCapabilities(outDeviceID).name.ToString();

            //Mackie Control Handshake
            byte[] mackieHandshakeData = 
            {
                (byte)0xF0, 
                (byte)0x00, 
                (byte)0x00, 
                (byte)0x66, 
                (byte)0x14, 
                (byte)0x1B, 
                (byte)0x58, 
                (byte)0x59, 
                (byte)0x5A, 
                (byte)0x00, 
                (byte)0x00, 
                (byte)0x00, 
                (byte)0x00, 
                (byte)0xF7,
            };
            SysExMessage mackieHandshake = new SysExMessage(mackieHandshakeData);
            outDevice.Send(mackieHandshake);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //Remember Settings for next time...
            Properties.Settings.Default.OutPort = outDeviceID;
            Properties.Settings.Default.InPort = inDeviceID;
            Properties.Settings.Default.F1 = textBox1.Text;
            Properties.Settings.Default.F2 = textBox2.Text;
            Properties.Settings.Default.F3 = textBox3.Text;
            Properties.Settings.Default.F4 = textBox4.Text;
            Properties.Settings.Default.F5 = textBox5.Text;
            Properties.Settings.Default.F6 = textBox6.Text;
            Properties.Settings.Default.F7 = textBox7.Text;
            Properties.Settings.Default.F8 = textBox8.Text;
            Properties.Settings.Default.MuteListen = muteMasterCheckBox.Checked;
            Properties.Settings.Default.ListenCC = listenModeCC;
            
            //Save settings
            Properties.Settings.Default.Save();

            base.OnClosing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            //Release MIDI Devices
            if(outDevice != null)
            {
                outDevice.Dispose();
            }
            if (inDevice != null)
            {
                inDevice.Dispose();
            }
            base.OnClosed(e);
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            //Enter Voice Listening Mode
            listenButton.Enabled = false;
            listenButton.Text = "Say Command Now";
            listenButton.Invalidate();
            listenButton.Update(); 
            Listen();
        }

        private void Listen()
        {
            //Fill a unique grammar object with SONAR-specific terms.
            //Do this every time we listen so the user can add and use custom 
            //function commands immediately.
            bListening = true;
            String sResult = "";
            Grammar sonarGrammar;
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            List<string> choiceList = new List<string>();
            choiceList.Add("arm");
            choiceList.Add("solo");
            choiceList.Add("mute");
            choiceList.Add("select");
            choiceList.Add("play");
            choiceList.Add("pause");
            choiceList.Add("stop");
            choiceList.Add("record");
            choiceList.Add("undo");
            choiceList.Add("redo");
            choiceList.Add("loop");
            choiceList.Add("insert midi");
            choiceList.Add("insert audio");
            choiceList.Add("go to");
            choiceList.Add("next marker");
            choiceList.Add("previous marker");
            choiceList.Add("okay");
            choiceList.Add("cancel");
            choiceList.Add(textBox1.Text);
            choiceList.Add(textBox2.Text);
            choiceList.Add(textBox3.Text);
            choiceList.Add(textBox4.Text);
            choiceList.Add(textBox5.Text);
            choiceList.Add(textBox6.Text);
            choiceList.Add(textBox7.Text);
            choiceList.Add(textBox8.Text);

            for (int i = 1; i < 201; i++)
            {
                string newterm = "measure " + i.ToString();
                choiceList.Add(newterm);
            }
            for (int i = 1; i < 65; i++)
            {
                string newterm = "track " + i.ToString();
                choiceList.Add(newterm);
            }

            string[] choiceArray = choiceList.ToArray();
   
            Choices sonar = new Choices(choiceArray);

            GrammarBuilder sonarGrammarBuilder = new GrammarBuilder();
            //Only allow 2 terms per recognition - this allows support for numbers, but shortens listening time and minimizes errors.
            sonarGrammarBuilder.Append(new GrammarBuilder(sonar), 1, 2);
            sonarGrammar = new Grammar(sonarGrammarBuilder);
            sonarGrammar.Name = "sonarGrammar";            
            recognizer.LoadGrammar(sonarGrammar);

            if (muteMasterCheckBox.Checked)
            {
                //Mute Main Out in preparation of Listening Mode.
                //This is done by setting the main/master fader to 
                //its minimum value.
                ChannelMessage muteMasterMessage = new ChannelMessage(ChannelCommand.PitchWheel, 8, 0, 0);
                outDevice.Send(muteMasterMessage);
            }

            try
            {
                //Actually listen.
                recognizer.SetInputToDefaultAudioDevice();
                recognizer.InitialSilenceTimeout = TimeSpan.FromSeconds(5);
                recognizer.EndSilenceTimeout = TimeSpan.FromSeconds(0);
                recognizer.EndSilenceTimeoutAmbiguous = TimeSpan.FromSeconds(0);
                RecognitionResult result = recognizer.Recognize();
                sResult = result.Text;
                DoneListening_Delegate d = new DoneListening_Delegate(DoneListening);
                IAsyncResult R = d.BeginInvoke(sResult, null, null);

                //Tel the user what we heard and disable the button til we're done firing commands
                statusLabel.Text = "Most Recent Command: " + sResult.ToUpper();
                listenButton.Text = "Working...";
                listenButton.Enabled = false;
            }
            catch
            {
                //No acceptable command was heard. Set command status
                //to "Failed" and exit listening mode.
                statusLabel.Text = "Most Recent Command: **FAILED**";
                SetButtonText("Click to Enable Listening");
                bListening = false;
            }
            finally
            {
                //Regardless of success/failure, unload grammar (to support custom commands)
                //and make sure the main out is un-muted.
                recognizer.UnloadAllGrammars();
                if (muteMasterCheckBox.Checked)
                {
                    ChannelMessage unMuteMasterMessage = new ChannelMessage(ChannelCommand.PitchWheel, 8, 85, 101);
                    outDevice.Send(unMuteMasterMessage);
                }
            }
        }

        private void DoneListening(string heardString)
        {
            //Listening Mode came up with something it thinks it can use. Check for words we're supposed to do
            //something about, and construct MIDI messages accordingly to the Mackie Control MIDI Spec.
            int iterations = 1;
            ChannelMessage moveWAIdown = new ChannelMessage(ChannelCommand.NoteOn, 0, 49, 127);
            ChannelMessage bankWAIup = new ChannelMessage(ChannelCommand.NoteOn, 0, 46, 127);
            int data = 0;
            int data2 = 127;
            ChannelCommand command = ChannelCommand.NoteOn;

            if (heardString.Contains("arm"))
            {
                data = 0;
            }
            if (heardString.Contains("solo"))
            {
                data = 8;
            }
            if (heardString.Contains("mute"))
            {
                data = 16;
            }
            if (heardString.Contains("select"))
            {
                data = 24;
            }
            if (heardString.Contains("track"))
            {
                int nTrack = (Int32.Parse(Regex.Replace(heardString, "[^0-9]", "")));
                if (nTrack < 9)
                {
                    data = ((data + nTrack) - 1);
                }
                else
                {
                    //For tracks higher than 8, bank WAI strip by one to reach the required track.
                    //Then use strip 8 in the message.
                    data = data + 7;
                    for (int y = 0; y < 9; y++)
                    {
                        outDevice.Send(bankWAIup);
                        Thread.Sleep(50);
                    }
                    for (int x = 8; x < nTrack; x++)
                    {
                        //For some reason this is intermittently off by one. 
                        //Tried increasing delay between messages... no dice. May be slightly improved - hard to tell.
                        outDevice.Send(moveWAIdown);
                        Thread.Sleep(100);
                    }
                }
            }
            if (heardString.ToUpper() == textBox1.Text.ToUpper())
            {
                data = 54;
            }
            if (heardString.ToUpper() == textBox2.Text.ToUpper())
            {
                data = 55;
            }
            if (heardString.ToUpper() == textBox3.Text.ToUpper())
            {
                data = 56;
            }
            if (heardString.ToUpper() == textBox4.Text.ToUpper())
            {
                data = 57;
            }
            if (heardString.ToUpper() == textBox5.Text.ToUpper())
            {
                data = 58;
            }
            if (heardString.ToUpper() == textBox6.Text.ToUpper())
            {
                data = 59;
            }
            if (heardString.ToUpper() == textBox7.Text.ToUpper())
            {
                data = 60;
            }
            if (heardString.ToUpper() == textBox8.Text.ToUpper())
            {
                data = 61;
            }
            if ((heardString.Contains("play")) || (heardString.Contains("pause")))
            {
                data = 94;
            }
            if (heardString.Contains("stop"))
            {
                data = 93;
            }
            if (heardString.Contains("record"))
            {
                data = 95;
            }
            if (heardString.Contains("undo"))
            {
                data = 82;
            }
            if (heardString.Contains("redo"))
            {
                data = 83;
            }
            if (heardString.Contains("loop"))
            {
                data = 89;
            }
            if (heardString.Contains("insert audio"))
            {
                data = 62;
            }
            if (heardString.Contains("insert midi"))
            {
                data = 63;
            }
            if (heardString.Contains("save file"))
            {
                data = 79;
            }
            if (heardString.Contains("next marker"))
            {
                data = 92;
            }
            if (heardString.Contains("previous marker"))
            {
                data = 91;
            }
            if (heardString.Contains("okay"))
            {
                data = 66;
            }
            if (heardString.Contains("cancel"))
            {
                data = 67;
            }
            if (heardString.Contains("go to measure"))
            {
                ChannelMessage Stop = new ChannelMessage(ChannelCommand.NoteOn, 0, 93, 127);
                ChannelMessage RTZ = new ChannelMessage(ChannelCommand.Controller, 0, 60, 65);

                outDevice.Send(Stop);
                for (int incr = 0; incr < 200; incr++)
                {
                    outDevice.Send(RTZ);
                    Thread.Sleep(20);
                }
                command = ChannelCommand.Controller;
                data = 60;
                data2 = 1;

                if (heardString.Contains("measure"))
                {
                    iterations = ((Int32.Parse(Regex.Replace(heardString, "[^0-9]", ""))) - 1);
                }
            }

            ChannelMessage heardMessage = new ChannelMessage(command, 0, data, data2);
            for (int i = 1; i <= iterations; i++)
            {
                outDevice.Send(heardMessage);
                Thread.Sleep(50);
            }
            if (heardString.Contains("track"))
            {
                //If needed, bank the WAI up by 8 8 times.
                //(this tool only works for tracks 1-64.)
                for (int y = 0; y < 9; y++)
                {
                    outDevice.Send(bankWAIup);
                    Thread.Sleep(50);
                }
            }

            //Exit voice listening mode
            SetButtonText("Click to Enable Listening");
            bListening = false;

            ////All notes off... Generally not needed, based on my testing
            //for (int i = 0; i < 128; i++)
            //{
            //    ChannelMessage noteOff = new ChannelMessage(ChannelCommand.NoteOff, 0, i, 127);
            //    outDevice.Send(noteOff);
            //}

        }
 
        delegate void SetTextCallback(string text);
        private void SetButtonText(string text)
        {
            //Delegate to set button properties from worker threads.
            if (this.listenButton.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetButtonText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.listenButton.Text = text;
                this.listenButton.Enabled = true;
            }
        }

        private void inputComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set input port to what the user chose
            inDeviceID = inputComboBox1.SelectedIndex;
            SetInput();
        }

        private void outputComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set output port to what the user chose
            outDeviceID = outputComboBox1.SelectedIndex;
            SetOutput();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //Always on top behavior
            this.TopMost = onTopCheckBox.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bLearning == false)
            {
                learnButton.Text = "Learning...";
                bLearning = true;
            }
            //Allow the user to exit CC learn mode by clicking again
            else
            {
                learnButton.Text = "Learn Trigger CC (Currently " + listenModeCC + ")";
                bLearning = false;
            }
        }
    }
}