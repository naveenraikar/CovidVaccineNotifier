namespace CovidVaccineNotifier
{
  using System.Drawing;

  internal class Resources
  {
    private static global::System.Resources.ResourceManager resourceManager;
    private static Icon appIcon;
    private static Bitmap deleteImage;

    /// <summary>
    ///   Returns the cached ResourceManager instance used by this class.
    /// </summary>
    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal static global::System.Resources.ResourceManager ResourceManager
    {
      get
      {
        return resourceManager ??= new global::System.Resources.ResourceManager(typeof(Resources));
      }
    }

    internal static Icon AppIcon
    {
      get
      {
        return appIcon ??= ((Icon)(ResourceManager.GetObject("AppIcon.Icon")));
      }
    }

    internal static Bitmap DeleteImage
    {
      get
      {
        return deleteImage ??= ((Bitmap)(ResourceManager.GetObject("Delete.Image")));
      }
    }
  }
}