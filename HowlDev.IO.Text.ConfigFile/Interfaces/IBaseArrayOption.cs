using System.ComponentModel;

namespace HowlDev.IO.Text.ConfigFile.Interfaces;
/// <summary/>
[EditorBrowsable(EditorBrowsableState.Never)]
public interface IBaseArrayOption : IBasePrimitiveOption {
    /// <summary/>
    IBaseConfigOption this[int index] { get; }
    /// <summary/>
    int Count { get; }
    /// <summary/>
    IEnumerable<IBaseConfigOption> Items { get; }

    /// <summary>
    /// Use primitives (int, bool double, string, DateTime, etc.) or classes to generate 
    /// an enumerable of that type. For objects, defaults to use both constructors and 
    /// properties. For strict, use <see cref="AsStrictEnumerable"/>. To use a custom 
    /// option set, use <see cref="AsEnumerable(OptionMappingOptions)"/>.
    /// </summary>
    /// <typeparam name="T">Primitive or Object</typeparam>
    /// <returns>Enumerable of the type parameter</returns>
    IEnumerable<T> AsEnumerable<T>();
    /// <summary>
    /// Use primitives (int, bool double, string, DateTime, etc.) or classes to generate 
    /// an enumerable of that type. For objects, uses the options passed in to parse with. 
    /// See <see cref="AsEnumerable()"/> or <see cref="AsStrictEnumerable"/> for logical defaults. 
    /// </summary>
    /// <typeparam name="T">Primitive or Object</typeparam>
    /// <returns>Enumerable of the type parameter</returns>
    IEnumerable<T> AsEnumerable<T>(OptionMappingOptions options);
    /// <summary>
    /// Use primitives (int, bool double, string, DateTime, etc.) or classes to generate 
    /// an enumerable of that type. Defaults to strict matching and checks both constructors and 
    /// properties. See <see cref="AsEnumerable()"/> and <see cref="AsEnumerable(OptionMappingOptions)"/> 
    /// for more options.
    /// </summary>
    /// <typeparam name="T">Primitive or Object</typeparam>
    /// <returns>Enumerable of the type parameter</returns>
    IEnumerable<T> AsStrictEnumerable<T>();
}