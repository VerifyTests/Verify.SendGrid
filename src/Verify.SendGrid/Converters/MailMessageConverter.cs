using SendGrid.Helpers.Mail;

class MailMessageConverter :
    WriteOnlyJsonConverter<SendGridMessage>
{
    public override void Write(VerifyJsonWriter writer, SendGridMessage mail)
    {
        writer.WriteStartObject();

        writer.WriteMember(mail, mail.From, "From");
        var to = mail.To;
        if (to.Any())
        {
            if (to.Count > 1)
            {
                writer.WriteMember(mail, to, "To");
            }
            else
            {
                writer.WriteMember(mail, to[0], "To");
            }
        }

        var cc = mail.CC;
        if (cc.Any())
        {
            if (cc.Count > 1)
            {
                writer.WriteMember(mail, cc, "Cc");
            }
            else
            {
                writer.WriteMember(mail, cc[0], "Cc");
            }
        }

        var bcc = mail.Bcc;
        if (bcc.Any())
        {
            if (bcc.Count > 1)
            {
                writer.WriteMember(mail, bcc, "Bcc");
            }
            else
            {
                writer.WriteMember(mail, bcc[0], "Bcc");
            }
        }

        var reply = mail.ReplyToList;
        if (reply.Any())
        {
            if (reply.Count > 1)
            {
                writer.WriteMember(mail, reply, "ReplyTo");
            }
            else
            {
                writer.WriteMember(mail, reply[0], "ReplyTo");
            }
        }

        writer.WriteMember(mail, mail.Subject, "Subject");
        writer.WriteMember(mail, mail.Personalizations, "Personalizations");
        
        writer.WriteMember(mail, mail.Contents, "Contents");
        writer.WriteMember(mail, mail.PlainTextContent, "PlainTextContent");
        writer.WriteMember(mail, mail.HtmlContent, "HtmlContent");
        writer.WriteMember(mail, mail.TemplateId, "TemplateId");
        writer.WriteMember(mail, mail.Headers, "Headers");
        writer.WriteMember(mail, mail.Sections, "Sections");
        writer.WriteMember(mail, mail.Categories, "Categories");
        writer.WriteMember(mail, mail.CustomArgs, "CustomArgs");
        writer.WriteMember(mail, mail.SendAt, "SendAt");

        writer.WriteMember(mail, mail.IsBodyHtml, "IsBodyHtml");
        writer.WriteMember(mail, mail.Body, "Body");

        writer.WriteMember(mail, mail.Attachments, "Attachments");
        writer.WriteEndObject();
    }
}