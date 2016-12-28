using System;

namespace Zenject
{
    public class FromBinderGeneric<TContract> : FromBinder
    {
        public FromBinderGeneric(
            BindInfo bindInfo,
            BindFinalizerWrapper finalizerWrapper)
            : base(bindInfo, finalizerWrapper)
        {
            BindingUtil.AssertIsDerivedFromTypes(typeof(TContract), BindInfo.ContractTypes);
        }

        public ScopeArgBinder FromFactory<TFactory>()
            where TFactory : IFactory<TContract>
        {
            return FromFactoryBase<TContract, TFactory>();
        }

        public ScopeArgBinder FromFactory<TConcrete, TFactory>()
            where TFactory : IFactory<TConcrete>
            where TConcrete : TContract
        {
            return FromFactoryBase<TConcrete, TFactory>();
        }

        public ScopeArgBinder FromMethod(Func<InjectContext, TContract> method)
        {
            return FromMethodBase<TContract>(method);
        }

        public ScopeBinder FromResolveGetter<TObj>(Func<TObj, TContract> method)
        {
            return FromResolveGetter<TObj>(null, method);
        }

        public ScopeBinder FromResolveGetter<TObj>(object identifier, Func<TObj, TContract> method)
        {
            return FromResolveGetterBase<TObj, TContract>(identifier, method);
        }

        public ScopeBinder FromInstance(TContract instance)
        {
            return FromInstance(instance, false);
        }

        public ScopeBinder FromInstance(TContract instance, bool allowNull)
        {
            return FromInstanceBase(instance, allowNull);
        }
    }
}

