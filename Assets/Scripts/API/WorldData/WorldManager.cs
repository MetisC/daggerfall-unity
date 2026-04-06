// Project:         Daggerfall Unity
// Copyright:       Copyright (C) 2009-2023 Daggerfall Workshop
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)

using System.IO;
using UnityEngine;

namespace DaggerfallConnect.Arena2
{
    public sealed class WorldManager
    {
        public WorldDimensions CurrentDimensions { get; private set; }
        public IWorldDatasetProvider Dataset { get; private set; }

        public void Boot(IWorldDatasetProvider provider)
        {
            Dataset = provider;
            CurrentDimensions = provider.GetWorldDimensions();
            WorldSettings.Load(CurrentDimensions);
        }
    }

    public static class WorldBootstrap
    {
        const string tamrielDatasetSubfolder = "WorldData/Tamriel";

        public static IWorldDatasetProvider CreateProvider(bool useTamrielDataset)
        {
            if (!useTamrielDataset)
                return new ClassicWorldDatasetProvider();

            string datasetRoot = Path.Combine(Application.streamingAssetsPath, tamrielDatasetSubfolder);
            return new TamrielWorldDatasetProvider(datasetRoot);
        }
    }
}
