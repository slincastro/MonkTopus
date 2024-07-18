using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ArchTests.Presentation;

public class PresentationLayerRules : ArchUnitBaseTest
{
    [Fact]
    public void DomainLayerShouldNotReferenceInfrastructureLayer()
    {
        var rule = Types().That().Are(PresentationLayer).Should().NotDependOnAny(DomainLayer);
        rule.Check(MyArchitecture);
    }
    
    [Fact]
    public void DomainLayerShouldNotReferencePresentationLayer()
    {
        var rule = Types().That().Are(PresentationLayer).Should().NotDependOnAny(InfrastructureLayer);
        rule.Check(MyArchitecture);
    }
}
