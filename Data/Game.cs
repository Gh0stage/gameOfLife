using System.Timers.Timer;

namespace gameOfLife.Data
{
    //This class is used to store the data of the game and is used to implement the game logic.
    internal class Game
    {

        //Global variables which can be changed from frontend
        private static bool isRunning; //   indicates if the game is running
        private static bool isInteractable;

        private static double zoomModifier;
        private static double zoomModifierMin;
        private static double zoomModifierMax;
        private static double zoomModifierDefault;

        private static Coordinate viewportRoot;

        static double speedModifier;
        static double speedModifierMin;
        static double speedModifierMax;
        static double speedModifierDefault;

        

        private static Playfield playField = new Playfield();
        private static Viewport viewPort = new Viewport(playField);

        public void Update(object iets)
        {
            if (isRunning)
            {
                playField.Update();
                viewPort.Update();
            }
        }
    }
}