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
        public WorldDimensions(
            int mapPixelWidth,
            int mapPixelHeight,
            int mapPixelToWorldUnitScale = MapsFile.WorldMapTerrainDim,
            int worldMapTileDim = MapsFile.WorldMapTileDim,
            int worldMapRmbDim = MapsFile.WorldMapRMBDim,
            bool verticalAxisInverted = true)
        {
            MapWidth = mapPixelWidth;
            MapHeight = mapPixelHeight;
            TerrainDim = mapPixelToWorldUnitScale;
            TileDim = worldMapTileDim;
            RmbDim = worldMapRmbDim;
            VerticalAxisInverted = verticalAxisInverted;
        }

        public int MapWidth { get; }
        public int MapHeight { get; }
        public int TerrainDim { get; }
        public int TileDim { get; }
        public int RmbDim { get; }
        public bool VerticalAxisInverted { get; }

        // Compatibility aliases while migrating engine-wide API names.
        public int MapPixelWidth => MapWidth;
        public int MapPixelHeight => MapHeight;
        public int MapPixelToWorldUnitScale => TerrainDim;
        public int WorldMapTileDim => TileDim;

        public int MapHeightMinusOne => MapHeight - 1;
        public int MaxWorldCoordX => MapWidth * TerrainDim;
        public int MaxWorldCoordZ => MapHeight * TerrainDim;
        public int MaxWorldTileCoordX => MapWidth * TileDim;
        public int MaxWorldTileCoordZ => MapHeight * TileDim;

        public int LastMapPixelX => MapWidth - 1;
        public int LastMapPixelY => MapHeightMinusOne;
    }

    /// <summary>
    /// Central runtime source of truth for world dimensions.
    /// </summary>
    public static class WorldSettings
    {
        static WorldSettings()
        {
            Dimensions = new WorldDimensions(MapsFile.ClassicMapPixelWidth, MapsFile.ClassicMapPixelHeight);
        }

        public static WorldDimensions Dimensions { get; private set; }

        public static void Load(WorldDimensions dimensions)
        {
            Dimensions = dimensions;
        }
    }
}
