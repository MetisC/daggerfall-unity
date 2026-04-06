// Project:         Daggerfall Unity
// Copyright:       Copyright (C) 2009-2023 Daggerfall Workshop
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)

using System.Collections.Generic;

namespace DaggerfallConnect.Arena2
{
    public interface IWorldDatasetProvider
    {
        string ProviderId { get; }
        WorldDimensions GetWorldDimensions();
        IReadOnlyList<ProvinceDefinition> GetProvinces();
        IReadOnlyList<RegionDefinition> GetRegions();
        bool TryGetLocationById(long id, out LocationDefinition location);
        bool TryGetLocationByName(string canonicalName, string regionCanonicalName, out LocationDefinition location);
        IEnumerable<LocationDefinition> GetLocationsInMapPixel(int mapPixelX, int mapPixelY);
        int GetRegionIdAtMapPixel(int mapPixelX, int mapPixelY);
        int GetClimateIdAtMapPixel(int mapPixelX, int mapPixelY);
        float SampleHeight(int mapPixelX, int mapPixelY, float u, float v);
    }
}
