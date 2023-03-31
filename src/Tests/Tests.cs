﻿using System.Collections.Specialized;
using System.Net.Mail;
using System.Net.Mime;

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

    [Fact]
    public Task MailAttachmentFull()
    {
        var attachment = new Attachment(
            new MemoryStream(new byte[]
            {
                1
            }),
            new ContentType("text/html; charset=utf-8"))
        {
            Name = "name.txt",
            TransferEncoding = TransferEncoding.EightBit,
        };
        return Verify(attachment);
    }

    #region MailMessage

    [Fact]
    public Task MailMessage()
    {
        var mail = new MailMessage(
            from: "from@mail.com",
            to: "to@mail.com", subject: "The subject",
            body: "The body");
        return Verify(mail);
    }

    #endregion

    [Fact]
    public Task MailMessageFull()
    {
        var mail = new MailMessage(
            from: new("from@mail.com", "the from"),
            to: new MailAddress("sender@mail.com", "the to"))
        {
            Subject = "The subject",
            Body = "The body",
            Headers =
            {
                new NameValueCollection
                {
                    {
                        "key", "value"
                    }
                }
            },
            Priority = MailPriority.High,
            Sender = new("sender@mail.com", "the sender"),
            Bcc =
            {
                new MailAddress("bcc@mail.com", "the bcc")
            },
            CC =
            {
                new MailAddress("cc@mail.com", "the ccc")
            },
            BodyEncoding = Encoding.BigEndianUnicode,
            SubjectEncoding = Encoding.UTF32,
            HeadersEncoding = Encoding.ASCII,
            BodyTransferEncoding = TransferEncoding.EightBit,
            IsBodyHtml = true,
            ReplyToList =
            {
                new MailAddress("reply@mail.com", "the reply")
            },
            DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure | DeliveryNotificationOptions.Delay,
            Attachments =
            {
                new Attachment(new MemoryStream(new byte[]
                    {
                        1
                    }),
                    new ContentType("text/html; charset=utf-8"))
                {
                    Name = "name.txt"
                }
            }
        };
        return Verify(mail);
    }
}