﻿using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.TestObjects;
using Volo.Abp.Threading;

namespace Volo.Abp.ObjectExtending
{
    [DependsOn(typeof(AbpObjectExtendingModule))]
    public class AbpObjectExtendingTestModule : AbpModule
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            OneTimeRunner.Run(() =>
            {
                ObjectExtensionManager.Instance
                    .AddOrUpdateProperty<ExtensibleTestPerson, string>("Name")
                    .AddOrUpdateProperty<ExtensibleTestPerson, int>("Age")
                    .AddOrUpdateProperty<ExtensibleTestPersonDto, string>("Name")
                    .AddOrUpdateProperty<ExtensibleTestPersonDto, int>("ChildCount");
            });
        }
    }
}
