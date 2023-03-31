using SendGrid.Helpers.Mail;

class MailAttachmentConverter :
    WriteOnlyJsonConverter<Attachment>
{
    public override void Write(VerifyJsonWriter writer, Attachment attachment)
    {
        writer.WriteStartObject();

        writer.WriteMember(attachment, attachment.Filename, "Filename");
        writer.WriteMember(attachment, attachment.Disposition, "Disposition");
        writer.WriteMember(attachment, attachment.ContentId, "ContentId");
        writer.WriteMember(attachment, attachment.Content, "Content");

        writer.WriteEndObject();
    }
}