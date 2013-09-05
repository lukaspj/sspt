//-----------------------------------------------------------------------------
// Game mainfile. Defines what happens when the root main.cs has set everything
// up properly.

// Module dependencies.
include(levels);
include(cameras);
include(assets);
/*
include(stateMachine);
include(bottomPrint);
include(navigation);*/

// Scripts that make up this module.
exec("./playGui.gui");

//-----------------------------------------------------------------------------
// Called when all datablocks have been transmitted.
function GameConnection::onEnterGame(%client) {
   // Select camera.
   if($flyCamera) {
      %c = FlyCamera.init(%client, GameGroup);
      %c.setTransform("0 0 10 0 0 1 0");
      FlyCamera.controls(true);
      setFOV(50);
      %client.camera = %c;
   } else {
      %c = SideCamera.init(%client, GameGroup, $MissionCleanupGroup, y);
      %c.setTransform(Level.sectionSize*.75 SPC 0 SPC Level.sectionHeight / 2 SPC
         "0.255082 0.205918 -0.944739 1.41418");
      SideCamera.controls(true);
      setFOV(50);
      SideCamera.mountToPlayer(ThePlayer);
      %client.camera = %c;
      %client.setFirstPerson(false);
   }

   // Activate HUD which allows us to see the game. This should technically be
   // a commandToClient, but since the client and server are on the same
   // machine...
   Canvas.setContent(PlayGui);
   activateDirectInput();

   // Activate the toon-edge PostFX.
   OutlineFx.enable();
   $missionRunning = true;
}

function bringUpOptions(%val)
{
   if (%val)
      Canvas.pushDialog(OptionsDlg);
}

//-----------------------------------------------------------------------------
// Called when the engine has been initialised.
function onStart() {
   new SimGroup(GameGroup);
   $MissionCleanupGroup = GameGroup;
   
   // Temporary fix for ParticleEmitters
   new SimGroup(ClientMissionCleanup);

   // Allow us to exit the game...
   GlobalActionMap.bind(keyboard, "escape", "quit");
   GlobalActionMap.bind(keyboard, "alt f4", "quit");
   
   // Allow us to edit the settings
   GlobalActionMap.bind(keyboard, "ctrl o", bringUpOptions);
   
   // Call onStart for child modules
   LevelModule.onStart();
   LocalClientConnection.setControlObject(ThePlayer);
   //Level.onStart();
}

//-----------------------------------------------------------------------------
// Called when the engine is shutting down.
function onEnd() {
	// Call onEnd for child Modules
	LevelModule.onEnd();

   // Delete the objects we created.
   GameGroup.delete();
   
   // Temporary fix for ParticleEmitters
   ClientMissionCleanup.delete();
}
