class EmailAddressConverter :
    WriteOnlyJsonConverter<EmailAddress>
{
    public override void Write(VerifyJsonWriter writer, EmailAddress address)
    {
        if (address.Name == null)
        {
            writer.WriteRawValueWithScrubbers(address.Email);
        }
        else
        {
            writer.WriteRawValueWithScrubbers($"{address.Name} <{address.Email}>");
        }
    }
}