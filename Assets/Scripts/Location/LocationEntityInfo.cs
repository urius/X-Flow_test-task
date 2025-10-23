using System.Linq;
using Core;
using UnityEngine;

namespace Location
{
    [CreateAssetMenu(fileName = "LocationEntityInfo", menuName = "ScriptableObject/EntityInfo/LocationEntityInfo")]
    internal class LocationEntityInfo : EntityInfoBase<LocationValue>
    {
        public const string EntityKey = "Location";

        [SerializeField] private LocationData[] _locationDataList;
        
        public override string Key => EntityKey;
        
        public override string GetStringValue()
        {
            var locationValue = PlayerData.Instance.GetEntityValue<LocationEntityInfo, LocationValue>();

            return _locationDataList.FirstOrDefault(d => d.Location == locationValue)?.LocationName ?? locationValue.ToString();
        }
    }
}