using Core;

namespace Location
{
    internal class LocationService
    {
        public static readonly LocationService Instance = new();
        
        private readonly PlayerData _playerData = PlayerData.Instance;
        
        private LocationEntityInfo _entityInfo;


        public void Initialize(LocationEntityInfo locationEntity)
        {
            _entityInfo = locationEntity;
        }

        public bool CanChangeLocationTo(string targetLocation)
        {
            var currentLocation = GetCurrentLocation();

            return currentLocation != targetLocation;
        }

        public void ChangeLocationTo(string newLocation)
        {
            if (CanChangeLocationTo(newLocation))
            {
                _playerData.SetEntityValue(_entityInfo, newLocation);
            }
        }

        public string GetCurrentLocation()
        {
            return PlayerData.Instance.GetEntityValue<LocationEntityInfo, string>(_entityInfo);
        }

        public bool CanResetToDefaultLocation()
        {
            return GetCurrentLocation() != LocationEntityInfo.DefaultLocation;
        }

        public void ResetToDefaultLocation()
        {
            if (CanResetToDefaultLocation())
            {
                _playerData.SetEntityValue(_entityInfo, LocationEntityInfo.DefaultLocation);
            }
        }
    }
}