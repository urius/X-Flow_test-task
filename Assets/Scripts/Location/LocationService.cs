using Core;

namespace Location
{
    internal class LocationService
    {
        public static readonly LocationService Instance = new();

        private const string DefaultLocation = "Лес";
        
        public bool CanChangeLocationTo(string targetLocation)
        {
            var currentLocation = PlayerData.Instance.GetEntityValue<LocationEntityInfo, string>();

            return currentLocation != targetLocation;
        }
        
        public void ChangeLocationTo(string newLocation)
        {
            if (CanChangeLocationTo(newLocation))
            {
                PlayerData.Instance.SetEntityValue<LocationEntityInfo, string>(newLocation);
            }
        }
        
        public string GetCurrentLocation()
        {
            return PlayerData.Instance.GetEntityValue<LocationEntityInfo, string>(DefaultLocation);
        }
        
        public bool CanResetToDefaultLocation()
        {
            return GetCurrentLocation() != DefaultLocation;
        }
        
        public void ResetToDefaultLocation()
        {
            if (CanResetToDefaultLocation())
            {
                PlayerData.Instance.SetEntityValue<LocationEntityInfo, string>(DefaultLocation);
            }
        }
    }
}