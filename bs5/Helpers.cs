using ToSic.Razor.Blade;
using System.Linq;
using System;
using ToSic.Sxc.Data;

public class Helpers: Custom.Hybrid.CodePro
{
  /// <summary>
  /// Generate class names for the overlay div, based on the settings of the slide
  /// </summary>
  public string OverlayAlignClasses(string textPosition) {
    var pos = textPosition ?? "";
    if (pos.StartsWith("c")) return "align-items-center";   // center: cl, cc, cr
    if (pos.StartsWith("b")) return "align-items-end";      // bottom: bl, bc, br
    return "";
  }

  /// <summary>
  /// Generate bootstrap4 css class names for the overlay div, based on the settings of the slide
  /// </summary>
  public string OverlayTextAlignClasses(string textPosition) {
    var pos = textPosition ?? "";
    if (pos.EndsWith("c")) return "text-center";    // center: tc, cc, bc
    if (pos.EndsWith("r")) return Kit.Css.Is("bs4") // right:  tr, cr, br
      ? "text-right"  // Bootstrap 4
      : "text-end";   // Bootstrap 5 / other
    return "";
  }

  /// <summary>
  /// Generate custom css class names for the overlay div, based on the settings of the slide
  /// This changes the effects as well as background gradients
  /// </summary>
  public string SlideWrapperClasses(string textPosition, string overlayEffect, bool darkContent) {
    return "content-position-" + (textPosition ?? "none")
      + " content-effect-" + (overlayEffect ?? "none")
      + " " + (darkContent ? "dark" : "light") + "-content";
  }

}