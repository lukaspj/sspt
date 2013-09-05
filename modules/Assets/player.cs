exec("./shapes/soldier.cs");

//-----------------------------------------------------------------------------
// Create the player material.
singleton Material(PlayerMaterial) {
   diffuseColor[0] = "0 1 0";
   mapTo = "basePlayer";
};

datablock DebrisData(PlayerDebris) {
   numBounces = 1;
   velocity = 3;
   velocityVariance = 1;
};

//-----------------------------------------------------------------------------
// Basic protagonist datablock.
datablock PlayerData(PlayerBase) {
   class = Player;
   superclass = Character;
   shapeFile = "./shapes/soldier.dae";
   maxDamage = 100;
   destroyedLevel = 100;
   debrisShapeName = "./shapes/playerDebris.dae";
   debris = PlayerDebris;
   maxForwardSpeed = 5;
   maxSideSpeed = 5;
   maxBackwardSpeed = 5;
   firstPerson = false;
};