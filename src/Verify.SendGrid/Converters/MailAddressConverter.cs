using SendGrid.Helpers.Mail;

class MailAddressConverter :
    WriteOnlyJsonConverter<EmailAddress>
{
    public override void Write(VerifyJsonWriter writer, EmailAddress address)
    {
        if (address.Name == "")
        {
            writer.WriteRawValueWithScrubbers(address.Email);
        }
        else
        {
            writer.WriteRawValueWithScrubbers($"{address.Name} <{address.Email}>");
        }
    }
}