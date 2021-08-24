using System;
using System.Threading.Tasks;
using VerifyTests;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class Tests
{
    record Target(string Property1, string Property2);

    static Tests()
    {
        VerifierSettings.UseStrictJson();
        VerifyQuibble.Initialize();
        VerifierSettings.DisableClipboard();
    }
    
    [Fact]
    public async Task Simple()
    {
        var settings = new VerifySettings();
        settings.UseMethodName("Foo");
        settings.DisableDiff();

        await Verifier.Verify(new Target("ValueA", "ValueB"), settings)
            .AutoVerify();

        FileNameBuilder.ClearPrefixList();
        var exception = await Assert.ThrowsAnyAsync<Exception>(() =>
            Verifier.Verify(new Target("ValueC", "ValueD"), settings));
        Assert.Contains(@"Compare Result:
String value difference at $.Property1: ValueC vs ValueA.
String value difference at $.Property2: ValueD vs ValueB.", exception.Message);
    }

    [Fact]
    public async Task Sample()
    {
        var target = new Target(
            Property1: "ValueC",
            Property2: "ValueD");
        await Verifier.Verify(target);
    }
}