namespace Core
{
    internal class ValueHolder<TValue> : ValueHolder
    {
        public TValue Value;

        public ValueHolder(TValue defaultValue)
        {
            Value = defaultValue;
        }

        public override string GetStringValue()
        {
            return Value.ToString();
        }
    }

    internal abstract class ValueHolder
    {
        public abstract string GetStringValue();
    }
}