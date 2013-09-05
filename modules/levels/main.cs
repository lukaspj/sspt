new ScriptObject(LevelModule) { };

//-----------------------------------------------------------------------------
// Called when the engine has been initialised.
function LevelModule::onStart() {
   // Create objects!
   new SimGroup(MissionGroup) {
      new LevelInfo(TheLevelInfo) {
         canvasClearColor = "0 0 0";
      };
      new GroundPlane(TheGround) {
         position = "0 0 0";
         material = BlankWhite;
      };
      new Sun(TheSun) {
         azimuth = 230;
         elevation = 45;
         color = "1 1 1";
         ambient = "0.1 0.1 0.1";
         castShadows = true;
      };
      new Player(ThePlayer) {
         dataBlock = PlayerBase;
      };
   };
   $MissionGroup = MissionGroup;
}

//-----------------------------------------------------------------------------
// Called when the engine is shutting down.
function LevelModule::onEnd() {
   // Delete the objects we created.
   MissionGroup.delete();
}