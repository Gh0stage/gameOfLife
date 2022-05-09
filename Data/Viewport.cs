namespace gameOfLife.Data
{
    internal class Viewport
    {
        public static Playfield Playfield { get; set; }
        public List<Chunk> LoadedChunks { get; set; }
        public int canvasSizeX;
        public int canvasSizeY;
        public Coordinate viewportCoordLB = new Coordinate(null, 0, 0);
        public Coordinate viewportCoordRA = new Coordinate(null, 100, 100);



        public const int BUFFERSIZE = 2;

        public Viewport(Playfield playfield)
        {
            Viewport.Playfield = playfield;
        }

        public void UpdateCanvas()
        {
            updateLoadedChunks();
        }
        public bool cornerCheck(Coordinate point)
        {
            if (point.X < viewportCoordLB.X || point.X > viewportCoordRA.X || point.Y < viewportCoordLB.Y || point.Y > viewportCoordRA.Y)
            {
                return false;
            }
            return true;
        }

        private void updateLoadedChunks()
        {
            foreach (Chunk chunk in Viewport.Playfield.chunkGrid)
            {
                Coordinate viewportCoordLA = new Coordinate(null, viewportCoordLB.X, viewportCoordRA.Y);
                Coordinate viewportCoordRB = new Coordinate(null, viewportCoordRA.X, viewportCoordLB.Y);
                if (cornerCheck(viewportCoordLB) || cornerCheck(viewportCoordRA) || cornerCheck(viewportCoordLA) || cornerCheck(viewportCoordRB))
                {
                    if (!LoadedChunks.Contains(chunk))
                    {
                        LoadedChunks.Add(chunk);
                    }
                }
                else
                {
                    if (LoadedChunks.Contains(chunk))
                    {
                        LoadedChunks.Remove(chunk);
                    }
                }
            }
        }
    }
}