﻿namespace gameOfLife.Data
{
    //This class is used to store the data of the game and is used to implement the game logic.
    internal class Game
    {
        private static bool isRunning;
        private static bool isInteractable;

        private static double zoomModifier;
        private static double zoomModifierMin;
        private static double zoomModifierMax;
        private static double zoomModifierDefault;

        private static Coordinate viewportRoot;

        private static double speedModifier;
        private static double speedModifierMin;
        private static double speedModifierMax;
        private static double speedModifierDefault;

        private static Playfield playField = new Playfield();
        private static Viewport viewPort = new Viewport(playField);



        public void Update()
        {
            if (isRunning)
            {
                Gamerules.UpdatePlayfield();
            }
        }
    }
}