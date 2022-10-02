using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class VariableReference<T> : ISerializationCallbackReceiver
{
    [SerializeField]

    public bool UseConstant = true;
    public T ConstantValue;
    public VariableSO<T> Variable;

    public event Action<T> ChangeEvent;

    public T Value
    {
        get
        {
            return UseConstant ? ConstantValue : Variable.value;
        }
        set
        {
            if (UseConstant)
            {
                ConstantValue = value;
            }
            else
            {
                Variable.value = value;
            }
            ChangeEvent?.Invoke(value);
        }
    }

    void OnValidate()
    {
        if (UseConstant || Variable) {
            ChangeEvent?.Invoke(Value);
        }
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize() => this.OnValidate();
    void ISerializationCallbackReceiver.OnAfterDeserialize() { }
}
[System.Serializable]
public class FloatReference : VariableReference<float>
{

}
[System.Serializable]
public class IntReference : VariableReference<int>
{

}
