using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VectorBasedIConTrial
{
    /// <summary>
    /// Interaction logic for VectorBasedIConTestUserControl.xaml
    /// </summary>
    public partial class VectorBasedIConTestUserControl : UserControl
    {
        public Path? AudioIcon { get; set; }
        public Path? CompoAndDispoPathTrialOne { get; set; } = null;
        public Path? CompoAndDispoPathTrialTwo { get; set; } = null;
        public Path? CompoAndDispoDefaultStatePathOne { get; set; } = null;
        public Path? CompoAndDispoLowSeverityNonDefective { get; set; } = null;
        public Path? CompoAndDispoMediumSeverityServicable { get; set; } = null;
        public Path? CompoAndDispoNonServiceable { get; set; } = null;
        
        public DrawingImage? PauseIcon { get; set; } = null;
        public DrawingImage? PauseIconTwo { get; set; } = null;
        public DrawingImage? ClassificationAndDispositionImageObject { get; set; } = null;
        public VectorBasedIConTestUserControl()
        {
            InitializeComponent();

            DataContext = this;

            InitializePathObjects();

            InitializeDrawingImageObjects();
        }

        private void InitializePathObjects()
        {
            AudioIcon = GetPathObjectFromKey("AudioIconKey");
            CompoAndDispoPathTrialOne = GetPathObjectFromKey("CompoAndDispoPathTrialOneKey");
            CompoAndDispoPathTrialTwo = GetPathObjectFromKey("CompoAndDispoPathTrialTwoKey");
            CompoAndDispoNonServiceable = GetPathObjectFromKey("CompoAndDispoNonServiceableKey");
            
            CompoAndDispoDefaultStatePathOne = GetPathObjectFromKey("CompoAndDispoDefaultStatePathOneKey");
            CompoAndDispoLowSeverityNonDefective = GetPathObjectFromKey("CompoAndDispoLowSeverityNonDefectiveKey");
            CompoAndDispoMediumSeverityServicable = GetPathObjectFromKey("CompoAndDispoMediumSeverityServicableKey");
        }

        private void InitializeDrawingImageObjects()
        {
            PauseIcon = GetdDrawingImageObjectFromKey("PauseIconKey");
            PauseIconTwo = GetdDrawingImageObjectFromKey("PauseIconKey2");
            ClassificationAndDispositionImageObject = GetdDrawingImageObjectFromKey("ClassificationAndDispositionKey");


        }

        private Path GetPathObjectFromKey(string iconPathKey)
        {
            Path? iconPath = null;
            if (iconPathKey != null && iconPathKey.Length > 0)
            {
                iconPath = Application.Current.Resources[iconPathKey] as Path;
            }

            return iconPath!;
        }

        private DrawingImage GetdDrawingImageObjectFromKey(string drawingImageKey)
        {
            DrawingImage? iconDrawingImage = null;
            if (drawingImageKey != null && drawingImageKey.Length > 0)
            {
                iconDrawingImage = Application.Current.Resources[drawingImageKey] as DrawingImage;
            }

            return iconDrawingImage!;
        }
    }
}
