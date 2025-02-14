using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Baml2006;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xaml;

namespace VectorBasedIConTrial
{
    /// <summary>
    /// Interaction logic for DynamicResourceTrialOne.xaml
    /// </summary>
    public partial class DynamicResourceTrialOne : UserControl, INotifyPropertyChanged
    {
        // private static bool _isLoaded = false;
        private ResourceDictionary _resourceDictionary = null!;


        private object _activeResourceView = null!;

        public object ActiveResourceView
        {
            get { return _activeResourceView; }
            set {
                _activeResourceView = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public DynamicResourceTrialOne()
        {
            InitializeComponent();

            DataContext = this;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var currentAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            var resourceDictionaryList = GetAllResources();

            _resourceDictionary = resourceDictionaryList.FirstOrDefault()!;

            resourceKeysComboBox.Items.Clear();

            var resourceKeysComboBoxItems = new List<string>();

            foreach (DictionaryEntry resourceDictionaryItem in _resourceDictionary!)
            {
                resourceKeysComboBoxItems.Add((string)resourceDictionaryItem.Key);
            }

            // resourceKeysComboBoxItems.OrderBy(item => item).ToList();

            resourceKeysComboBoxItems.Sort();

            resourceKeysComboBoxItems.ForEach(item => resourceKeysComboBox.Items.Add(item));

            resourceKeysComboBox.SelectedIndex = 0;
        }

        private object? GetResourceObjectGivenKey(string key)
        {

            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            if (_resourceDictionary == null)
            {
                return null;
            }

            if (!_resourceDictionary.Contains(key))
            {
                return null;
            }

            object? valueToReturn = new object();

            foreach (DictionaryEntry resourceDictionaryItem in _resourceDictionary!)
            {
                string keyString = (string)resourceDictionaryItem.Key;

                if (string.IsNullOrWhiteSpace(keyString))
                    continue;

                if (keyString == key)
                {
                    return resourceDictionaryItem.Value;
                }
            }

            return null;
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public List<ResourceDictionary> GetAllResources()
        {
            var resourceDictionaryList = new List<ResourceDictionary>();
            List<System.IO.Stream> bamlStreams = new List<System.IO.Stream>();
            Assembly skinAssembly = Assembly.GetExecutingAssembly();
            var currentAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            ResourceManager rm = new ResourceManager("vectorbasediconresourcedictionary", skinAssembly);
            ResourceManager rm1 = new ResourceManager("vectorbasediconresourcedictionaryOne", skinAssembly);

            var resourceDictionaries = skinAssembly.GetManifestResourceNames().ToList();
            foreach (string resourceName in resourceDictionaries)
            {
                ManifestResourceInfo info = skinAssembly.GetManifestResourceInfo(resourceName)!;
                if (info.ResourceLocation != ResourceLocation.ContainedInAnotherAssembly)
                {
                    System.IO.Stream resourceStream = skinAssembly.GetManifestResourceStream(resourceName)!;
                    using (ResourceReader reader = new ResourceReader(resourceStream))
                    {
                        foreach (DictionaryEntry entry in reader)
                        {
                            var entryKeyString = entry.Key.ToString();

                            var xamlResource = entryKeyString!.Replace(".baml", ".xaml");

                            if (xamlResource == "dynamicresourcetrialone.xaml")
                            {
                                continue;
                            }

                            if (xamlResource == "mainwindow.xaml")
                            {
                                continue;
                            }

                            if (xamlResource == "app.xaml")
                            {
                                continue;
                            }

                            var resourceUri = new Uri($"/{currentAssemblyName};component/{xamlResource}", UriKind.RelativeOrAbsolute);

                            ResourceDictionary resourceDictionary = new ResourceDictionary();

                            try
                            {
                                resourceDictionary = new ResourceDictionary
                                {
                                    Source = resourceUri
                                };
                            }
                            catch (System.InvalidOperationException exception)
                            {
                                if (exception.Message.Contains("ResourceDictionary LoadFrom operation failed with URI"))
                                {
                                    // Swallo the exception and continue.
                                    continue;
                                }
                            }

                            resourceDictionaryList.Add(resourceDictionary);
                        }
                    }
                }
            }
            return resourceDictionaryList;
        }

        private void resourceKeysComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var text = (string)e.AddedItems[0]!;

            string text2 = (string)((ComboBox)sender).SelectedItem;

            // string text3 = (string)((ComboBoxItem)((ComboBox)sender).SelectedItem).Content;

            var resourceObject = GetResourceObjectGivenKey(text);

            if (resourceObject == null)
                return;

            var resourceObjectType = resourceObject.GetType();

            switch (resourceObjectType.Name)
            {
                case nameof(Path):
                    {
                        ActiveResourceView = new PathWrapper() { PathObject = (Path)resourceObject };
                        
                    }
                    break;
                case nameof(DrawingImage):
                    {
                        ActiveResourceView = new DrawingImageWrapper() { DrawingImageObject = (DrawingImage)resourceObject };
                    }
                    break;

                default:
                    {
                        // TrialBinding = "Here we go..select some other";
                    }
                    break;
            }
        }

        private void moveNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (resourceKeysComboBox.SelectedIndex + 1 == resourceKeysComboBox.Items.Count)
            {
                return;
            }
            resourceKeysComboBox.SelectedIndex = resourceKeysComboBox.SelectedIndex + 1;
        }

        private void moveBeforeButton_Click(object sender, RoutedEventArgs e)
        {
            if (resourceKeysComboBox.SelectedIndex == 0)
            {
                return;
            }

            resourceKeysComboBox.SelectedIndex = resourceKeysComboBox.SelectedIndex - 1;
        }

        public List<ResourceDictionary> GetResourceDictionary(Assembly assembly = null!)
        {

            if (assembly == null)
            {
                assembly = Assembly.GetExecutingAssembly();
            }

            var resourceDictionaryList = new List<ResourceDictionary>();

            System.IO.Stream stream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".g.resources")!;

            var t = assembly.GetManifestResourceNames().ToList()!;

            using (ResourceReader reader = new ResourceReader(stream))
            {
                // var t = reader.GetEnumerator();

                foreach (DictionaryEntry entry in reader)
                {
                    var readStream = entry.Value as System.IO.Stream;
                    Baml2006Reader bamlReader = new Baml2006Reader(readStream);
                    bamlReader.Read();
                    var nodeType = bamlReader.NodeType;
                    XamlType xamlType = bamlReader.Member.DeclaringType.BaseType;
                    
                    var loadedObject = System.Windows.Markup.XamlReader.Load(bamlReader);
                    if (loadedObject is ResourceDictionary)
                    {
                        var resourceDictionary = loadedObject as ResourceDictionary;
                        resourceDictionaryList.Add(resourceDictionary!);
                    }
                }
            }
            return resourceDictionaryList;
        }


    }
}
