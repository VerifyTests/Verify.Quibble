public class Tests
{
    record Target(string Property1, string Property2);

    [Fact]
    public async Task Sample()
    {
        var target = new Target(
            Property1: "ValueC",
            Property2: "ValueD");
        await Verify(target);
    }
}