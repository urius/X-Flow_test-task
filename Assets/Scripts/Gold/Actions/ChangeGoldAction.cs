using Core;
using UnityEngine;

namespace Gold.Actions
{
    [CreateAssetMenu(fileName = "ChangeGoldAction", menuName = "ScriptableObject/Actions/ChangeGoldAction")]
    internal class ChangeGoldAction : EntityActionBase<GoldEntityInfo>
    {
        [SerializeField] private int _amount;

        public override bool CanPerform()
        {
            return GoldService.Instance.CanChangeGold(EntityInfo, _amount);
        }

        public override void Perform()
        {
            GoldService.Instance.ChangeGold(EntityInfo, _amount);
        }
    }
}
