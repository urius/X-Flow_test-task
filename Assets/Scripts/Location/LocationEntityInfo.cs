using Core;
using UnityEngine;

namespace Location
{
    [CreateAssetMenu(fileName = "LocationEntityInfo", menuName = "ScriptableObject/EntityInfo/LocationEntityInfo")]
    internal class LocationEntityInfo : EntityInfoBase<string>
    {
        public const string EntityKey = "Location";
        public const string DefaultLocation = "Лес";

        public override string Key => EntityKey;

        
        public override string GetStringValue()
        {
            return LocationService.Instance.GetCurrentLocation();
        }
    }
}