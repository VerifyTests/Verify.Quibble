using Quibble.CSharp;

namespace VerifyTests;

public static class VerifyQuibble
{
    public static void Initialize()
    {
        if (!VerifierSettings.StrictJson)
        {
            throw new("VerifyQuibble requers that VerifierSettings.UseStrictJson() is enabled");
        }

        VerifierSettings.RegisterStringComparer(
            "json",
            (received, verified, _) =>
            {
                if (verified == string.Empty)
                {
                    verified = "{}";
                }
                var list = JsonStrings.TextDiff(received, verified);
                if (!list.Any())
                {
                    return Task.FromResult(CompareResult.Equal);
                }

                var result = string.Join(Environment.NewLine, list);
                return Task.FromResult(CompareResult.NotEqual(result));
            });
    }
}