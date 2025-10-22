using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "ChangeHealthAction", menuName = "ScriptableObject/Actions/ChangeHealthAction")]
    internal class ChangeHealthAction : EntityActionBase
    {
        [SerializeField] private int _amount;

        public override bool CanPerform()
        {
            return HealthController.Instance.CanChangeHealth(_amount);
        }

        public override void Perform()
        {
            HealthController.Instance.ChangeHealth(_amount);
        }
    }
}