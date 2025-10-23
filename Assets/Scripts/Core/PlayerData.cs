using System;
using System.Collections.Generic;

namespace Core
{
    public class PlayerData
    {
        public event Action<string> ValueChanged;
        
        public static readonly PlayerData Instance = new();
        
        private readonly Dictionary<Type, string> _entityKeyByEntityTypeDict = new();
        private readonly Dictionary<string, ValueHolder> _valueHoldersByEntityKey = new();

        public TValue GetEntityValue<TEntity, TValue>() 
            where TEntity : EntityInfoBase<TValue>
        {
            if (_entityKeyByEntityTypeDict.TryGetValue(typeof(TEntity), out var entityKey)
                && _valueHoldersByEntityKey.TryGetValue(entityKey, out var valueHolder))
            {
                return ((ValueHolder<TValue>)valueHolder).Value;
            }
            
            return default;
        }
        
        public void SetEntityValue<TEntity, TValue>(string entityKey, TValue value) 
            where TEntity : EntityInfoBase<TValue>
        {
            var entityType = typeof(TEntity);

            _entityKeyByEntityTypeDict.TryAdd(entityType, entityKey);

            if (_valueHoldersByEntityKey.TryGetValue(entityKey, out var valueHolder) == false)
            {
                valueHolder = new ValueHolder<TValue>();
                _valueHoldersByEntityKey[entityKey] = valueHolder;
            }
            
            ((ValueHolder<TValue>)valueHolder).Value = value;
            
            ValueChanged?.Invoke(entityKey);
        }
        
        public string GetStrValue(string entityKey)
        {
            if (_valueHoldersByEntityKey.TryGetValue(entityKey, out var result))
            {
                return result.GetStringValue();
            }

            return string.Empty;
        }
    }
}