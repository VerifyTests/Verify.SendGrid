class SendGridMessageConverter :
    WriteOnlyJsonConverter<SendGridMessage>
{
    public override void Write(VerifyJsonWriter writer, SendGridMessage mail)
    {
        writer.WriteStartObject();
        writer.WriteMember(mail, mail.From, "From");
        writer.WriteMember(mail, mail.Personalizations, "Personalizations");
        writer.WriteMember(mail, mail.ReplyTo, "ReplyTo");
        writer.WriteMember(mail, mail.ReplyTos, "ReplyTos");
        writer.WriteMember(mail, mail.Subject, "Subject");
        writer.WriteMember(mail, mail.Contents, "Contents");
        writer.WriteMember(mail, mail.PlainTextContent, "PlainTextContent");
        writer.WriteMember(mail, mail.HtmlContent, "HtmlContent");
        writer.WriteMember(mail, mail.Attachments, "Attachments");
        writer.WriteMember(mail, mail.TemplateId, "TemplateId");
        writer.WriteMember(mail, mail.Headers, "Headers");
        writer.WriteMember(mail, mail.Sections, "Sections");
        writer.WriteMember(mail, mail.Categories, "Categories");
        writer.WriteMember(mail, mail.CustomArgs, "CustomArgs");
        if (mail.SendAt != null)
        {
            writer.WriteMember(mail, VerifySendGrid.UnixTimeStampToDateTime(mail.SendAt.Value), "SendAt");
        }
        writer.WriteMember(mail, mail.Asm, "Asm");
        writer.WriteMember(mail, mail.BatchId, "BatchId");
        writer.WriteMember(mail, mail.IpPoolName, "IpPoolName");
        writer.WriteMember(mail, mail.MailSettings, "MailSettings");
        writer.WriteMember(mail, mail.TrackingSettings, "TrackingSettings");

        writer.WriteEndObject();
    }
}