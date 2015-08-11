using System;

namespace Core.Utility
{
    public static class General
    {
        public static Random Random = new Random(Guid.NewGuid().GetHashCode());
    }
}