using Core;
using UnityEngine;

namespace Location
{
    [CreateAssetMenu(fileName = "ChangeLocationAction", menuName = "ScriptableObject/Actions/ChangeLocationAction")]
    public class ChangeLocationAction : EntityActionBase
    {
        [SerializeField] private int _deltaIndex;
        
        public override bool CanPerform()
        {
            return LocationService.Instance.CanChangeLocation(_deltaIndex);
        }

        public override void Perform()
        {
            LocationService.Instance.ChangeLocation(_deltaIndex);
        }
    }
}