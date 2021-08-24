using System;
using System.Threading.Tasks;
using VerifyTests;
using VerifyNUnit;
using NUnit.Framework;

[TestFixture]
public class Tests
{
    record Target(string Property1, string Property2);

    static Tests()
    {
        VerifierSettings.UseStrictJson();
        VerifyQuibble.Initialize();
        VerifierSettings.DisableClipboard();
    }

    [Test]
    public async Task Simple()
    {
        var settings = new VerifySettings();
        settings.UseMethodName("Foo");
        settings.DisableDiff();

        await Verifier.Verify(new Target("ValueA", "ValueB"), settings)
            .AutoVerify();

        FileNameBuilder.ClearPrefixList();
        await Verifier.ThrowsTask(() =>
                Verifier.Verify(
                    new Target("ValueC", "ValueD"),
                    settings))
            .ScrubLinesContaining("DiffEngineTray");
    }

    [Test]
    public async Task Sample()
    {
        var target = new Target(
            Property1: "ValueC",
            Property2: "ValueD");
        await Verifier.Verify(target);
    }
}