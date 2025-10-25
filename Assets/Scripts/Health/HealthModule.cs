using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "HealthModule", menuName = "ScriptableObject/Modules/HealthModule")]
    public class HealthModule : ModuleBase
    {
        [SerializeField] private HealthEntityInfo _healthEntity;
        
        public override void Initialize()
        {
            PlayerData.Instance.RegisterEntity(_healthEntity, defaultValue: 100);
            
            HealthService.Instance.Initialize(_healthEntity);
        }
    }
}
