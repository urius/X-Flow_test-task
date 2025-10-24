using Core;

namespace Location
{
    internal class LocationService
    {
        public static readonly LocationService Instance = new();

        private const string DefaultLocation = "Лес";

        public bool CanChangeLocationTo(LocationEntityInfo entityInfo, string targetLocation)
        {
            var currentLocation = PlayerData.Instance.GetEntityValue<LocationEntityInfo, string>(entityInfo);

            return currentLocation != targetLocation;
        }

        public void ChangeLocationTo(LocationEntityInfo entityInfo, string newLocation)
        {
            if (CanChangeLocationTo(entityInfo, newLocation))
            {
                PlayerData.Instance.SetEntityValue(entityInfo, newLocation);
            }
        }

        public string GetCurrentLocation(LocationEntityInfo entityInfo)
        {
            return PlayerData.Instance.GetEntityValue(entityInfo, DefaultLocation);
        }

        public bool CanResetToDefaultLocation(LocationEntityInfo entityInfo)
        {
            return GetCurrentLocation(entityInfo) != DefaultLocation;
        }

        public void ResetToDefaultLocation(LocationEntityInfo entityInfo)
        {
            if (CanResetToDefaultLocation(entityInfo))
            {
                PlayerData.Instance.SetEntityValue(entityInfo, DefaultLocation);
            }
        }
    }
}