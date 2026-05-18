using BenchmarkDotNet.Attributes;
using HowlDev.IO.Text.Parsers;
using HowlDev.IO.Text.Parsers.Enums;

namespace HowlDev.IO.Text.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob]
public class ComplexObjectTextParserBench {
    private string jsonFile;
    private string yamlFile;
    public ComplexObjectTextParserBench() {
        jsonFile = File.ReadAllText("../../../../../../../data/ComplexObject.json");
        yamlFile = File.ReadAllText("../../../../../../../data/ComplexObject.yaml");
    }

    [Benchmark]
    public List<(TextToken token, string value)> ComplexJSONObject() =>
        [.. new JSONParser(jsonFile)];

    [Benchmark]
    public List<(TextToken token, string value)> ComplexYAMLObject() =>
        [.. new YAMLParser(yamlFile)];
}
