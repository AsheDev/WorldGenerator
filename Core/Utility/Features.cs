using Core.Interfaces;

namespace Core.Utility
{
    public static class Features
    {
        public static bool AreCompatible(IFeatures one, IFeatures two)
        {
            // how do I want this to work?
            // do I pass in a list and then loop over each item?
            switch (one.GetType().Name.ToLower())
            {
                case "bog":
                    break;
                case "caves":
                    break;
                case "craters":
                    break;
                case "dunes":
                    break;
                case "faults":
                    break;
                case "forest":
                    break;
                case "fumaroles":
                    break;
                case "karst":
                    break;
                case "ridges":
                    break;
                case "rivers":
                    break;
                case "shrubland":
                    break;
                case "talus":
                default:
                    break;
            }



            return true;
        }
    }
}
