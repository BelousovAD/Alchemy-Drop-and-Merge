using Bootstrap;
using Reflex.Core;
using UnityEngine;

namespace Currency
{
    internal class CurrencyInstaller : MonoBehaviour, IInstaller
    {
        private SaveableCurrency _money;
        private ContainerBuilder _builder;

        public void InstallBindings(ContainerBuilder builder)
        {
            _builder = builder;
            _money = new SaveableCurrency(CurrencyType.Money);

            _builder.RegisterValue(_money, new[] { typeof(Currency) });

            _builder.OnContainerBuilt += Initialize;
        }

        private void Initialize(Container container)
        {
            _builder.OnContainerBuilt -= Initialize;

            _money.Initialize(container.Resolve<SavvyServicesProvider>());
        }
    }
}