using Core;
using UnityEngine;

namespace Location
{
    [CreateAssetMenu(fileName = "ChangeLocationToAction", menuName = "ScriptableObject/Actions/ChangeLocationActionTo")]
    public class ChangeLocationToAction : EntityActionBase
    {
        [SerializeField] private LocationValue _targetLocation;
        
        public override bool CanPerform()
        {
            return LocationController.Instance.CanChangeLocationTo(_targetLocation);
        }

        public override void Perform()
        {
            LocationController.Instance.ChangeLocationTo(_targetLocation);
        }
    }
}