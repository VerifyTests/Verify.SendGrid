class PersonalizationConverter :
    WriteOnlyJsonConverter<Personalization>
{
    public override void Write(VerifyJsonWriter writer, Personalization personalization)
    {
        writer.WriteStartObject();

        writer.WriteMember(personalization, personalization.From, "From");
        writer.WriteMember(personalization, personalization.Subject, "Subject");
        var to = personalization.Tos;
        if (to != null && to.Any())
        {
            if (to.Count == 1)
            {
                writer.WriteMember(personalization, to[0], "To");
            }
            else
            {
                writer.WriteMember(personalization, to, "To");
            }
        }

        var cc = personalization.Ccs;
        if (cc != null && cc.Any())
        {
            if (cc.Count == 1)
            {
                writer.WriteMember(personalization, cc[0], "Cc");
            }
            else
            {
                writer.WriteMember(personalization, cc, "Cc");
            }
        }

        var bcc = personalization.Bccs;
        if (bcc != null && bcc.Any())
        {
            if (bcc.Count == 1)
            {
                writer.WriteMember(personalization, bcc[0], "Bcc");
            }
            else
            {
                writer.WriteMember(personalization, bcc, "Bcc");
            }
        }

        writer.WriteMember(personalization, personalization.Headers, "Headers");
        writer.WriteMember(personalization, personalization.Substitutions, "Substitutions");
        writer.WriteMember(personalization, personalization.CustomArgs, "CustomArgs");
        if (personalization.SendAt != null)
        {
            writer.WriteMember(personalization, VerifySendGrid.UnixTimeStampToDateTime(personalization.SendAt.Value), "SendAt");
        }

        writer.WriteMember(personalization, personalization.TemplateData, "TemplateData");
        writer.WriteEndObject();
    }
}