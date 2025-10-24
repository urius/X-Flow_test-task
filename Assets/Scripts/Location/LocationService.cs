using Core;

namespace Location
{
    internal class LocationService
    {
        public static readonly LocationService Instance = new();
        
        public bool CanChangeLocationTo(string targetLocation)
        {
            var currentLocation = PlayerData.Instance.GetEntityValue<LocationEntityInfo, string>();

            return currentLocation != targetLocation;
        }
        
        public void ChangeLocationTo(string newLocation)
        {
            if (CanChangeLocationTo(newLocation))
            {
                PlayerData.Instance.SetEntityValue<LocationEntityInfo, string>(LocationEntityInfo.EntityKey, newLocation);
            }
        }
        
        public string GetCurrentLocation()
        {
            return PlayerData.Instance.GetEntityValue<LocationEntityInfo, string>();
        }
    }
}