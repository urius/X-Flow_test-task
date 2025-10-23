using System;
using System.Collections.Generic;
using Core;

namespace Location
{
    internal class LocationController
    {
        public static readonly LocationController Instance = new();
        private static IReadOnlyList<LocationValue> LocationValues => (LocationValue[])Enum.GetValues(typeof(LocationValue));

        public bool CanChangeLocation(int deltaAmount)
        {
            var newIndex = GetNextLocationIndex(deltaAmount);

            return newIndex < LocationValues.Count && newIndex > 0;
        }

        public void ChangeLocation(int deltaAmount)
        {
            if (CanChangeLocation(deltaAmount))
            {
                var newIndex = GetNextLocationIndex(deltaAmount);
                var newLocation = LocationValues[newIndex];

                PlayerData.Instance.SetEntityValue<LocationEntityInfo, LocationValue>(LocationEntityInfo.EntityKey, newLocation);
            }
        }
        
        public bool CanChangeLocationTo(LocationValue targetLocation)
        {
            var currentLocation = PlayerData.Instance.GetEntityValue<LocationEntityInfo, LocationValue>();

            return currentLocation != targetLocation;
        }
        
        public void ChangeLocationTo(LocationValue newLocation)
        {
            if (CanChangeLocationTo(newLocation))
            {
                PlayerData.Instance.SetEntityValue<LocationEntityInfo, LocationValue>(LocationEntityInfo.EntityKey, newLocation);
            }
        }

        private int GetNextLocationIndex(int deltaIndex)
        {
            var currentLocation = PlayerData.Instance.GetEntityValue<LocationEntityInfo, LocationValue>();
            var newIndex = (int)currentLocation + deltaIndex;
            
            return newIndex;
        }
    }
}