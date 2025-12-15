using HowlDev.IO.Text.ConfigFile.Enums;
using HowlDev.IO.Text.ConfigFile.Primitives;
using HowlDev.IO.Text.ConfigFile.Interfaces;
using HowlDev.IO.Text.Parsers.Enums;
using HowlDev.IO.Text.Parsers;
using System.Collections;

namespace HowlDev.IO.Text.ConfigFile.Tests.BaseTests;

internal class ParseFileAsOptionTests {
    [Test]
    public async Task AllObjectsMustBeClosedBeforeEnding1() {
        var p = new PseudoTextParser([
            (TextToken.StartObject, ""), 
            (TextToken.KeyValue, "Lorem"),
            (TextToken.StartObject, "Lorem")
        ]);
        await Assert.That(() => TextConfigFile.ParseFileAsOption(p))
            .Throws<InvalidOperationException>()
            .WithMessage("");
    }
}

internal class PseudoTextParser(IEnumerable<(TextToken, string)> list) : TokenParser {
    public IEnumerator<(TextToken, string)> GetEnumerator() {
        foreach (var item in list) yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}