using SendGrid.Helpers.Mail;

[UsesVerify]
public class Tests
{
    #region Attachment

    [Fact]
    public Task Attachment()
    {
        var attachment = new Attachment
        {
            Filename = "name.txt",
            Content = "The content",
            Disposition = "text/html; charset=utf-8"
        };
        return Verify(attachment);
    }

    #endregion

    #region EmailAddress

    [Fact]
    public Task EmailAddress()
    {
        var address = new EmailAddress
        {
            Email = "joe.smith@example.com",
            Name = "Joe Smith"
        };
        return Verify(address);
    }

    #endregion
    #region Personalization

    [Fact]
    public Task Personalization()
    {
        var personalization = new Personalization
        {
            Subject = "The subject"
        };
        return Verify(personalization);
    }

    #endregion


    #region SendGridMessage

    [Fact]
    public Task SendGridMessage()
    {
        var mail = new SendGridMessage
        {
            From = new("test@example.com", "DX Team"),
            Subject = "Sending with Twilio SendGrid is Fun",
            PlainTextContent = "and easy to do anywhere, even with C#",
            HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>"
        };
        mail.AddTo(new EmailAddress("test@example.com", "Test User"));
        return Verify(mail);
    }

    #endregion

    [Fact]
    public Task SingleReplyTo()
    {
        var mail = new SendGridMessage
        {
            ReplyTo = new("test@example.com", "DX Team"),
        };
        return Verify(mail);
    }

    [Fact]
    public Task SingleReplyTos()
    {
        var mail = new SendGridMessage
        {
            ReplyTos = new()
            {
                new("test@example.com", "DX Team")
            },
        };
        return Verify(mail);
    }
    [Fact]
    public Task SingleReplyToAndReplyTos()
    {
        var mail = new SendGridMessage
        {
            ReplyTos = new()
            {
                new("test@example.com", "DX Team")
            },
        };
        return Verify(mail);
    }
}