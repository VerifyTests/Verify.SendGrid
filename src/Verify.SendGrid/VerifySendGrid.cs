namespace VerifyTests;

public static class VerifySendGrid
{
    public static bool Initialized { get; private set; }

    public static void Initialize()
    {
        if (Initialized)
        {
            throw new("Already Initialized");
        }

        Initialized = true;

        InnerVerifier.ThrowIfVerifyHasBeenRun();
        VerifierSettings.AddExtraSettings(_ =>
        {
            _.Converters.Add(new MailAddressConverter());
            _.Converters.Add(new MailAttachmentConverter());
            _.Converters.Add(new MailMessageConverter());
        });
    }

    internal static DateTime UnixTimeStampToDateTime(double unixTimeStamp) =>
        // Unix timestamp is seconds past epoch
        new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            .AddSeconds(unixTimeStamp)
            .ToUniversalTime();
}