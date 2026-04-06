// Project:         Daggerfall Unity
// Copyright:       Copyright (C) 2009-2023 Daggerfall Workshop
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DaggerfallConnect.Arena2
{
    [Serializable]
    internal sealed class WorldDimensionsDocument
    {
        public string datasetId;
        public int mapWidth = 7680;
        public int mapHeight = 6144;
        public int terrainDim = MapsFile.WorldMapTerrainDim;
        public int tileDim = MapsFile.WorldMapTileDim;
        public int rmbDim = MapsFile.WorldMapRMBDim;
        public bool verticalAxisInverted = true;
    }

    public sealed class TamrielWorldDatasetProvider : IWorldDatasetProvider
    {
        const string dimensionsFileName = "WorldDimensions.json";
        readonly WorldDimensions dimensions;

        public TamrielWorldDatasetProvider(string datasetRoot)
        {
            dimensions = LoadDimensions(datasetRoot);
        }

        public string ProviderId => "tamriel-main";

        public WorldDimensions GetWorldDimensions() => dimensions;

        public IReadOnlyList<ProvinceDefinition> GetProvinces() => Array.Empty<ProvinceDefinition>();

        public IReadOnlyList<RegionDefinition> GetRegions() => Array.Empty<RegionDefinition>();

        public bool TryGetLocationById(long id, out LocationDefinition location)
        {
            location = null;
            return false;
        }

        public bool TryGetLocationByName(string canonicalName, string regionCanonicalName, out LocationDefinition location)
        {
            location = null;
            return false;
        }

        public IEnumerable<LocationDefinition> GetLocationsInMapPixel(int mapPixelX, int mapPixelY)
        {
            yield break;
        }

        public int GetRegionIdAtMapPixel(int mapPixelX, int mapPixelY)
        {
            return -1;
        }

        public int GetClimateIdAtMapPixel(int mapPixelX, int mapPixelY)
        {
            return (int)MapsFile.DefaultClimate;
        }

        public float SampleHeight(int mapPixelX, int mapPixelY, float u, float v)
        {
            return 0;
        }

        static WorldDimensions LoadDimensions(string datasetRoot)
        {
            string path = Path.Combine(datasetRoot, dimensionsFileName);
            if (!File.Exists(path))
                return new WorldDimensions(7680, 6144);

            try
            {
                string json = File.ReadAllText(path);
                WorldDimensionsDocument document = JsonUtility.FromJson<WorldDimensionsDocument>(json);
                if (document == null)
                    return new WorldDimensions(7680, 6144);

                return new WorldDimensions(document.mapWidth, document.mapHeight, document.terrainDim, document.tileDim, document.rmbDim, document.verticalAxisInverted);
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"Failed to load Tamriel WorldDimensions.json at '{path}': {ex.Message}");
                return new WorldDimensions(7680, 6144);
            }
        }
    }
}
