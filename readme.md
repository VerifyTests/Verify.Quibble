# <img src="/src/icon.png" height="30px"> Verify.Quibble

[![Build status](https://ci.appveyor.com/api/projects/status/a87e2jpm0s4f34gu?svg=true)](https://ci.appveyor.com/project/SimonCropp/Verify-Quibble)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Quibble.svg)](https://www.nuget.org/packages/Verify.Quibble/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow [comparison](https://github.com/VerifyTests/Verify/blob/master/docs/comparer.md) of text via [Quibble](https://github.com/nrkno/Quibble).

<a href='https://dotnetfoundation.org' alt='Part of the .NET Foundation'><img src='https://raw.githubusercontent.com/VerifyTests/Verify/master/docs/dotNetFoundation.svg' height='30px'></a><br>
Part of the <a href='https://dotnetfoundation.org' alt=''>.NET Foundation</a>


## NuGet package

https://nuget.org/packages/Verify.Quibble/


## Usage


### Initialize

Call once at assembly load time:

```
VerifierSettings.UseStrictJson();
VerifyQuibble.Initialize();
```

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
