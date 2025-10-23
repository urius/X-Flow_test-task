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
            return LocationController.Instance.CanChangeLocation(_deltaIndex);
        }

        public override void Perform()
        {
            LocationController.Instance.ChangeLocation(_deltaIndex);
        }
    }
}