using Domain;
using Application;
using Infrastructure;
using Presentation;
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using  Assembly = System.Reflection.Assembly;

namespace ArchTests
{
    public abstract class ArchUnitBaseTest
    {
        protected static readonly Assembly DomainAssembly = typeof(DomainArchUnitMarker).Assembly;
        protected static readonly Assembly ApplicationAssembly = typeof(ApplicationArchUnitMarker).Assembly;
        protected static readonly Assembly InfrastructureAssembly = typeof(InfrastructureArchUnitMarker).Assembly;
        protected static readonly Assembly PresentationAssembly = typeof(PresentationArchUnitMarker).Assembly;

        protected static readonly Architecture MyArchitecture = 
            new ArchLoader()
                .LoadAssemblies(DomainAssembly, ApplicationAssembly, InfrastructureAssembly, PresentationAssembly)
                .Build();

        protected static readonly IObjectProvider<IType> DomainLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(DomainAssembly).As("Domain Layer");

        protected static readonly IObjectProvider<IType> ApplicationLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(ApplicationAssembly).As("Application Layer");

        protected static readonly IObjectProvider<IType> InfrastructureLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(InfrastructureAssembly).As("Infrastructure Layer");

        protected static readonly IObjectProvider<IType> PresentationLayer =
            ArchRuleDefinition.Types().That().ResideInAssembly(PresentationAssembly).As("Presentation Layer");

    }
}
