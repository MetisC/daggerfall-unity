// Project:         Daggerfall Unity
// Copyright:       Copyright (C) 2009-2023 Daggerfall Workshop
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)

using System;
using System.Collections.Generic;

namespace DaggerfallConnect.Arena2
{
    public sealed class ClassicWorldDatasetProvider : IWorldDatasetProvider
    {
        readonly List<ProvinceDefinition> provinces = new List<ProvinceDefinition>()
        {
            new ProvinceDefinition() { Id = "classic-iliac-bay", DisplayName = "Iliac Bay" },
        };

        readonly List<RegionDefinition> regions = new List<RegionDefinition>();

        public ClassicWorldDatasetProvider()
        {
            for (int i = 0; i < MapsFile.RegionNames.Length; i++)
            {
                regions.Add(new RegionDefinition()
                {
                    RegionId = i,
                    CanonicalName = MapsFile.RegionNames[i],
                    DisplayName = MapsFile.RegionNames[i],
                    ProvinceId = "classic-iliac-bay",
                    LegacyCompatible = true,
                    LegacyRegionIndex = i,
                });
            }
        }

        public string ProviderId => "classic";

        public WorldDimensions GetWorldDimensions() =>
            new WorldDimensions(MapsFile.ClassicMapPixelWidth, MapsFile.ClassicMapPixelHeight);

        public IReadOnlyList<ProvinceDefinition> GetProvinces() => provinces;

        public IReadOnlyList<RegionDefinition> GetRegions() => regions;

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
    }
}
