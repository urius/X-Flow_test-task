using Core;
using UnityEngine;

namespace Location.Actions
{
    [CreateAssetMenu(fileName = "ChangeLocationToAction", menuName = "ScriptableObject/Actions/ChangeLocationToAction")]
    public class ChangeLocationToAction : EntityActionBase
    {
        [SerializeField] private string _targetLocation;
        
        public override bool CanPerform()
        {
            return LocationService.Instance.CanChangeLocationTo(_targetLocation);
        }

        public override void Perform()
        {
            LocationService.Instance.ChangeLocationTo(_targetLocation);
        }
    }
}