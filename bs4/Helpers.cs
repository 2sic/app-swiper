using ToSic.Razor.Blade;
using System.Linq;
using System;

public class Helpers: Custom.Hybrid.Code12
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

  // todo: 2dm - it needs the real ratio!
  public dynamic PictureTag(string imgUrlOrig, string title) {
    var jpgQ = 70;
    var webpQ = 60;
    var defW = 800;
    var defH = 350;
    var ratio = Convert.ToSingle(defW) / defH;
    var widths = new[] { 320, 480, 640, 800, 1000, 1600 };
    var imgDefault = Link.Image(imgUrlOrig, format: "jpg", quality: jpgQ, resizeMode: "crop", scaleMode: "both", width: 1600);
    var setJpg = string.Join(",\n", widths.Select(width => SrcSetLine(imgUrlOrig, ratio, width, "jpg", jpgQ)));

    var pictureTag = Tag.Picture();
    pictureTag.Add(Tag.Source().Srcset(setJpg).Type("image/jpeg"));

    if(App.Settings.OptimizationsEnableWebP == true){
      var setWebp = string.Join(",\n", widths.Select(s => SrcSetLine(imgUrlOrig, ratio, s, "webp", webpQ)));
      pictureTag.Add(Tag.Source().Srcset(setWebp).Type("image/webp"));
    }
    pictureTag.Add(
      Tag.Img().Src(imgDefault + RatioParams(ratio, 1600)).Alt(title)
    );
    return pictureTag;
  }

  string SrcSetLine(string url, float ratio, int width, string format, int quality) {
    return Link.Image(url, width: width, aspectRatio: ratio, format: format, quality: quality, resizeMode: "crop", scaleMode: "both") + " " + width + "w";
  }

  string RatioParams(float ratio, float wReal) {
    var hReal = Convert.ToInt32(wReal / ratio);
    return "&w=" + wReal + "&h=" + hReal;
  }
}


