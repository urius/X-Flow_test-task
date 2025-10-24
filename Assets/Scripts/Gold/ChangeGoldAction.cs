using Core;
using UnityEngine;

namespace Gold
{
    [CreateAssetMenu(fileName = "ChangeGoldAction", menuName = "ScriptableObject/Actions/ChangeGoldAction")]
    internal class ChangeGoldAction : EntityActionBase
    {
        [SerializeField] private int _amount;

        public override bool CanPerform()
        {
            return GoldService.Instance.CanChangeGold(_amount);
        }

        public override void Perform()
        {
            GoldService.Instance.ChangeGold(_amount);
        }
    }
}
