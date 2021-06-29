# MobileActionSandbox
# Unity Version 2019.4.21f1

Prototypes of action games either on 3D or 2D on mobile. With this project, little by little, I want to show that we can bring PC like experience, story driving games on mobile.

```All scripts can be found on the following path Assets->RehtseStudio```

**Scene RS_ActionSampleScene**

On this scene your going to have a Prefab of a Playable Character on the hierarchy named _RS_ActionXbot_ that has a _Cinemachine Free Look_ attacked to it called _CM_3rdPersonCamera_.

This Playable Character has a script [RS_PlayerController] that control is movements, speed and animation.  All Inputs are from the new Input System [RehtseStudio_InGameInputActionsMap].

Player can be controlled by using Keyboard, Gamepad (tested with a Xbox, one Controller) and mobile input. 

The camera can be controller by moving your finger on the right side of the screen, this input is being created by a script called _RS_TouchInputManager_ localed inside a UI canvas on the hierarchy: [--RS Mobile Input Asset Holder--] -> [--RS_Managers--] -> RS_MobileInputUI_Canvas, inside the canvas theres a panel that will receive the input from your finger, you can change the size of this panel as you wish. 

The [--RS Managers--] GameObject hold the _RS_InGameInputsManager_, the scripts is a singleton sharing the new Input System.

Theres a special scripts for Cinemachine called _RS_CinemachineInputManager_ this scripts will allowed you to control the camera with Touch Input, Gamepad and Mouse. You need to have a reference to the _RS_MobileInputUI_Canvas_ GameObject that is on the hierarchy and place it on the script using the Inspector windows.

**Goal is to make new scene of different action players to have it be playable on mobile. If its to much then each scene will have a project on there own to have everything nice and clean**

**Comments are welcomed**
