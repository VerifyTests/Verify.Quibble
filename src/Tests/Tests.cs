[UsesVerify]
public class Tests
{
    record Target(string Property1, string Property2);

    static Tests()
    {
        VerifierSettings.UseStrictJson();
        VerifyQuibble.Initialize();
    }

    [Fact]
    public async Task Sample()
    {
        var target = new Target(
            Property1: "ValueC",
            Property2: "ValueD");
        await Verify(target);
    }
}