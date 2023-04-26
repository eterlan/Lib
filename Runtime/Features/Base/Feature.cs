using System;
using UnityEngine;

namespace Lib
{
    [Serializable]
    public abstract class Feature
    {
        public    bool             enabled = true;
        protected FeatureContainer owner;
        public    bool             oneShot;
        
        protected internal virtual void OnEnabled(FeatureContainer owner)
        {
            this.owner = owner;
            //enabled   = Filter();
            if (!enabled)
            {
                Debug.LogWarning($"Feature: {GetType().Name} is disabled because of filtered");
            }
        }

        protected internal virtual void OnDisabled(){}

        // protected internal virtual void InternalUpdate()
        // {
        //     if (Filter())
        //     {
        //         Update();
        //     }
        // }
        //
        // protected internal virtual void InternalFixedUpdate()
        // {
        //     if (Filter())
        //     {
        //         FixedUpdate();
        //     }
        // }


        protected virtual bool Filter()
        {
            return true;
        }
        
        protected internal virtual void Update()
        {
            
        }
        protected internal virtual void FixedUpdate(){}
        protected internal virtual void Start(){}
    }

    [Serializable]
    public abstract class Feature<T1> : Feature where T1 : IValue, new()
    {
        protected T1 v1;

        protected internal override void OnEnabled(FeatureContainer owner)
        {
            base.OnEnabled(owner);
            v1 = owner.GetOrAddValue<T1>();
        }
        // protected override bool Filter()
        // {
        //     var hasValue = container.TryGetValue(out v1);
        //     return hasValue;
        // }
    }

    [Serializable]
    public abstract class Feature<T1, T2> : Feature where T1 : IValue, new() 
                                                    where T2 : IValue, new()
    {
        protected T1 v1;
        protected T2 v2;

        protected internal override void OnEnabled(FeatureContainer owner)
        {
            base.OnEnabled(owner);
            v1 = owner.GetOrAddValue<T1>();
            v2 = owner.GetOrAddValue<T2>();
        }

        // protected override bool Filter()
        // {
        //     var hasV1 = container.TryGetValue(out v1);
        //     var hasV2 = container.TryGetValue(out v2);
        //     return hasV1 && hasV2;
        // }
    }

    [Serializable]
    public abstract class Feature<T1, T2, T3> : Feature where T1 : IValue, new() 
                                                        where T2 : IValue, new()
                                                        where T3 : IValue, new()
    {
        protected T1 v1;
        protected T2 v2;
        protected T3 v3;

        protected internal override void OnEnabled(FeatureContainer owner)
        {
            base.OnEnabled(owner);
            v1 = owner.GetOrAddValue<T1>();
            v2 = owner.GetOrAddValue<T2>();
            v3 = owner.GetOrAddValue<T3>();
        }
    }
}