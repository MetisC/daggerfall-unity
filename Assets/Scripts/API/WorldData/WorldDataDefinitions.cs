// Project:         Daggerfall Unity
// Copyright:       Copyright (C) 2009-2023 Daggerfall Workshop
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)

using System;

namespace DaggerfallConnect.Arena2
{
    [Serializable]
    public sealed class ProvinceDefinition
    {
        public string Id;
        public string DisplayName;
    }

    [Serializable]
    public sealed class RegionDefinition
    {
        public int RegionId;
        public string CanonicalName;
        public string DisplayName;
        public string ProvinceId;
        public bool LegacyCompatible;
        public int LegacyRegionIndex = -1;
        public int PoliticalColorId;
        public string TravelOverlayId;
        public string[] BiomeTags;
    }

    [Serializable]
    public sealed class LocationDefinition
    {
        public long StableId;
        public string CanonicalName;
        public string DisplayName;
        public int RegionId;
        public string ProvinceId;
        public int MapPixelX;
        public int MapPixelY;
        public int WorldX;
        public int WorldZ;
    }
}
