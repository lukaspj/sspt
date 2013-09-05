//-----------------------------------------------------------------------------
// Create a datablock for the observer camera.
datablock CameraData(Observer) {};

function pitch(%amount) { $mvPitch += %amount * 0.01; }
function yaw(%amount) { $mvYaw += %amount * 0.01; }

exec("./flyCamera.cs");
exec("./sideCamera.cs");