# SONAR Voice Control
Mackie Control Emulation for Voice Recognition DAW Control

**Important information about the SONAR Voice Prototype:**

This is a quick and dirty, hacky prototype of SONAR voice recognition support. It converts spoken commands to MIDI messages according to the Mackie Control Universal MIDI spec.   

The goal is to assess the feasibility and value of directly implementing a voice recognition feature in SONAR X4 to allow users holding a guitar or standing at a mic in a booth to drive SONAR hands-free. Maybe we can call it "Studio Assistant Talkback" or something. There may also be vision impaired accessibility benefits. 

**Short Version:**
1) Read the command list at the bottom of this doc. It provides valuable info regarding  what the prototype can and can't do.
2) Make sure a virtual MIDI port is installed.
3) Insert the Mackie Control plugin in SONAR (Preferences|MIDI|Control Surfaces). Make sure its input is set to the virtual device.
4) Launch the prototype applet.
5) Set the applet's output to the virtual MIDI device.
6) Optionally set the applet's input to the MIDI device you'll use to trigger listening mode.

**Long Version:**   

To use the app, set its output to the Mackie Control surface plugin using a virtual driver (I recommend LoopMIDI for x64 support: http://www.tobias-erichsen.de/software/loopmidi.html).   

Speech recognition happens through your Windows default recording device.   

Pedal Input looks for a MIDI CC value of 127 on any channel of the selected port. When the message is detected, it puts the app in "listen mode." It defaults to CC:64 (sustain), but an alternative can be "learned."   

"Mute Master Bus in Listening Mode" is designed to silence playback so the app can hear your command clearly with minimal noisefloor (it can't hear you say "stop" over your latest black metal masterpiece playing from SONAR).  This is achieved by programatically exercising the main out gain control. It moves it from -inf to 0dB. So if you have your main initially set to something other than 0dB, this function will mess things up (or explode your ears).   

You can optionally run the included SVPToolsMenu.bat as administrator to add a "SONAR Voice..." item to the Utilities menu.   

You can assign any custom verbal command to the Mackie Control function buttons. But avoid assigning words/phrases that are already built-in (such as "Solo," "Track," or "Loop"), as this could potentially cause multiple commands to fire.   

The "Always On Top" toggle will keep the windown up front regardless of focus.   

The .NET 4.0 Client Profile redist is required. This is installed with SONAR, so it shouldn't be a problem. But if needed, it can be found here: http://www.microsoft.com/en-us/download/details.aspx?id=24872   

The app may crash if it can't access your Windows default recording device. This can happen if you're using ASIO4ALL in SONAR or if you're in MME driver mode and don't have "Share Drivers With Other Programs" selected in Preferences|Playback and Recording. If it happens to crash, you'll have to kill the process in the Task Manager, change your SONAR settings, and relaunch. 

The following spoken commands are available:
- Transport
    - "Play"
    - "Pause"
    - "Stop"
    - "Record"
    - "Go to Measure n" (1-199)
    - "Next Marker"
    - "Previous Marker"
- Track
    - "Solo Track n" (1-64)
    - "Mute Track n" (1-64)
    - "Arm Track n" (1-64)
    - "Select Track n" (1-64; Requires "select highlights track" enabled in the surface plugin)
- Utility
    - "Insert Audio" (Adds a new audio track)
    - "Insert MIDI" (Adds a new MIDI track)
    - "Loop" (Enable/Disable Looped Playback)
    - "Undo"
    - "Redo"
    - "Save File"
    - "Okay" (For dialog boxes; SONAR must have focus)
    - "Cancel" (For dialog boxes; SONAR must have focus)
- Customizable Assignable Function Defaults
    - "Function n" (1-8)