# <img src="/src/icon.png" height="30px"> Verify.SendGrid

[![Discussions](https://img.shields.io/badge/Verify-Discussions-yellow?svg=true&label=)](https://github.com/orgs/VerifyTests/discussions)
[![Build status](https://ci.appveyor.com/api/projects/status/6jexhwrxrfbe9dsf?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-sendgrid)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.SendGrid.svg)](https://www.nuget.org/packages/Verify.SendGrid/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of [SendGrid](https://github.com/sendgrid/sendgrid-csharp).


## NuGet package

https://nuget.org/packages/Verify.SendGrid/


## Usage

<!-- snippet: Enable -->
<a id='snippet-enable'></a>
```cs
[ModuleInitializer]
public static void Initialize() =>
    VerifySendGrid.Initialize();
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L3-L9' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Attachment

<!-- snippet: Attachment -->
<a id='snippet-attachment'></a>
```cs
[Fact]
public Task Attachment()
{
    var contentBytes = "The content"u8.ToArray();
    var attachment = new Attachment
    {
        Filename = "name.txt",
        Content = Convert.ToBase64String(contentBytes),
        Type = "text/html",
        Disposition = "attachment"
    };
    return Verify(attachment);
}
```
<sup><a href='/src/Tests/Tests.cs#L6-L22' title='Snippet source file'>snippet source</a> | <a href='#snippet-attachment' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in: 

<!-- snippet: Tests.Attachment.verified.txt -->
<a id='snippet-Tests.Attachment.verified.txt'></a>
```txt
{
  Filename: name.txt,
  Disposition: attachment,
  Type: text/html,
  Content: The content
}
```
<sup><a href='/src/Tests/Tests.Attachment.verified.txt#L1-L6' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.Attachment.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### SendGridMessage

<!-- snippet: SendGridMessage -->
<a id='snippet-sendgridmessage'></a>
```cs
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
```
<sup><a href='/src/Tests/Tests.cs#L65-L81' title='Snippet source file'>snippet source</a> | <a href='#snippet-sendgridmessage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Results in: 

<!-- snippet: Tests.SendGridMessage.verified.txt -->
<a id='snippet-Tests.SendGridMessage.verified.txt'></a>
```txt
{
  From: DX Team <test@example.com>,
  Personalizations: [
    {
      To: Test User <test@example.com>
    }
  ],
  Subject: Sending with Twilio SendGrid is Fun,
  PlainTextContent: and easy to do anywhere, even with C#,
  HtmlContent: <strong>and easy to do anywhere, even with C#</strong>
}
```
<sup><a href='/src/Tests/Tests.SendGridMessage.verified.txt#L1-L11' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.SendGridMessage.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

[Grid](https://thenounproject.com/icon/grid-2082325/)  from [The Noun Project](https://thenounproject.com).
