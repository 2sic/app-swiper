using ToSic.Razor.Blade;
using System.Linq;
using System;

public class Helpers: Custom.Hybrid.Code12
{
  /// <summary>
  /// Generate bootstrap4 css class names for the overlay div, based on the settings of the slide
  /// </summary>
  public dynamic OverlayAlignClasses(dynamic settingsStack) {
    var pos = settingsStack.TextPosition ?? "";
    return (pos.StartsWith("c") ? "align-items-center" : "")   // center: cl, cc, cr
      + " " + (pos.StartsWith("b") ? "align-items-end" : "");  // bottom: bl, bc, br
  }

  /// <summary>
  /// Generate bootstrap4 css class names for the overlay div, based on the settings of the slide
  /// </summary>
  public dynamic OverlayTextAlignClasses(dynamic settingsStack) {
    var pageCss = GetService<Connect.Koi.ICss>();         // Service to get CSS information about the current Theme
    var pos = settingsStack.TextPosition ?? "";
    return (pos.EndsWith("c") ? "text-center" : "")    // center: tc, cc, bc
      + " " + (pos.EndsWith("r") && pageCss.Is("bs4") ? "text-right" : pos.EndsWith("r") && pageCss.Is("bs5") ? "text-end" : ""); // right:  tr, cr, br
  }

  /// <summary>
  /// Generate custom css class names for the overlay div, based on the settings of the slide
  /// This changes the effects as well as background gradients
  /// </summary>
  public dynamic SlideWrapperClasses(dynamic settingsStack) {
    return "content-position-" + (settingsStack.TextPosition ?? "none")
      + " content-effect-" + (settingsStack.OverlayEffect ?? "none")
      + (settingsStack.DarkContent ? " dark-content" : " light-content");
  }

  /// <summary>
  /// Generate a <picture> tag for responsive images, with various resolutions for each screen size
  /// </summary>
}


