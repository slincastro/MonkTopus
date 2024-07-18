using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ArchTests.Domain;

public class DomainLayerRulesTest : ArchUnitBaseTest
{
    [Fact]
    public void DomainLayerShouldNotReferenceApplicationLayer()
    {
        var rule = Types().That().Are(DomainLayer).Should().NotDependOnAny(ApplicationLayer);
        rule.Check(MyArchitecture);
        Assert.True(rule.HasNoViolations(MyArchitecture));
    }
    
    [Fact]
    public void DomainLayerShouldNotReferenceInfrastructureLayer()
    {
        var rule = Types().That().Are(DomainLayer).Should().NotDependOnAny(InfrastructureLayer);
        rule.Check(MyArchitecture);
    }
    
    [Fact]
    public void DomainLayerShouldNotReferencePresentationLayer()
    {
        var rule = Types().That().Are(DomainLayer).Should().NotDependOnAny(PresentationLayer);
        rule.Check(MyArchitecture);
    }
}
