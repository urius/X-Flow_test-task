using Core;
using UnityEngine;

namespace Location
{
    [CreateAssetMenu(fileName = "LocationModule", menuName = "ScriptableObject/Modules/LocationModule")]
    public class LocationModule : ModuleBase
    {
        [SerializeField] private LocationEntityInfo _locationEntity;
        
        public override void Initialize()
        {
            PlayerData.Instance.RegisterEntity(_locationEntity, LocationEntityInfo.DefaultLocation);
            
            LocationService.Instance.Initialize(_locationEntity);
        }
    }
}
