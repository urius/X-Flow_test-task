using Core;
using UnityEngine;

namespace Location.Actions
{
    [CreateAssetMenu(fileName = "ResetLocationToDefaultAction", menuName = "ScriptableObject/Actions/ResetLocationToDefaultAction")]
    internal class ResetLocationToDefaultAction : EntityActionBase<LocationEntityInfo>
    {
        public override bool CanPerform()
        {
            return LocationService.Instance.CanResetToDefaultLocation();
        }

        public override void Perform()
        {
            LocationService.Instance.ResetToDefaultLocation();
        }
    }
}