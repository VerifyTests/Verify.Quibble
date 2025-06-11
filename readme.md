# <img src="/src/icon.png" height="30px"> Verify.Quibble

[![Discussions](https://img.shields.io/badge/Verify-Discussions-yellow?svg=true&label=)](https://github.com/orgs/VerifyTests/discussions)
[![Build status](https://ci.appveyor.com/api/projects/status/a87e2jpm0s4f34gu?svg=true)](https://ci.appveyor.com/project/SimonCropp/Verify-Quibble)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Quibble.svg)](https://www.nuget.org/packages/Verify.Quibble/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow [comparison](https://github.com/VerifyTests/Verify/blob/master/docs/comparer.md) of text via [Quibble](https://github.com/nrkno/Quibble).

**See [Milestones](../../milestones?state=closed) for release notes.**


## NuGet

 * https://nuget.org/packages/Verify.Quibble


## Usage


### Initialize

<!-- snippet: enable -->
<a id='snippet-enable'></a>
```cs
[ModuleInitializer]
public static void Init()
{
    VerifierSettings.UseStrictJson();
    VerifyQuibble.Initialize();
}
```
<sup><a href='/src/Tests/ModuleInit.cs#L3-L12' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

`UseStrictJson` is required since Verify by default [uses a variant of json](https://github.com/VerifyTests/Verify/blob/main/docs/serializer-settings.md#not-valid-json) which Quibble cannot parse.


### Verify

Given an existing verified file:

```json
{
  "Property1": "ValueA",
  "Property2": "ValueB"
}
```

And a test:

```cs
[Test]
public async Task Sample()
{
    var target = new Target(
        Property1: "ValueC",
        Property2: "ValueD");
    await Verifier.Verify(target);
}
```


### Diff results

When the comparison fails, the resulting differences will be included in the test result displayed to the user.

```txt
Results do not match.
Use DiffEngineTray to verify files.
Differences:
Received: Tests.Sample.received.json
Verified: Tests.Sample.verified.json
Compare Result:
String value difference at $.Property1: ValueC vs ValueA.
String value difference at $.Property2: ValueD vs ValueB.
```


## Icon

[Argument](https://thenounproject.com/term/argument/2311124/) designed by [Vinence Studio](https://thenounproject.com/vinzencestudio/) from [The Noun Project](https://thenounproject.com).
