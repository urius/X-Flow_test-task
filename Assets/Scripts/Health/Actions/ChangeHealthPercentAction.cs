using Core;
using UnityEngine;

namespace Health.Actions
{
    [CreateAssetMenu(fileName = "ChangeHealthPercentAction", menuName = "ScriptableObject/Actions/ChangeHealthPercentAction")]
    internal class ChangeHealthPercentAction : EntityActionBase<HealthEntityInfo>
    {
        [SerializeField] private int _deltaPercent;
        
        public override bool CanPerform()
        {
            return HealthService.Instance.CanChangeHealthPercent(_deltaPercent);
        }

        public override void Perform()
        {
            HealthService.Instance.ChangeHealthPercent(_deltaPercent);
        }
    }
}