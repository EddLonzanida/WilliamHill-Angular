using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace TechChallenge.Tests.Integration.Utils
{
    public static class MefExtensions
    {
        public static object GetExportedValueByType(this CompositionContainer container, Type type)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                if (partDef.ExportDefinitions.All(exportDef => exportDef.ContractName != type.FullName)) continue;

                var contract = AttributedModelServices.GetContractName(type);
                var definition = new ContractBasedImportDefinition(contract, contract, null, ImportCardinality.ExactlyOne,
                    false, false, CreationPolicy.Any);

                return container.GetExports(definition).FirstOrDefault()?.Value;
            }

            return null;
        }

        public static IEnumerable<object> GetExportedValuesByType(this CompositionContainer container, Type type)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                if (partDef.ExportDefinitions.All(exportDef => exportDef.ContractName != type.FullName)) continue;

                var contract = AttributedModelServices.GetContractName(type);
                var definition = new ContractBasedImportDefinition(contract, contract, null, ImportCardinality.ExactlyOne,
                    false, false, CreationPolicy.Any);

                return container.GetExports(definition);
            }

            return new List<object>();
        }

        public static T GetExportedValue<T>(this CompositionContainer container,
            Func<IDictionary<string, object>, bool> predicate)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                foreach (var exportDef in partDef.ExportDefinitions)
                {
                    if (exportDef.ContractName != typeof(T).FullName) continue;

                    if (predicate(exportDef.Metadata))
                        return (T)partDef.CreatePart().GetExportedValue(exportDef);
                }
            }

            return default;
        }

        public static T GetExportedValueByType<T>(this CompositionContainer container, string type)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                foreach (var exportDef in partDef.ExportDefinitions)
                {
                    if (exportDef.ContractName == type)
                        return (T)partDef.CreatePart().GetExportedValue(exportDef);
                }
            }

            return default;
        }
    }
}
