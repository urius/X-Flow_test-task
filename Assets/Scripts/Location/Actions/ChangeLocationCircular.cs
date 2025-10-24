using System;
using Core;
using UnityEngine;

namespace Location.Actions
{
    [CreateAssetMenu(fileName = "ChangeLocationCircular", menuName = "ScriptableObject/Actions/ChangeLocationCircular")]
    internal class ChangeLocationCircular : EntityActionBase<LocationEntityInfo>
    {
        [SerializeField] private string[] _locationsList;
        
        public override bool CanPerform()
        {
            if (_locationsList is { Length: > 0 })
            {
                var currentLocation = LocationService.Instance.GetCurrentLocation(EntityInfo);
                return _locationsList.Length != 1 || _locationsList[0] != currentLocation;
            }

            return false;
        }

        public override void Perform()
        {
            if (CanPerform())
            {
                var currentLocation = LocationService.Instance.GetCurrentLocation(EntityInfo);
                var currentLocationIndex = Array.IndexOf(_locationsList, currentLocation);
                
                if (currentLocationIndex < 0 || currentLocationIndex >= _locationsList.Length - 1)
                {
                    LocationService.Instance.ChangeLocationTo(EntityInfo, _locationsList[0]);
                }
                else
                {
                    LocationService.Instance.ChangeLocationTo(EntityInfo, _locationsList[currentLocationIndex + 1]);
                }
            }
        }
    }
}