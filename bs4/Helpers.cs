using ToSic.Razor.Blade;
using System.Linq;
using System;

public class Helpers: Custom.Hybrid.Code12
{
  public dynamic RowClasses(dynamic settingsStack) {
    var textPosition = settingsStack.TextPosition ?? "none";
    return (textPosition == "cl" || textPosition == "cc" || textPosition == "cr" ? "align-items-center" : "") + " " + (textPosition == "bl" || textPosition == "bc" || textPosition == "br" ? "align-items-end" : "");
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
  // WIP - ALMOST DONE
  public dynamic PictureTag(string imgUrlOrig, string title, string probablyRatio) {
    // Calculate ratio if it was provided
    float ratio = 1.1f;
    var help = "";
    help = "r1:" + probablyRatio;
    if (Text.Has(probablyRatio) && probablyRatio.IndexOf(":") > 0) {
      var splitter = probablyRatio.IndexOf(":");
      if (splitter > 0) {
        var w = probablyRatio.Substring(0, splitter);
        var h = probablyRatio.Substring(splitter + 1);

        help += "s:" + splitter + "-w:" + w + "-h:" + h;
        float wf;
        float hf;
        // if(float.TryParse(w, out wf) && wf > 0 && float.TryParse(h, out hf)) {
        //   help += "gotTo1";
        // }
        if (float.TryParse(w, out wf) && wf > 0 && float.TryParse(h, out hf) && hf > 0) {
          ratio = hf / wf;
          // help += "got here";
        }

help += "&rf=" + ratio;

      }
    }
    // var jpgQ = 70;
    // var webpQ = 60;
    // var defW = 800;
    // var defH = 350;
    // var ratio = Convert.ToSingle(defW) / defH;
    var widths = new[] { 320, 480, 640, 800, 1000, 1600 };
    var resizeSettings = AsDynamic(new {
      Format = "jpg",
      Quality = 70,
      ResizeMode = "crop",
      ScaleMode = "both",
      Width = 1600
    });


    var pictureTag = Tag.Picture();
    var setJpg = string.Join(",\n", widths.Select(width => Link.Image(imgUrlOrig, resizeSettings, width: width, aspectRatio: ratio) + "&r=" + help + " " + width + "w"));
    pictureTag.Add(Tag.Source().Srcset(setJpg).Type("image/jpeg"));

    var imgDefault = Link.Image(imgUrlOrig, resizeSettings);
    pictureTag.Add(
      Tag.Img().Src(imgDefault + RatioParams(ratio, 1600)).Alt(title)
    );
    return pictureTag;
  }

  private string SrcSetLine(string url, dynamic resizeSettings, int width) {
    return Link.Image(url, resizeSettings, width: width) + " " + width + "w";
  }

  private string RatioParams(float ratio, float wReal) {
    var hReal = Convert.ToInt32(wReal / ratio);
    return "&w=" + wReal + "&h=" + hReal + "&r=" + ratio;
  }
}


