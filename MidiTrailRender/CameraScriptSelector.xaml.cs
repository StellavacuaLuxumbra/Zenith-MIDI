using Microsoft.CSharp;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace MIDITrailRender
{
    /// <summary>
    /// Interaction logic for CameraScriptSelector.xaml
    /// </summary>
    public partial class CameraScriptSelector : UserControl
    {
        public CameraScriptSelector()
        {
            InitializeComponent();
        }

        public void LoadScript(Settings settings)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "C# Script Files (*.cs)|*.cs|All Files (*.*)|*.*";
            openFileDialog.Title = "Select Camera Control Script";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string scriptPath = openFileDialog.FileName;
                    string scriptCode = File.ReadAllText(scriptPath);

                    // Compile the script
                    CSharpCodeProvider provider = new CSharpCodeProvider();
                    CompilerParameters parameters = new CompilerParameters();
                    parameters.GenerateInMemory = true;
                    parameters.ReferencedAssemblies.Add("System.dll");
                    parameters.ReferencedAssemblies.Add("System.Core.dll");
                    parameters.ReferencedAssemblies.Add(typeof(Settings).Assembly.Location);
                    parameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

                    CompilerResults results = provider.CompileAssemblyFromSource(parameters, scriptCode);

                    if (results.Errors.HasErrors)
                    {
                        string errors = "";
                        foreach (CompilerError error in results.Errors)
                        {
                            errors += $"Line {error.Line}: {error.ErrorText}\n";
                        }
                        MessageBox.Show($"Compilation errors:\n{errors}", "Script Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Get the script type and instance
                    Type scriptType = results.CompiledAssembly.GetType("CameraScript");
                    if (scriptType == null)
                    {
                        MessageBox.Show("Script must contain a class named 'CameraScript'", "Script Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    object scriptInstance = Activator.CreateInstance(scriptType);

                    // Find and call the UpdateCamera method
                    MethodInfo updateMethod = scriptType.GetMethod("UpdateCamera");
                    if (updateMethod == null)
                    {
                        MessageBox.Show("Script must contain a method named 'UpdateCamera'", "Script Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Call UpdateCamera with settings parameter
                    updateMethod.Invoke(scriptInstance, new object[] { settings });

                    MessageBox.Show("Camera script loaded successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading script:\n{ex.Message}", "Script Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
