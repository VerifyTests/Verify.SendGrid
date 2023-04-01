class AttachmentConverter :
    WriteOnlyJsonConverter<Attachment>
{
    public override void Write(VerifyJsonWriter writer, Attachment attachment)
    {
        writer.WriteStartObject();

        writer.WriteMember(attachment, attachment.Filename, "Filename");
        writer.WriteMember(attachment, attachment.Disposition, "Disposition");
        writer.WriteMember(attachment, attachment.Type, "Type");
        writer.WriteMember(attachment, attachment.ContentId, "ContentId");

        if (attachment.Type.StartsWith("text"))
        {
            var data = Convert.FromBase64String(attachment.Content);
            var decoded = Encoding.UTF8.GetString(data);
            writer.WriteMember(attachment, decoded, "Content");
        }

        writer.WriteEndObject();
    }
}