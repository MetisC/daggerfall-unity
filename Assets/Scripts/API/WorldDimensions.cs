// Project:         Daggerfall Unity
// Copyright:       Copyright (C) 2009-2023 Daggerfall Workshop
// Web Site:        http://www.dfworkshop.net
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Source Code:     https://github.com/Interkarma/daggerfall-unity

namespace DaggerfallConnect.Arena2
{
    /// <summary>
    /// Describes runtime dimensions and scales for the overworld.
    /// Defaults to classic Daggerfall 1000x500 map pixels.
    /// </summary>
    public sealed class WorldDimensions
    {
        public WorldDimensions(int mapPixelWidth, int mapPixelHeight, int mapPixelToWorldUnitScale = MapsFile.WorldMapTerrainDim, int worldMapTileDim = MapsFile.WorldMapTileDim)
        {
            MapPixelWidth = mapPixelWidth;
            MapPixelHeight = mapPixelHeight;
            MapPixelToWorldUnitScale = mapPixelToWorldUnitScale;
            WorldMapTileDim = worldMapTileDim;
        }

        public int MapPixelWidth { get; }
        public int MapPixelHeight { get; }
        public int MapPixelToWorldUnitScale { get; }
        public int WorldMapTileDim { get; }

        public int MaxWorldCoordX => MapPixelWidth * MapPixelToWorldUnitScale;
        public int MaxWorldCoordZ => MapPixelHeight * MapPixelToWorldUnitScale;
        public int MaxWorldTileCoordX => MapPixelWidth * WorldMapTileDim;
        public int MaxWorldTileCoordZ => MapPixelHeight * WorldMapTileDim;

        public int LastMapPixelX => MapPixelWidth - 1;
        public int LastMapPixelY => MapPixelHeight - 1;
    }

    /// <summary>
    /// Central runtime source of truth for world dimensions.
    /// </summary>
    public static class WorldSettings
    {
        static WorldSettings()
        {
            Dimensions = new WorldDimensions(MapsFile.MaxMapPixelX, MapsFile.MaxMapPixelY);
        }

        public static WorldDimensions Dimensions { get; private set; }

        public static void Load(WorldDimensions dimensions)
        {
            Dimensions = dimensions;
        }
    }
}
