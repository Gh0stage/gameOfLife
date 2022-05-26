namespace gameOfLife.Data
{
    internal class Viewport
    {
        public static Playfield Playfield { get; set; }
        public List<Chunk> LoadedChunks { get; set; }
        public int canvasSizeX = 300;
        public int canvasSizeY = 600;
        public Coordinate viewportCoordLB = new Coordinate(Playfield.chunkGrid[0,0], 0, 0);
        public Coordinate viewportCoordRA = new Coordinate(null, 0, 0); 
        public LiveNode[,] canvas = new LiveNode[,] { };

        

        public const int BUFFERSIZE = 2;
        
        public Viewport(Playfield playfield)
        {
            Viewport.Playfield = playfield;
        }

        public void UpdateCanvas()
        {
            foreach (Chunk chunk in LoadedChunks)
            {
                foreach (LiveNode cell in chunk.GetActiveCells())
                {
                    canvas[chunk.RootCoord.X*Chunk.SIZE+cell.Location.X, chunk.RootCoord.Y * Chunk.SIZE + cell.Location.Y] = cell;
                }
            }
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

        internal void Update()
        {
            updateLoadedChunks();
            int xLChunksX = (LoadedChunks.Max(x => x.RootCoord.X)) - (LoadedChunks.Min(x => x.RootCoord.X) +2);
            int xLChunksY = (LoadedChunks.Max(x => x.RootCoord.Y)) - (LoadedChunks.Min(x => x.RootCoord.Y) +2);
            canvas = new LiveNode[xLChunksX, xLChunksY];
            UpdateCanvas();
        }
    }
}