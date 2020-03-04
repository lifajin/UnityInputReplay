# Unity Input Replay
This tool is created for Unity to record Input so it can be played back to help reproduce those specific bugs that might be tricky to see.

This tool is built using the Input system prior to the 2020 edition.

## How to Start
Add the LetsBuild folder from this repository to your Unity Project's Assets.

Once the scripts are added to your project you can now add the _UnityInputReplay_ component into your scene. This script is located under _LetsBuild/Components_. You will only require one GameObject referencing this component.

You will notice several options on the component that will be explained in the next sections. Otherwise check out Options to jump right into it.

Now that we are setup let's start recording.

## How do I capture Input?
Let's assume the UnityInputReplay is attached to my input controller game object. I will need to get a reference to _UnityInputReplay_.

``` c#
  private UnityInputReplay inputReplay;
  
  void Awake()
  {
      inputReplay = GetComponent<UnityInputReplay>();
  }
```

Now that we have the infrastructure in place let's start capturing input!

Traditionally you would just go directly to _Input_.

``` c#
  var didJump = Input.GetButton("Jump");
```

This will now need to capture input from the input replay so it can be played back at a later time. This will change to the following.

``` c#
  var didJump = inputReplay.manager.GetButton("Jump");
```

## How do I playback?
After your changes to input you first need to make a recording!

To do this in Unity make sure you have your __Recording Directory__ set to a well known location. As you play your game it will create a file with the timestamp of when the game session started.

Secondly, make sure __Mode__ is set to __Recording__.

Before we start recording let's make sure our Update Cycle is set properly. This setting is used to make sure the input capture is occuring at the correct interval so there the input playback isn't incorrect. As you can see with the names, it should be set to __FixedUpdate__ when you are capturing input in __FixedUpdate__ and __Update__ if it is in __Update__.

Now play your game for a bit! The recording is dependant on a well known location of your game state. What better location then the start of the session?

Once a recording is complete go to the known file directory and see what timestamp was recorded for the game session.

Next we want to set the __Playback File Path__ to the file location with file name. For example it might look like _C:\UnityGameSession\2020346731518.json_.

Once this is set let's change the __Mode__ to __Playback__.

Now let's start our game!

We should now see our player mirroring the movements of the original player and see exactly how they played the game.

How cool was that?

## Options
- __Mode__: This identifies what functionality we want to run with the replay script. 
     - __Record__: When set to this mode all input will be recorded for a later playback. This works with __Record Directory__.
     - __Playback__: When set this mode will use the __Playback File Path__ and replay player input.
     - __None__: This skips all input management and goes directly to the _Input_ system in Unity.

- __Recording Directory__: This is where the recording file will be generated when __Mode__ is set to __Record__. _Note: the directory must exist for it to be able to be written to._

- __Playback File Path__: This is the fully qualified file location that will be used for playback when __Mode__ is set to __Playback__.

- __Update Cycle__: Identifies when input is being captured in your game. This is used to make sure the frames are synchrnozied for playback.
  - __FixedUpdate__: This should be set when you are capturing Input in _FixedUpdate_.
  - __Update__: This should be set when you are capturing Input in _Update_.
  
- __Objects To Sync__: When the __Update Cycle__ is __Update__ objects may get out of sync due to differences in CPU cycles. To combat this objects added to this collection will compensate for differences in frames to have a much more reliable playback.
