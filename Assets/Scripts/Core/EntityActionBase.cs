using UnityEngine;

namespace Core
{
    public abstract class EntityActionBase<T> : EntityActionBase where T : EntityInfoBase
    {
        [SerializeField] protected T EntityInfo;
        
        public override string EntityKey => EntityInfo.Key;
    }

    public abstract class EntityActionBase : ScriptableObject
    {
        public abstract string EntityKey { get; }
        
        public abstract bool CanPerform();
        public abstract void Perform();
    }
}