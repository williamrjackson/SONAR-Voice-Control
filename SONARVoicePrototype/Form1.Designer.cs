using Sanford.Multimedia.Midi;

namespace SONARVoicePrototype
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listenButton = new System.Windows.Forms.Button();
            this.openMidiFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sequence1 = new Sanford.Multimedia.Midi.Sequence();
            this.sequencer1 = new Sanford.Multimedia.Midi.Sequencer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusLabel = new System.Windows.Forms.Label();
            this.muteMasterCheckBox = new System.Windows.Forms.CheckBox();
            this.inputComboBox1 = new System.Windows.Forms.ComboBox();
            this.outputComboBox1 = new System.Windows.Forms.ComboBox();
            this.inLabel = new System.Windows.Forms.Label();
            this.outLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.F8label = new System.Windows.Forms.Label();
            this.F7label = new System.Windows.Forms.Label();
            this.F6label = new System.Windows.Forms.Label();
            this.F5label = new System.Windows.Forms.Label();
            this.F4label = new System.Windows.Forms.Label();
            this.F3label = new System.Windows.Forms.Label();
            this.F2label = new System.Windows.Forms.Label();
            this.F1label = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.onTopCheckBox = new System.Windows.Forms.CheckBox();
            this.learnButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listenButton
            // 
            this.listenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listenButton.Location = new System.Drawing.Point(0, 1);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(486, 107);
            this.listenButton.TabIndex = 1;
            this.listenButton.Text = "Click to Enable Listening";
            this.listenButton.UseVisualStyleBackColor = true;
            this.listenButton.Click += new System.EventHandler(this.listenButton_Click);
            // 
            // openMidiFileDialog
            // 
            this.openMidiFileDialog.DefaultExt = "mid";
            this.openMidiFileDialog.Filter = "MIDI files|*.mid|All files|*.*";
            this.openMidiFileDialog.Title = "Open MIDI file";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 202);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(519, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sequence1
            // 
            this.sequence1.Format = 1;
            // 
            // sequencer1
            // 
            this.sequencer1.Position = 0;
            this.sequencer1.Sequence = this.sequence1;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(9, 206);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 13);
            this.statusLabel.TabIndex = 7;
            // 
            // muteMasterCheckBox
            // 
            this.muteMasterCheckBox.AutoSize = true;
            this.muteMasterCheckBox.Location = new System.Drawing.Point(25, 181);
            this.muteMasterCheckBox.Name = "muteMasterCheckBox";
            this.muteMasterCheckBox.Size = new System.Drawing.Size(192, 17);
            this.muteMasterCheckBox.TabIndex = 13;
            this.muteMasterCheckBox.Text = "Mute Master Bus in Listening Mode";
            this.muteMasterCheckBox.UseVisualStyleBackColor = true;
            // 
            // inputComboBox1
            // 
            this.inputComboBox1.AccessibleName = "MIDI Input Device";
            this.inputComboBox1.FormattingEnabled = true;
            this.inputComboBox1.Location = new System.Drawing.Point(92, 14);
            this.inputComboBox1.Name = "inputComboBox1";
            this.inputComboBox1.Size = new System.Drawing.Size(171, 21);
            this.inputComboBox1.TabIndex = 9;
            this.inputComboBox1.SelectedIndexChanged += new System.EventHandler(this.inputComboBox1_SelectedIndexChanged);
            // 
            // outputComboBox1
            // 
            this.outputComboBox1.AccessibleName = "MIDI Output Device";
            this.outputComboBox1.FormattingEnabled = true;
            this.outputComboBox1.Location = new System.Drawing.Point(323, 14);
            this.outputComboBox1.Name = "outputComboBox1";
            this.outputComboBox1.Size = new System.Drawing.Size(170, 21);
            this.outputComboBox1.TabIndex = 10;
            this.outputComboBox1.SelectedIndexChanged += new System.EventHandler(this.outputComboBox1_SelectedIndexChanged);
            // 
            // inLabel
            // 
            this.inLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.inLabel.AutoSize = true;
            this.inLabel.Location = new System.Drawing.Point(22, 18);
            this.inLabel.Name = "inLabel";
            this.inLabel.Size = new System.Drawing.Size(64, 13);
            this.inLabel.TabIndex = 11;
            this.inLabel.Text = "Pedal Input:";
            // 
            // outLabel
            // 
            this.outLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.outLabel.AutoSize = true;
            this.outLabel.Location = new System.Drawing.Point(275, 18);
            this.outLabel.Name = "outLabel";
            this.outLabel.Size = new System.Drawing.Size(42, 13);
            this.outLabel.TabIndex = 12;
            this.outLabel.Text = "Output:";
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "";
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(495, 134);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listenButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(487, 108);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listen Trigger";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.F8label);
            this.tabPage2.Controls.Add(this.F7label);
            this.tabPage2.Controls.Add(this.F6label);
            this.tabPage2.Controls.Add(this.F5label);
            this.tabPage2.Controls.Add(this.F4label);
            this.tabPage2.Controls.Add(this.F3label);
            this.tabPage2.Controls.Add(this.F2label);
            this.tabPage2.Controls.Add(this.F1label);
            this.tabPage2.Controls.Add(this.textBox8);
            this.tabPage2.Controls.Add(this.textBox7);
            this.tabPage2.Controls.Add(this.textBox6);
            this.tabPage2.Controls.Add(this.textBox5);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(487, 108);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Custom Commands";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // F8label
            // 
            this.F8label.AccessibleName = "F8";
            this.F8label.AutoSize = true;
            this.F8label.Location = new System.Drawing.Point(267, 87);
            this.F8label.Name = "F8label";
            this.F8label.Size = new System.Drawing.Size(22, 13);
            this.F8label.TabIndex = 15;
            this.F8label.Text = "F8:";
            // 
            // F7label
            // 
            this.F7label.AccessibleName = "F7";
            this.F7label.AutoSize = true;
            this.F7label.Location = new System.Drawing.Point(267, 61);
            this.F7label.Name = "F7label";
            this.F7label.Size = new System.Drawing.Size(22, 13);
            this.F7label.TabIndex = 14;
            this.F7label.Text = "F7:";
            // 
            // F6label
            // 
            this.F6label.AccessibleName = "F6";
            this.F6label.AutoSize = true;
            this.F6label.Location = new System.Drawing.Point(267, 35);
            this.F6label.Name = "F6label";
            this.F6label.Size = new System.Drawing.Size(22, 13);
            this.F6label.TabIndex = 13;
            this.F6label.Text = "F6:";
            // 
            // F5label
            // 
            this.F5label.AccessibleName = "F5";
            this.F5label.AutoSize = true;
            this.F5label.Location = new System.Drawing.Point(267, 9);
            this.F5label.Name = "F5label";
            this.F5label.Size = new System.Drawing.Size(22, 13);
            this.F5label.TabIndex = 12;
            this.F5label.Text = "F5:";
            // 
            // F4label
            // 
            this.F4label.AccessibleName = "F4";
            this.F4label.AutoSize = true;
            this.F4label.Location = new System.Drawing.Point(61, 87);
            this.F4label.Name = "F4label";
            this.F4label.Size = new System.Drawing.Size(22, 13);
            this.F4label.TabIndex = 11;
            this.F4label.Text = "F4:";
            // 
            // F3label
            // 
            this.F3label.AccessibleName = "F3";
            this.F3label.AutoSize = true;
            this.F3label.Location = new System.Drawing.Point(61, 61);
            this.F3label.Name = "F3label";
            this.F3label.Size = new System.Drawing.Size(22, 13);
            this.F3label.TabIndex = 10;
            this.F3label.Text = "F3:";
            // 
            // F2label
            // 
            this.F2label.AccessibleName = "F2";
            this.F2label.AutoSize = true;
            this.F2label.Location = new System.Drawing.Point(61, 35);
            this.F2label.Name = "F2label";
            this.F2label.Size = new System.Drawing.Size(22, 13);
            this.F2label.TabIndex = 9;
            this.F2label.Text = "F2:";
            // 
            // F1label
            // 
            this.F1label.AccessibleName = "F1";
            this.F1label.AutoSize = true;
            this.F1label.Location = new System.Drawing.Point(61, 9);
            this.F1label.Name = "F1label";
            this.F1label.Size = new System.Drawing.Size(22, 13);
            this.F1label.TabIndex = 8;
            this.F1label.Text = "F1:";
            // 
            // textBox8
            // 
            this.textBox8.AccessibleName = "F8";
            this.textBox8.Location = new System.Drawing.Point(308, 84);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 7;
            this.textBox8.Text = "Function 8";
            // 
            // textBox7
            // 
            this.textBox7.AccessibleName = "F7";
            this.textBox7.Location = new System.Drawing.Point(308, 58);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 6;
            this.textBox7.Text = "Function 7";
            // 
            // textBox6
            // 
            this.textBox6.AccessibleName = "F6";
            this.textBox6.Location = new System.Drawing.Point(308, 32);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 5;
            this.textBox6.Text = "Function 6";
            // 
            // textBox5
            // 
            this.textBox5.AccessibleName = "F5";
            this.textBox5.Location = new System.Drawing.Point(308, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.Text = "Function 5";
            // 
            // textBox4
            // 
            this.textBox4.AccessibleName = "F4";
            this.textBox4.Location = new System.Drawing.Point(102, 84);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "Function 4";
            // 
            // textBox3
            // 
            this.textBox3.AccessibleName = "F3";
            this.textBox3.Location = new System.Drawing.Point(102, 58);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Function 3";
            // 
            // textBox2
            // 
            this.textBox2.AccessibleName = "F2";
            this.textBox2.Location = new System.Drawing.Point(102, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Function 2";
            // 
            // textBox1
            // 
            this.textBox1.AccessibleName = "F1";
            this.textBox1.Location = new System.Drawing.Point(102, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Function 1";
            // 
            // onTopCheckBox
            // 
            this.onTopCheckBox.AutoSize = true;
            this.onTopCheckBox.Location = new System.Drawing.Point(223, 181);
            this.onTopCheckBox.Name = "onTopCheckBox";
            this.onTopCheckBox.Size = new System.Drawing.Size(98, 17);
            this.onTopCheckBox.TabIndex = 14;
            this.onTopCheckBox.Text = "Always On Top";
            this.onTopCheckBox.UseVisualStyleBackColor = true;
            this.onTopCheckBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // learnButton
            // 
            this.learnButton.Location = new System.Drawing.Point(327, 175);
            this.learnButton.Name = "learnButton";
            this.learnButton.Size = new System.Drawing.Size(166, 23);
            this.learnButton.TabIndex = 15;
            this.learnButton.Text = "Learn Trigger CC (Currently 64)";
            this.learnButton.UseVisualStyleBackColor = true;
            this.learnButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 224);
            this.Controls.Add(this.learnButton);
            this.Controls.Add(this.onTopCheckBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.outLabel);
            this.Controls.Add(this.inLabel);
            this.Controls.Add(this.outputComboBox1);
            this.Controls.Add(this.inputComboBox1);
            this.Controls.Add(this.muteMasterCheckBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SONAR Voice Prototype";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button listenButton;
        private System.Windows.Forms.OpenFileDialog openMidiFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Sequence sequence1;
        private Sequencer sequencer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox muteMasterCheckBox;
        private System.Windows.Forms.ComboBox inputComboBox1;
        private System.Windows.Forms.ComboBox outputComboBox1;
        private System.Windows.Forms.Label inLabel;
        private System.Windows.Forms.Label outLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label F8label;
        private System.Windows.Forms.Label F7label;
        private System.Windows.Forms.Label F6label;
        private System.Windows.Forms.Label F5label;
        private System.Windows.Forms.Label F4label;
        private System.Windows.Forms.Label F3label;
        private System.Windows.Forms.Label F2label;
        private System.Windows.Forms.Label F1label;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox onTopCheckBox;
        private System.Windows.Forms.Button learnButton;
    }
}

