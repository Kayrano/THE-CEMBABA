﻿#if ENABLE_EXPERIMENTAL_INCREMENTAL_PIPELINE
using System.Linq;

namespace Unity.Build
{
    // TODO Ideally we would like to expose Pram directly here.
    // But as it stands today Pram wants to use NiceIO and Shell.Execute, which we import directly from precompiled bee
    // Unity.Build namespace doesn't contain bee references, hence why we provide an interface here for now.
    internal abstract class RunTargetProviderBase
    {
        private static RunTargetProviderBase[] m_Providers;
        /// <summary>
        /// Discover all available run targets.
        /// </summary>
        public abstract RunTargetBase[] Discover();

        /// <summary>
        /// Discover all available run targets.
        /// </summary>
        public static RunTargetBase[] DiscoverFromAllProviders()
        {
            if (m_Providers == null)
                m_Providers = TypeCacheHelper.ConstructTypesDerivedFrom<RunTargetProviderBase>().ToArray();

            return m_Providers.SelectMany(x => x.Discover()).ToArray();
        }
    }
}
#endif
