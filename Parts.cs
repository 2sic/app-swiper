using ToSic.Razor.Blade;

public class Parts: Custom.Hybrid.Code12
{
  public dynamic RowClasses(dynamic settingsStack) {
    var textPosition = settingsStack.TextPosition ?? "none";
    return "row h-100 " + (textPosition == "cl" || textPosition == "cc" || textPosition == "cr" ? "align-items-center" : "") + " " + (textPosition == "bl" || textPosition == "bc" || textPosition == "br" ? "align-items-end" : "");
  }

  public dynamic ContentClasses(dynamic settingsStack) {
    var textPosition = settingsStack.TextPosition ?? "none";
    return (textPosition == "tc" || textPosition == "cc" || textPosition == "bc" ? "text-center" : "") + " " + (textPosition == "tr" || textPosition == "cr" || textPosition == "br" ? "text-right" : "");
  }

  public dynamic WrapperClasses(dynamic settingsStack) {
    var contentEffect = settingsStack.ContentEffect ?? "none";
    var contentTextPosition =settingsStack.TextPosition ?? "none";
    return "content-position-" + contentTextPosition + " content-effect-" + contentEffect + " " + (settingsStack.DarkContent ? "dark-content" : "light-content");
  }
}


