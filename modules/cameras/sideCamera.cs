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

   // And let the client control the camera.
   %client.setControlObject(%c);

   // If there's no input, capture some!
   if(!isObject(%this.map)) {
      %this.map = new ActionMap();
      %this.map.bindCmd(mouse, button0, "$mvForwardAction = 1;", "$mvForwardAction = 0;");
      %this.map.bindCmd(mouse, button1, "$mvBackwardAction = 1;", "$mvBackwardAction = 0;");
      %this.map.bind(mouse, xaxis, yaw);
      %this.map.bind(mouse, yaxis, pitch);
   }

   return %c;
}

function SideCamera::controls(%this, %controls) {
   //%this.map.call(%controls? "push" : "pop");
}

function SideCamera::mountToPlayer(%this, %player) {
   return %this.setOrbitObject(%player, "0 0 0.75", 10, 10, 10, true);
}