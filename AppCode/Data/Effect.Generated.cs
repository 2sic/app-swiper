// DO NOT MODIFY THIS FILE - IT IS AUTO-GENERATED
// See also: https://go.2sxc.org/copilot-data
// To extend it, create a "Effect.cs" with this contents:
/*
namespace AppCode.Data
{
  public partial class Effect
  {
    // Add your own properties and methods here
  }
}
*/

// Generator:   CSharpDataModelsGenerator v17.06.02
// App/Edition: Swiper Slider/
// User:        2sic Web-Developer
// When:        2024-04-05 11:31:21Z
namespace AppCode.Data
{
  // This is a generated class for Effect 
  // To extend/modify it, see instructions above.

  /// <summary>
  /// Effect data. <br/>
  /// Generated 2024-04-05 11:31:21Z. Re-generate whenever you change the ContentType. <br/>
  /// <br/>
  /// Default properties such as `.Title` or `.Id` are provided in the base class. <br/>
  /// Most properties have a simple access, such as `.Configuration`. <br/>
  /// For other properties or uses, use methods such as
  /// .IsNotEmpty("FieldName"), .String("FieldName"), .Children(...), .Picture(...), .Html(...).
  /// </summary>
  public partial class Effect: AutoGenerated.ZagEffect
  {  }
}

namespace AppCode.Data.AutoGenerated
{
  /// <summary>
  /// Auto-Generated base class for Default.Effect in separate namespace and special name to avoid accidental use.
  /// </summary>
  public abstract class ZagEffect: Custom.Data.CustomItem
  {
    /// <summary>
    /// Configuration as string. <br/>
    /// For advanced manipulation like scrubHtml, use .String("Configuration", scrubHtml: true) etc.
    /// </summary>
    public string Configuration => _item.String("Configuration", fallback: "");

    /// <summary>
    /// Name as string. <br/>
    /// For advanced manipulation like scrubHtml, use .String("Name", scrubHtml: true) etc.
    /// </summary>
    public string Name => _item.String("Name", fallback: "");
  }
}