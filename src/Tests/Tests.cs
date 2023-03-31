using System.Collections.Specialized;
using SendGrid.Helpers.Mail;

[UsesVerify]
public class Tests
{
    #region MailAttachment

    [Fact]
    public Task MailAttachment()
    {
        var attachment = new Attachment(
            new MemoryStream(new byte[]
            {
                1
            }),
            new ContentType("text/html; charset=utf-8"))
        {
            Name = "name.txt"
        };
        return Verify(attachment);
    }

    #endregion


    #region MailMessage

    [Fact]
    public Task MailMessage()
    {
        var mail = new SendGridMessage(
            from: "from@mail.com",
            to: "to@mail.com", subject: "The subject",
            body: "The body");
        return Verify(mail);
    }

    #endregion
}