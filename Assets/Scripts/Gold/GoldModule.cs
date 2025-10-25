using Core;
using UnityEngine;

namespace Gold
{
    [CreateAssetMenu(fileName = "GoldModule", menuName = "ScriptableObject/Modules/GoldModule")]
    public class GoldModule : ModuleBase
    {
        [SerializeField] private GoldEntityInfo _goldEntity;
        
        public override void Initialize()
        {
            PlayerData.Instance.RegisterEntity<GoldEntityInfo, int>(_goldEntity);
            
            GoldService.Instance.Initialize(_goldEntity);
        }
    }
}