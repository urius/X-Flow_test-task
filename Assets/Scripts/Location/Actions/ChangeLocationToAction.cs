using Core;
using UnityEngine;

namespace Location.Actions
{
    [CreateAssetMenu(fileName = "ChangeLocationToAction", menuName = "ScriptableObject/Actions/ChangeLocationToAction")]
    internal class ChangeLocationToAction : EntityActionBase<LocationEntityInfo>
    {
        [SerializeField] private string _targetLocation;
        
        public override bool CanPerform()
        {
            return LocationService.Instance.CanChangeLocationTo(EntityInfo, _targetLocation);
        }

        public override void Perform()
        {
            LocationService.Instance.ChangeLocationTo(EntityInfo, _targetLocation);
        }
    }
}