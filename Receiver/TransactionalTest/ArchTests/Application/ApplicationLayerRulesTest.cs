using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ArchTests.Application;

public class ApplicationLayerRulesTest : ArchUnitBaseTest
{
    [Fact]
    public void DomainLayerShouldNotReferenceInfrastructureLayer()
    {
        var rule = Types().That().Are(ApplicationLayer).Should().NotDependOnAny(InfrastructureLayer);
        rule.Check(MyArchitecture);
    }
    
    [Fact]
    public void DomainLayerShouldNotReferencePresentationLayer()
    {
        var rule = Types().That().Are(ApplicationLayer).Should().NotDependOnAny(PresentationLayer);
        rule.Check(MyArchitecture);
    }
}
