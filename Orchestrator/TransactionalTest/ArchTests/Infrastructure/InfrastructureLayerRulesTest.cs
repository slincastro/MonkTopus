using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ArchTests.Infrastructure;

public class InfrastructureLayerRulesTest : ArchUnitBaseTest
{
    [Fact]
    public void InfrastructureLayerShouldNotReferenceDomainLayer()
    {
        var rule = Types().That().Are(InfrastructureLayer).Should().NotDependOnAny(DomainLayer);
        rule.Check(MyArchitecture);
        Assert.True(rule.HasNoViolations(MyArchitecture));
    }
    
    [Fact]
    public void InfrastructureLayerShouldNotReferencePresentationLayer()
    {
        var rule = Types().That().Are(InfrastructureLayer).Should().NotDependOnAny(PresentationLayer);
        rule.Check(MyArchitecture);
    }
}
