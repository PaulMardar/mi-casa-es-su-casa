using System;
using System.Reflection;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ApplicationHeaderControl : DisplayBase
    {
        private readonly string applicationName;
        private readonly Version applicationVersion;

        public ApplicationHeaderControl()
        {
            Assembly assembly = Assembly.GetEntryAssembly();

            AssemblyProductAttribute assemblyProductAttribute = assembly.GetCustomAttribute<AssemblyProductAttribute>();
            applicationName = assemblyProductAttribute.Product;

            AssemblyName assemblyName = assembly.GetName();
            applicationVersion = assemblyName.Version;
        }

        public void Display()
        {
            Console.WriteLine("{0} {1}", applicationName, applicationVersion.ToString(2));
            Console.WriteLine(new string('=', 79));
        }
    }
}