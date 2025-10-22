using UnityEngine;

namespace Core
{
    public abstract class EntityActionBase : ScriptableObject
    {
        [SerializeField] protected EntityInfoBase EntityInfo;
        
        public abstract bool CanPerform();
        public abstract void Perform();
    }
}