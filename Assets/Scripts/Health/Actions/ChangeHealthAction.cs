using Core;
using UnityEngine;

namespace Health.Actions
{
    [CreateAssetMenu(fileName = "ChangeHealthAction", menuName = "ScriptableObject/Actions/ChangeHealthAction")]
    internal class ChangeHealthAction : EntityActionBase<HealthEntityInfo>
    {
        [SerializeField] private int _amount;

        public override bool CanPerform()
        {
            return HealthService.Instance.CanChangeHealth(_amount);
        }

        public override void Perform()
        {
            HealthService.Instance.ChangeHealth(_amount);
        }
    }
}