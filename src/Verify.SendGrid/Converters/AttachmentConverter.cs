class AttachmentConverter :
    WriteOnlyJsonConverter<Attachment>
{
    public override void Write(VerifyJsonWriter writer, Attachment attachment)
    {
        writer.WriteStartObject();

        writer.WriteMember(attachment, attachment.Filename, "Filename");
        writer.WriteMember(attachment, attachment.Disposition, "Disposition");
        writer.WriteMember(attachment, attachment.ContentId, "ContentId");
        //TODO: check Disposition and render text
        writer.WriteMember(attachment, attachment.Content, "Content");

        writer.WriteEndObject();
    }
}