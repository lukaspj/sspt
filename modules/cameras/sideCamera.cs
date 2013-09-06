new ScriptObject(SideCamera);

function SideCamera::init(%this, %client, %group) {
   // Create a camera for the client.
   %c = new Camera() {
      datablock = Observer;
   };

   // Add to SimGroup if one is given.
   if(isObject(%group)) {
      %group.add(%c);
   }

   // Cameras are not ghosted (sent across the network) by default; we need to
   // do it manually for the client that owns the camera or things will go south
   // quickly.
   %c.scopeToClient(%client);

   // Set the camera of the client to be this camera in such a manner that it
   // doesn't remove control from the player.
   %client.setCameraObject(%c);

   // If there's no input, capture some!
   if(!isObject(%this.map)) {
      %this.map = new ActionMap();
      %this.map.bind( keyboard, w, moveforward );
      %this.map.bind( keyboard, s, movebackward );
      //%this.map.bind(mouse, xaxis, yaw);
      //%this.map.bind(mouse, yaxis, pitch);
   }

   %this.camera = %c;

   return %c;
}

function SideCamera::controls(%this, %controls) {
   %this.map.call(%controls? "push" : "pop");
}

function SideCamera::mountToPlayer(%this, %player) {
   return %this.camera.setOrbitObject(%player, "0 0"SPC mDegToRad(270), 1, 8, 5, true);
}
