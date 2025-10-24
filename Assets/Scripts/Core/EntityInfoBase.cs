using System;
using UnityEngine;

namespace Core
{
    public abstract class EntityInfoBase<TValue> : EntityInfoBase
    {
    }
    
    public abstract class EntityInfoBase : ScriptableObject
    {
        [SerializeField] private string _name;
        private Type _type;

        public abstract string Key { get; }
        public abstract string GetStringValue();

        public string EntityName => _name;
        public Type CashedType => _type ??= GetType();
    }
}