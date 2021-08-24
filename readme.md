# <img src="/src/icon.png" height="30px"> Verify.Quibble

[![Build status](https://ci.appveyor.com/api/projects/status/9ug1ufa69m4vf4ph?svg=true)](https://ci.appveyor.com/project/SimonCropp/Verify-Quibble)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Quibble.svg)](https://www.nuget.org/packages/Verify.Quibble/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow [comparison](https://github.com/VerifyTests/Verify/blob/master/docs/comparer.md) of text via [Quibble](https://github.com/nrkno/Quibble).

<a href='https://dotnetfoundation.org' alt='Part of the .NET Foundation'><img src='https://raw.githubusercontent.com/VerifyTests/Verify/master/docs/dotNetFoundation.svg' height='30px'></a><br>
Part of the <a href='https://dotnetfoundation.org' alt=''>.NET Foundation</a>


## NuGet package

https://nuget.org/packages/Verify.Quibble/


## Usage


### Initialize

Call `VerifyQuibble.Initialize()` once at assembly load time.


### Verify text

Given an existing verified file:

```
The
before
text
```

And a test:

```cs
[Test]
public async Task Sample()
{
    var target = @"The
after
text";
    await Verifier.Verify(target);
}
```


### Diff results

When the comparison fails, the resulting differences will be included in the test result displayed to the user.

```txt
Results do not match.
Differences:
Received: Tests.Sample.received.txt
Verified: Tests.Sample.verified.txt
Compare Result:
  The
- before
+ after
  text
```
