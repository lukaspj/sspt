//---------------------------------------------------------------------------------------------
// Editor Checking
// Needs to be outside of the tools directory so these work in non-tools builds
//---------------------------------------------------------------------------------------------

function EditorIsActive()
{
   return ( isObject(EditorGui) && Canvas.getContent() == EditorGui.getId() );
}

function GuiEditorIsActive()
{
   return ( isObject(GuiEditorGui) && Canvas.getContent() == GuiEditorGui.getId() );
}

//---------------------------------------------------------------------------------------------
// MoveMap for the WorldEditor
// Needs to be outside of the tools directory so these work in non-tools builds
//---------------------------------------------------------------------------------------------

if ( isObject( moveMap ) )
   moveMap.delete();
new ActionMap(moveMap);


//------------------------------------------------------------------------------
// Non-mapspecific
//  These functions should be moved out of here.
//------------------------------------------------------------------------------
function escapeFromGame()
{
   if ( $Server::ServerType $= "SinglePlayer" )
      MessageBoxYesNo( "Exit", "Exit from this Mission?", "disconnect();", "");
   else
      MessageBoxYesNo( "Disconnect", "Disconnect from the server?", "disconnect();", "");
}

function showPlayerList(%val)
{
   if (%val)
      PlayerListGui.toggle();
}

function hideHUDs(%val)
{
   if (%val)
      HudlessPlayGui.toggle();
}

function doScreenShotHudless(%val)
{
   if(%val)
   {
      canvas.setContent(HudlessPlayGui);
      //doScreenshot(%val);
      schedule(10, 0, "doScreenShot", %val);
   }
   else
      canvas.setContent(PlayGui);
}

//------------------------------------------------------------------------------
// Non-remapable binds
//------------------------------------------------------------------------------


moveMap.bindCmd(keyboard, "escape", "", "handleEscape();");

moveMap.bind( keyboard, F2, showPlayerList );

moveMap.bind(keyboard, "ctrl h", hideHUDs);

moveMap.bind(keyboard, "alt p", doScreenShotHudless);

moveMap.bind( keyboard, a, moveleft );
moveMap.bind( keyboard, d, moveright );
moveMap.bind( keyboard, left, moveleft );
moveMap.bind( keyboard, right, moveright );

moveMap.bind( keyboard, w, moveforward );
moveMap.bind( keyboard, s, movebackward );
moveMap.bind( keyboard, up, moveforward );
moveMap.bind( keyboard, down, movebackward );

moveMap.bind( keyboard, e, moveup );
moveMap.bind( keyboard, c, movedown );

moveMap.bind( keyboard, space, jump );
moveMap.bind( mouse, xaxis, yaw );
moveMap.bind( mouse, yaxis, pitch );

moveMap.bind( gamepad, thumbrx, "D", "-0.23 0.23", gamepadYaw );
moveMap.bind( gamepad, thumbry, "D", "-0.23 0.23", gamepadPitch );
moveMap.bind( gamepad, thumblx, "D", "-0.23 0.23", gamePadMoveX );
moveMap.bind( gamepad, thumbly, "D", "-0.23 0.23", gamePadMoveY );

moveMap.bind( gamepad, btn_a, jump );
moveMap.bindCmd( gamepad, btn_back, "disconnect();", "" );

moveMap.bindCmd(gamepad, dpadl, "toggleLightColorViz();", "");
moveMap.bindCmd(gamepad, dpadu, "toggleDepthViz();", "");
moveMap.bindCmd(gamepad, dpadd, "toggleNormalsViz();", "");
moveMap.bindCmd(gamepad, dpadr, "toggleLightSpecularViz();", "");

// ----------------------------------------------------------------------------
// Stance/pose
// ----------------------------------------------------------------------------

moveMap.bind(keyboard, lcontrol, doCrouch);
moveMap.bind(gamepad, btn_b, doCrouch);

moveMap.bind(keyboard, lshift, doSprint);

//------------------------------------------------------------------------------
// Mouse Trigger
//------------------------------------------------------------------------------

moveMap.bind( mouse, button0, mouseFire );
//moveMap.bind( mouse, button1, altTrigger );

moveMap.bind(gamepad, triggerr, gamepadFire);
moveMap.bind(gamepad, triggerl, gamepadAltTrigger);

//------------------------------------------------------------------------------
// Zoom and FOV functions
//------------------------------------------------------------------------------

moveMap.bind(keyboard, f, setZoomFOV); // f for field of view
moveMap.bind(keyboard, z, toggleZoom); // z for zoom
moveMap.bind( mouse, button1, mouseButtonZoom );

//------------------------------------------------------------------------------
// Camera & View functions
//------------------------------------------------------------------------------

moveMap.bind( keyboard, v, toggleFreeLook ); // v for vanity
moveMap.bind( keyboard, tab, toggleFirstPerson );
moveMap.bind( keyboard, "alt c", toggleCamera );

moveMap.bind( gamepad, btn_start, toggleCamera );
moveMap.bind( gamepad, btn_x, toggleFirstPerson );

//------------------------------------------------------------------------------
// Helper Functions
//------------------------------------------------------------------------------

moveMap.bind(keyboard, "F8", dropCameraAtPlayer);
moveMap.bind(keyboard, "F7", dropPlayerAtCamera);