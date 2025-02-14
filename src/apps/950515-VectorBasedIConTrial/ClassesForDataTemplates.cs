using System.Windows.Media;
using System.Windows.Shapes;

namespace VectorBasedIConTrial
{
    public class PathWrapper
    {
        public string TitleText { get; set; } = "Path Object";
        public Path PathObject { get; set; } = new Path(); 
    }

    public class DrawingImageWrapper
    {
        public string TitleText { get; set; } = "Drawing Image Object";
        public DrawingImage DrawingImageObject { get; 
            set; 
        } = new DrawingImage(); 
    }
}
