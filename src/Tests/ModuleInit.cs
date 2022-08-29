public static class ModuleInit
{
    #region enable

    [ModuleInitializer]
    public static void Init()
    {
        VerifierSettings.UseStrictJson();
        VerifyQuibble.Initialize();

        #endregion

        VerifyDiffPlex.Initialize();
    }
}